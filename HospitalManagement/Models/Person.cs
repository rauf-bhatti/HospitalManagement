using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public abstract class Person
    {
        public int ID_Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public Person(int ID_Number, string FirstName, string LastName, int Age, string Address)
        {
            this.ID_Number = ID_Number;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
            this.Address = Address;
        }
    }
}
