using WinFormsApp.View;
using WinFormsApp.Model;
using System.Collections.Generic;
using DatabaseSQL;
using Data;

namespace WinFormsApp.Presenter
{
    public class ClientsPresenter
    {
        private readonly IClientView _view;

        public ClientsPresenter(IClientView view)
        {
            _view = view;
            view.Presenter = this;
        }

        public List<ClientModel> LoadClientList()
        {
            var clients = Database.Instance.GetClients();
            return ConvertClientsToClientsModel(clients);
        }

        private List<ClientModel> ConvertClientsToClientsModel(List<Client> clients)
        {
            List<ClientModel> clientModels = new List<ClientModel>();

            foreach (Client client in clients)
            {
                ClientModel clientModel = new ClientModel(client);
                clientModels.Add(clientModel);
            }

            return clientModels;
        }
    }
}
