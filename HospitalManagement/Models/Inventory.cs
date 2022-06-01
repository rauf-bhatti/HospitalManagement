using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public InventoryCategory Category { get; set; }

        public Inventory(int InventoryID, string ProductName, int ProductQuantity, InventoryCategory Category)
        {
            this.InventoryID = InventoryID;
            this.ProductName = ProductName;
            this.ProductQuantity = ProductQuantity;
            this.Category = Category;
        }

    }
}
