using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Client : ClientBase
    {
        public Client(IDataReader reader)
        {
            if (reader["ClientID"] != DBNull.Value)
            {
                ClientID = (int)reader["ClientID"];
            }
            if (reader["Name"] != DBNull.Value)
            {
                Name = (string)reader["Name"];
            }
            if (reader["Address"] != DBNull.Value)
            {
                Address = (string)reader["Address"];
            }
            if (reader["PostCode"] != DBNull.Value)
            {
                PostCode = (string)reader["PostCode"];
            }
        }
        public Client() { }
    }
}
