using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Data;

namespace DatabaseSQL
{
    public class Database
    {
        private SqlConnection _connection;

        private const string UpdateClientCommand = "UpdateClient";
        private const string GetClientsCommand = "GetClients";
        private const string CreateLogCommand = "CreateLog";

        public static Database Instance { get; } = new Database();

        public SqlConnection Connection
        {
            get
            {
                lock (this)
                {
                    if (_connection == null || _connection.State == ConnectionState.Closed)
                    {

                        _connection =
                            new SqlConnection(ConfigurationManager.ConnectionStrings["Limedika_Task"].ConnectionString);
                        _connection.Open();
                    }

                }
                return _connection;
            }
        }
        public SqlCommand CreateCommand(string command)
        {
            SqlCommand cmd = new SqlCommand(command, Connection);
            cmd.CommandTimeout = 120;
            return cmd;
        }

        public int UpdateClient(Client client)
        {
            using (SqlCommand cmd = CreateCommand(UpdateClientCommand))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@ClientID", client.ClientID));
                cmd.Parameters.Add(new SqlParameter("@Name", client.Name));
                cmd.Parameters.Add(new SqlParameter("@Address", client.Address));
                cmd.Parameters.Add(new SqlParameter("@PostCode", client.PostCode));

                return (int)cmd.ExecuteScalar();
            }
        }

        public List<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            using (SqlCommand cmd = CreateCommand(GetClientsCommand))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client client = new Client(reader);
                        clients.Add(client);
                    }
                }
            }
            return clients;
        }
        public void CreateLog(string action)
        {
            using (SqlCommand cmd = CreateCommand(CreateLogCommand))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Action", action));

                cmd.ExecuteScalar();
            }
        }
    }
}
