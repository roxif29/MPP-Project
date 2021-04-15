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
    class CursaDbRepository : ICursaRepository

    {

        private static readonly ILog log = LogManager.GetLogger("CursaDbRepository");
        public CursaDbRepository() { log.Info("Creating CursaDbRepository"); }

        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Curse where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No cursa deleted!");
            };
        }
        //int id,int nrPers, int capacMot
        public IEnumerable<Cursa> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Cursa> curse = new List<Cursa>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nrPers, capacMotor from Curse";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        Console.WriteLine(id);
                        int nrPers = dataR.GetInt32(1);
                        int capacMotor = dataR.GetInt32(2);
                        Cursa cursa = new Cursa(id, nrPers, capacMotor);
                        curse.Add(cursa);
                    }
                }
            }

            return curse;
        }

        public IEnumerable<Cursa> findAll(int capacMotor)
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Cursa> curse = new List<Cursa>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nrPers, capacMotor from Curse where capacMotor=@capacMotor";

                IDbDataParameter paramCapacMotor = comm.CreateParameter();
                paramCapacMotor.ParameterName = "@capacMotor";
                paramCapacMotor.Value = capacMotor;
                comm.Parameters.Add(paramCapacMotor);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        int nrPers = dataR.GetInt32(1);
                        int capacMotorV = dataR.GetInt32(2);
                        Cursa cursa = new Cursa(id, nrPers, capacMotor);
                        curse.Add(cursa);
                    }
                }
            }

            return curse;
        }

        public Cursa findOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nrPers, capacMotor from Curse where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        int nrPers = dataR.GetInt32(1);
                        int capacMotor = dataR.GetInt32(2);
                        Cursa cursa = new Cursa(id, nrPers, capacMotor);
                        log.InfoFormat("Exiting findOne with value {0}", cursa);
                        return cursa;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void save(Cursa entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Curse values (@id, @nrPers, @capacMotor)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramNrPers = comm.CreateParameter();
                paramNrPers.ParameterName = "@nrPers";
                paramNrPers.Value = entity.NrPers;
                comm.Parameters.Add(paramNrPers);

                var paramCapacMotor = comm.CreateParameter();
                paramCapacMotor.ParameterName = "@capacMotor";
                paramCapacMotor.Value = entity.CapacMotor;
                comm.Parameters.Add(paramCapacMotor);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No cursa added !");
            }
        }
    }
}
