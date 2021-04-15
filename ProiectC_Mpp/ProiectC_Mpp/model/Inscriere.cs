using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.model
{
    class Inscriere:HasId<int>
    {
        public int Id { get; set; }
        public Cursa C { get; set; }
        public Participant P { get; set; }


        public Inscriere(int id,Cursa c,Participant p)
        {
            Id = Id;
            C = c;
            P = p;
            
        }
        public Inscriere(Cursa c,Participant p)
        {
          
            C = c;
            P = p;
            
        }
        public override bool Equals(object obj)
        {
            if (obj is Inscriere)
            {
                Inscriere i = obj as Inscriere;
                return Id == i.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Inscriere i1, Inscriere i2)
        {
            return i1.Id == i2.Id;
        }
        public static bool operator !=(Inscriere i1, Inscriere i2)
        {
            return i1.Id != i2.Id;
        }
        public override string ToString()
        {
            return string.Format("Inscriere (id:{0}), cursa ({1}), nume participant ({2}))",Id,C.CapacMotor,P.Nume);
        }
    }
}
