using ProiectC_Mpp.model;
using System;
using System.Collections.Generic;
using log4net;
using System.Data;

namespace ProiectC_Mpp.repository.DB
{
    class ParticipantDbRepository : IParticipantRepository

    {
        private static readonly ILog log = LogManager.GetLogger("ParticipantRepository");
        public ParticipantDbRepository() { log.Info("Creating ParticipantBdRepository"); }

        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Participanti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No participant deleted!");
            }
        }

        public IEnumerable<Participant> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Participant> participanti = new List<Participant>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nume, echipa, capacMotor from Participanti";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String echipa = dataR.GetString(2);
                        int capacMotor = dataR.GetInt32(3);
                        
              
                        Participant participant = new Participant(id, nume, echipa, capacMotor);
                        participanti.Add(participant);
                    }
                }
            }

            return participanti;
        }

        public IEnumerable<Participant> findAll(string echipa)
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Participant> participanti = new List<Participant>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, nume, echipa, capacMotor from Participanti where echipa=@echipa";

                IDbDataParameter paramEchipa = comm.CreateParameter();
                paramEchipa.ParameterName = "@echipa";
                paramEchipa.Value = echipa;
                comm.Parameters.Add(paramEchipa);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String echipaV = dataR.GetString(2);
                        int capacMotor = dataR.GetInt32(3);
                        
              
                        Participant participant = new Participant(id, nume, echipa, capacMotor);
                        participanti.Add(participant);
                    }
                }
            }

            return participanti;
        }

        public Participant findOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume, echipa, capacMotor from Participanti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String echipa = dataR.GetString(2);
                        int capacMotor = dataR.GetInt32(3);


                        Participant participant = new Participant(id, nume, echipa, capacMotor);
                        log.InfoFormat("Exiting findOne with value {0}", participant);
                        return participant;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void save(Participant entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Participanti values (@id, @nume, @echipa, @capacMotor)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.Nume;
                comm.Parameters.Add(paramNume);

                var paramEchipa = comm.CreateParameter();
                paramEchipa.ParameterName = "@echipa";
                paramEchipa.Value = entity.Echipa;
                comm.Parameters.Add(paramEchipa);

                var paramCapacMotor = comm.CreateParameter();
                paramCapacMotor.ParameterName = "@capacMotor";
                paramCapacMotor.Value = entity.CapacMotor;
                comm.Parameters.Add(paramCapacMotor);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No participant added !");
            }
        }
    }
}
