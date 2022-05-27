using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    class Staff : Person
    {
        
        string Designation { get; set; }

        public Staff(string ID_Number, string FirstName, string LastName, int Age, string Address, string Designation)
            : base(ID_Number, FirstName, LastName, Age, Address)
        {
            this.Designation = Designation;
        }

      
    
    
    }

}