using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    class Inventory
    {
        int id;
        int Title;
        int Quantity;

        public Inventory(int id, int Title, int Quantity)
        {
            this.id = id;
            this.Title = Title;
            this.Quantity = Quantity;

        }

    }
}
