using ProiectC_Mpp.model;
using ProiectC_Mpp.repository.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProiectC_Mpp.service
{
    class ServiceLogin
    {
        private AngajatDbRepository AngajatDBRepository;

        public ServiceLogin(AngajatDbRepository angajatDBRepository)
        {
            AngajatDBRepository = angajatDBRepository;
        }

        public bool login(string user, string pass)
        {
            Angajat result = AngajatDBRepository.findOne(user, pass);
            if(result==null)
                return false;
            return true;
        }
    }
}
