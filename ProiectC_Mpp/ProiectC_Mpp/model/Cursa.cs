using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.model
{
    public class Cursa:HasId<int>
    {
        public int Id { get; set; }
        public int NrPers { get; set; }
        public int CapacMotor { get; set; }

        public Cursa(int id,int nrPers, int capacMot)
        {
            Id = id;
            NrPers = nrPers;
            CapacMotor = capacMot;
        }
        public Cursa() { }
        public override bool Equals(object obj)
        {
            if(obj is Cursa)
            {
                Cursa c = obj as Cursa;
                return Id == c.Id;
            }return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator==(Cursa c1, Cursa c2)
        {
            return c1.Id == c2.Id;
        }
        public static bool operator !=(Cursa c1, Cursa c2)
        {
            return c1.Id != c2.Id;
        }
        public override string ToString()
        {
            return string.Format("Cursa (id:{0}), nr pers ({1}), cap motor ({2})", Id, NrPers, CapacMotor);
        }
    }
}
