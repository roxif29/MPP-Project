using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.model.validator
{
    class AngajatValidator:IValidator<Angajat>
    {
        public void validate(Angajat elem)
        {
            StringBuilder errorString = new StringBuilder();

            if (elem.Username == "")
                errorString.Append( "Username nu trebuie sa fie null");
            if (elem.Id < 0)
                errorString.Append("Id trebuie sa fie pozitiv");

            if (errorString.Length != 0)
                throw new ValidationException(errorString.ToString());
        }
    }
}
