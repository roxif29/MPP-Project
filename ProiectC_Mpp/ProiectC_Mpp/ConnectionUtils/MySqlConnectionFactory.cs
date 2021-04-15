using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ProiectC_Mpp.ConnectionUtils
{
    public class MySqlConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection()
        {
            //MySql Connection
            String connectionString = "Database=mpp;" +
                                        "Data Source=localhost;" +
                                        "User id=test;" +
                                        "Password=passtest;";
            return new MySqlConnection(connectionString);


        }
    }
}
