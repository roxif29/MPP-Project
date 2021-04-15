using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.model
{
    class Participant: HasId<int>
    {
        public int Id { get; set; }
        public int CapacMotor { get; set; }
        public string Nume { get; set; }
        public string Echipa { get; set; }

        public Participant( int id,string nume, string echipa, int capacMotor)
        {
            Id = id;
            CapacMotor = capacMotor;
            Nume = nume;
            Echipa = echipa;
        }
        public Participant() { }
        public override bool Equals(object obj)
        {
            if (obj is Participant)
            {
                Participant p = obj as Participant;
                return Id == p.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Participant p1, Participant p2)
        {
            return p1.Id == p2.Id;
        }
        public static bool operator !=(Participant p1, Participant p2)
        {
            return p1.Id != p2.Id;
        }
        public override string ToString()
        {
            return string.Format("Participant (id:{0}), nume participant ({1}), echipa ({2})", Id, Nume, Echipa);
        }
    }
}
