using System.IO;
using WinFormsApp.View;
using Newtonsoft.Json;
using System.Collections.Generic;
using DatabaseSQL;
using Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace WinFormsApp.Presenter
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        
        public MainPresenter(IMainView view)
        {
            _view = view;
            view.Presenter = this;
        }

        public void ImportClients()
        {
            var clientNamesFromDB = Database.Instance.GetClients().Select(c => c.Name);
            var clientsFromJson = LoadJson().Distinct(new Utils.ClientComparer()).ToList();

            foreach (Client client in clientsFromJson)
            {
                if (!clientNamesFromDB.Contains(client.Name))
                {
                    int clientId = Database.Instance.UpdateClient(client);
                    Database.Instance.CreateLog($"Client created. Name - {client.Name}, ClientID - {clientId}.");
                }
            }
        }
        public async void UpdatePostalCodes()
        {
            var clients = Database.Instance.GetClients();
            foreach (Client client in clients)
            {
                var requestUrl = string.Format(Properties.Settings.Default.PostItUrl, client.Address.Trim(), Properties.Settings.Default.PostItKey);
                dynamic response = JsonConvert.DeserializeObject(await GetAsync(requestUrl));
                if (client.PostCode != (string)response.data[0].post_code)
                {
                    client.PostCode = response.data[0].post_code;
                    Database.Instance.UpdateClient(client);
                    Database.Instance.CreateLog($"Client Post Code updated. Name - {client.Name}, ClientID - {client.ClientID}, PostCode  {client.PostCode}.");
                }
            }
        }
        private List<Client> LoadJson()
        {
            using (StreamReader reader = new StreamReader(Properties.Settings.Default.ClientJsonFile))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Client>>(json);
            }
        }
        private async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
