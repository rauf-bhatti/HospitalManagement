using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosp_management_v0._1.Models
{
    class Doctor : Person
    {
        
        string Speciality { get; set; }

        public Doctor(string ID_Number, string FirstName, string LastName, int Age, string Address, string Speciality)
            : base(ID_Number, FirstName, LastName, Age, Address)
        {
            this.Speciality = Speciality;
        }

      
    
    
    }

}