using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.Data;
using ProiectC_Mpp.model;

namespace ProiectC_Mpp.repository.DB
{
    class AngajatDbRepository : IAngajatRepository
    {
        private static readonly ILog log = LogManager.GetLogger("AngajatDbRepository");
        public AngajatDbRepository() { log.Info("Creating AngajatDbRepository"); }

    
        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Angajati where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No angajat deleted!");
            }
        }
        //int id,string user, string pass
        public IEnumerable<Angajat> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Angajat> angajati = new List<Angajat>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, username, pass from Angajati";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String username = dataR.GetString(1);
                        String pass = dataR.GetString(2);
                    
                        Angajat angajat = new Angajat(id, username,pass);
                        angajati.Add(angajat);
                    }
                }
            }

            return angajati;
        }

        public Angajat findOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, username, pass from Angajati where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String username = dataR.GetString(1);
                        String pass = dataR.GetString(2);
                        
                        Angajat angajat = new Angajat(id, username, pass);
                        log.InfoFormat("Exiting findOne with value {0}", angajat);
                        return angajat;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public Angajat findOne(string user, string pass)
        {
            IEnumerable<Angajat> angajati = findAll();
            Angajat result = new Angajat();
            foreach (Angajat a in angajati)
            {
                if (a.Pass==pass && a.Username==user)
                {
                    result.Username = user;
                    result.Pass = pass;
                    result.Id = a.Id;
                    return result;
                }
            }
            return null;
        }
        public void save(Angajat entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Angajati values (@id, @username, @pass)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = entity.Username;
                comm.Parameters.Add(paramUsername);

                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@pass";
                paramPass.Value = entity.Pass;
                comm.Parameters.Add(paramPass);


                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No angajat added !");
            }
        }
    }
}
