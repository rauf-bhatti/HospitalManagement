using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    class Doctor : Person
    {
        public string Speciality { get; set; }

        public Doctor(string ID_Number, string FirstName, string LastName, int Age, string Address, string Speciality)
            : base(ID_Number, FirstName, LastName, Age, Address)
        {
            this.Speciality = Speciality;
        }
    }

}