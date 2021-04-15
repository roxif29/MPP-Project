using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.model.validator
{
    class ParticipantValidator:IValidator<Participant>
    {
        public void validate(Participant elem)
        {
            StringBuilder errorString = new StringBuilder();

            if (elem.Echipa == "")
                errorString.Append("Echipa nu trebuie sa fie null");
            if (elem.Nume == "")
                errorString.Append("Nume nu trebuie sa fie null");
            if (elem.Id < 0)
                errorString.Append("Id trebuie sa fie pozitiv");
          
            if (errorString.Length != 0)
                throw new ValidationException(errorString.ToString());
        }
    }
}
