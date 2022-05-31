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
        int Salary { get; set; }

        public Staff(int ID_Number, string FirstName, string LastName, int Age, string Address, string Designation, int Salary)
            : base(ID_Number, FirstName, LastName, Age, Address)
        {
            this.Designation = Designation;
            this.Salary = Salary;
        }

      
    
    
    }

}