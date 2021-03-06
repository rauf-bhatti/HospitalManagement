using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class Doctor : Person
    {
        public Specialization Specialization { get; set; }
        public int Salary { get; set; }
        public Doctor(int ID_Number, string FirstName, string LastName, int Age, string Address, Specialization specialization, int Salary)
            : base(ID_Number, FirstName, LastName, Age, Address)
        {
            this.Specialization = Specialization;
            this.Salary = Salary;
        }
    }

}