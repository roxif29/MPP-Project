using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectC_Mpp.model.validator
{
    public class ValidationException:ApplicationException
    {
        public ValidationException() { }
        public ValidationException(String ms) : base(ms) { }
        public ValidationException(String ms, Exception e) : base(ms, e) { }

    }
}
