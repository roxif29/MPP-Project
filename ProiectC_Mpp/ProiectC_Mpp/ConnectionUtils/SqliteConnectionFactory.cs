using System;
using System.Data;
using System.Data.SQLite;

//using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.ConnectionUtils
{
    public class SqliteConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection()
        {
            //Mono Sqlite Connection
            //String connectionString = "URI=file:/Users/grigo/didactic/MPP/ExempleCurs/2017/database/tasks.db,Version=3";
            //return new SqliteConnection(connectionString);

            // Windows Sqlite Connection, fisierul .db ar trebuie sa fie in directorul debug/bin
            //D:\MppProiect\mpp-proiect-repository-roxif29\curse.db
            String connectionString = "Data Source=D:\\MppProiect\\mpp-proiect-repository-roxif29\\curse.db;Version=3";
            return new SQLiteConnection(connectionString);
        }
    }
}
