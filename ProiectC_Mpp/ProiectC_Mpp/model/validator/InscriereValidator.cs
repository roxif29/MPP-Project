using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.model.validator
{
    class InscriereValidator:IValidator<Inscriere>
    {
        public void validate(Inscriere elem)
        {
            StringBuilder errorString = new StringBuilder();

           
            if (elem.Id < 0)
                errorString.Append("Id trebuie sa fie pozitiv");
         

            if (errorString.Length != 0)
                throw new ValidationException(errorString.ToString());
        }
    }
}
