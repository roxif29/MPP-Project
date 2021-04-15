using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using log4net;
using System.Configuration;

namespace ProiectC_Mpp.repository
{
    public static class DBUtils
    {
       private static SQLiteConnection instance = null;
        private static readonly ILog logger = LogManager.GetLogger("DBUtils");
        public static SQLiteConnection getConnection()
        {
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = createConnection();
                instance.Open();
                logger.Info("instance is open!");
            }
            return instance;
        }

        private static SQLiteConnection createConnection()
        {
            logger.Info("createConnection entry");
            string connectionString = "";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["curse"];
            if (settings != null)
            {
                connectionString = settings.ConnectionString;
                logger.InfoFormat("connectionString : {0}", connectionString);
            }
            return new SQLiteConnection(connectionString);
        }

        public static void closeConnection()
        {
            if (instance != null && instance.State != System.Data.ConnectionState.Closed)
            {
                instance.Close();
                logger.Info("connection successfully closed!");
            }
        }
    }
}