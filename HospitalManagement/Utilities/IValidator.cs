using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Utilities
{
    public interface IValidator
    {
        public bool ValidateDataLength(string dataString, int lowerBound, int upperBound);
        public bool ValidateData(string dataString);
    }
}
