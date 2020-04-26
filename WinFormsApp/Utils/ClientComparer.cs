
using System;
using System.Collections.Generic;
using Data;

namespace WinFormsApp.Utils
{
    public class ClientComparer: IEqualityComparer<Client>
    {
        public bool Equals(Client x, Client y)
        {
            if (ReferenceEquals(x, y)) return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Name == y.Name;
        }
        public int GetHashCode(Client client)
        {
            if (ReferenceEquals(client, null)) return 0;

            return client.Name == null ? 0 : client.Name.GetHashCode();
        }
    }
}
