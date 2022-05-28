using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    class Patient : Person
    {
        public List<PatientHistory> PatientHistory = new List<PatientHistory>();

        public Patient(string ID_Number, string FirstName, string LastName, int Age, string Address)
            : base(ID_Number, FirstName, LastName, Age, Address)
        {
            
        }
    }
}
