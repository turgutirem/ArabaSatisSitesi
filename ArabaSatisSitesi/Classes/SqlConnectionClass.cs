using System.Data.SqlClient;
using System;
using System.Linq;
using System.Web;

namespace ArabaSatisSitesi.Classes
{
    public class SqlConnectionClass
    {
        public static SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ArabaSatis;Integrated Security=True");

        public static void CheckConnection()
        {
            if (connection.State==System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                    
            }
        }
    }
}
