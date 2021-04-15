using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.model.validator
{
    public interface IValidator<T>
    {
        void validate(T elem);
    }

    public class ValidatorException : ApplicationException
    {
        public ValidatorException(string message) : base(message) { }
    }
}
