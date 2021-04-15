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
    class InscriereDbRepository : IInscriereRepository
    {
        private static readonly ILog log = LogManager.GetLogger("InscriereDbRepository");
        public InscriereDbRepository() { log.Info("Creating InscriereDbRepository"); }

        private ParticipantDbRepository participantDb=new ParticipantDbRepository();
        private CursaDbRepository cursaDb=new CursaDbRepository();


        public void delete(int id)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "delete from Inscrieri where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                var dataR = comm.ExecuteNonQuery();
                if (dataR == 0)
                    throw new RepositoryException("No inscriere deleted!");
            }
        }
        //int id, Cursa c,Participant p
        public IEnumerable<Inscriere> findAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Inscriere> inscrieri = new List<Inscriere>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, idCursa, idParticipant from Inscrieri";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        int idCursa = dataR.GetInt32(1);
                        int idParticipant = dataR.GetInt32(2);
                        Participant p = participantDb.findOne(idParticipant);
                        Cursa c = cursaDb.findOne(idCursa);

                        Inscriere inscriere = new Inscriere(id,c,p);
                        inscrieri.Add(inscriere);
                    }
                }
            }

            return inscrieri;
        }
        //int id, Cursa c,Participant p
        public Inscriere findOne(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume, echipa, capacMotor from Inscrieri where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        int idCursa = dataR.GetInt32(1);
                        int idParticipant = dataR.GetInt32(2);
                        Participant p = participantDb.findOne(idParticipant);
                        Cursa c = cursaDb.findOne(idCursa);

                        Inscriere inscriere = new Inscriere(id, c, p);
                        log.InfoFormat("Exiting findOne with value {0}", inscriere);
                        return inscriere;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public void save(Inscriere entity)
        {
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Inscrieri values (@id, @idCursa, @idParticipant)";
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id+1;
                comm.Parameters.Add(paramId);


                var paramIdCursa = comm.CreateParameter();
                paramIdCursa.ParameterName = "@idCursa";
                paramIdCursa.Value = entity.C.Id;
                comm.Parameters.Add(paramIdCursa);

                var paramIdParticipant = comm.CreateParameter();
                paramIdParticipant.ParameterName = "@idParticipant";
                paramIdParticipant.Value = entity.P.Id;
                comm.Parameters.Add(paramIdParticipant);
             
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    throw new RepositoryException("No inscriere added !");
            }
        }
    }
}
