using Data;

namespace WinFormsApp.Model
{
    public class ClientModel: ClientBase
    {
        public ClientModel(Client client)
        {
            ClientID = client.ClientID;
            Name = client.Name;
            Address = client.Address;
            PostCode = client.PostCode;
        }
    }
}
