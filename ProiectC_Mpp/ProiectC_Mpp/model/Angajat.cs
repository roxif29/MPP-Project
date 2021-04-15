using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.model
{
    class Angajat:HasId<int>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }

        public Angajat(int id,string user, string pass)
        {
            Id = Id;
            Username = user;
            Pass = pass;
        }
        public Angajat() { }
        public override bool Equals(object obj)
        {
            if (obj is Angajat)
            {
                Angajat a = obj as Angajat;
                return Id == a.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        //public static bool operator ==(Angajat a1, Angajat a2)
        //{
        //    return a1.Id == a2.Id;
        //}
        //public static bool operator !=(Angajat a1, Angajat a2)
        //{
        //    return a1.Id != a2.Id;
        //}
        public override string ToString()
        {
            return string.Format("Angajat (id:{0}), username ({1})", Id, Username);
        }
    }
}
