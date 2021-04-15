using ProiectC_Mpp.model;
using ProiectC_Mpp.repository.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.service
{
    class ServiceAll
    {
        private AngajatDbRepository AngajatDbRepository;
        private CursaDbRepository CursaDbRepository;
        private InscriereDbRepository InscriereDbRepository;
        private ParticipantDbRepository ParticipantDbRepository;

        public ServiceAll(AngajatDbRepository angajatDbRepository, CursaDbRepository cursaDbRepository, InscriereDbRepository inscriereDbRepository, ParticipantDbRepository participantDbRepository)
        {
            AngajatDbRepository = angajatDbRepository;
            CursaDbRepository = cursaDbRepository;
            InscriereDbRepository = inscriereDbRepository;
            ParticipantDbRepository = participantDbRepository;
        }

        public IEnumerable<Cursa> getAllCurse()
        {
            return CursaDbRepository.findAll();
        }
        public IEnumerable<Participant> getAllParticipanti()
        {
            return ParticipantDbRepository.findAll();
        }

        public IEnumerable<Cursa> findByCapacMotor(int capacMotor)
        {
            return CursaDbRepository.findAll(capacMotor);
        }

        public int getNrParticipantiCursa(int idCursa)
        {
            return CursaDbRepository.findOne(idCursa).NrPers;
        }

        public IEnumerable<Participant> getAllParticipantsByEchipa(string echipa)
        {
            IEnumerable<Participant> participants = ParticipantDbRepository.findAll();
            List<Participant> result = new List<Participant>();
            foreach (Participant p in participants)
            {
                if (p.Echipa == echipa)
                {
                    result.Add(p);
                }
            }
            return result;
        }

        public Participant findParticipantByNumeSiEchipaSiCapacMotor(int capacMotor, string nume, string echipa)
        {
            IEnumerable<Participant> participants = ParticipantDbRepository.findAll();
            Participant result = new Participant();
            foreach(Participant p in participants)
            {
                if(p.Echipa==echipa && p.CapacMotor == capacMotor && p.Nume == nume)
                {
                    result.Id = p.Id;
                    result.Nume = nume;
                    result.CapacMotor = capacMotor;
                    result.Echipa = echipa;
                    return result;
                }
            }
            return null;
        }

        public Cursa findCursaByCapacMotor(int capacMotor)
        {
            IEnumerable<Cursa> curse = CursaDbRepository.findAll();
            Cursa result = new Cursa();
            foreach (Cursa c in curse)
            {
                if (c.CapacMotor == capacMotor)
                {
                    result.Id = c.Id;
                    result.NrPers = c.NrPers;
                    result.CapacMotor = c.CapacMotor;
                    return result;
                }

            }
            return null;
        }

        public Cursa findCursa(int id)
        {
            return CursaDbRepository.findOne(id);
        }
        public void inscriereParticipant(int capacMotor, string nume, string echipa)
        {

            InscriereDbRepository.save(new Inscriere(findCursaByCapacMotor(capacMotor), findParticipantByNumeSiEchipaSiCapacMotor(capacMotor, nume, echipa)));

        }

    }
}
