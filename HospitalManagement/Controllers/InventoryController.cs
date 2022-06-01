using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Utilities;

namespace HospitalManagement.Controllers
{
    class InventoryController
    {
        private InventoryValidator inventoryValidator = new InventoryValidator();
        private HospitalManagement.Database.Database dbInstance = new HospitalManagement.Database.Database();
        private readonly string inventory_get_query = "SELECT * FROM Inventory_Table";


        private string QueryizeInsert(Inventory inventory)
        {
            return $"INSERT INTO Inventory_Table (ProductName, Quantity, Category) VALUES ('{inventory.ProductName}', '{inventory.ProductQuantity}', '{inventory.Category}');";
        }


        private string QueryizeModify(Inventory inventoryProduct)
        {
            return $"UPDATE Inventory_Table SET ProductName ='{inventoryProduct.ProductName}', Quantity = {inventoryProduct.ProductQuantity}, Category = {inventoryProduct.Category} WHERE Inventory_ID = {inventoryProduct.InventoryID};";

        }

        private string QueryizeDelete(Inventory inventoryProduct)
        {
            return $"DELETE FROM Inventory_Table WHERE Inventory_ID = {inventoryProduct.InventoryID};";
        }

        public List<Inventory> GetAllInventoryItems()
        {
            dynamic _dataReader = dbInstance.RunReceiveQuery(inventory_get_query, 1);
            List<Inventory> _inventoryList = new List<Inventory>();

            while (_dataReader.Read())
            {
                InventoryCategory category;
                Enum.TryParse<InventoryCategory>(_dataReader["Category"].ToString(), out category);
                _inventoryList.Add(new Inventory(Convert.ToInt32(_dataReader["Inventory_ID"].ToString()), _dataReader["ProductName"].ToString(), Convert.ToInt32(_dataReader["Quantity"].ToString()), category));
            }

            return _inventoryList;
        }

        public bool AddInventoryEntry(Inventory newInventory)
        {
            if (inventoryValidator.ValidateDataLength(newInventory.ProductName, 4, 50) &&
                newInventory.ProductQuantity > 0 && newInventory.ProductQuantity < 99) 
            {
                dbInstance.RunInsertionQuery(QueryizeInsert(newInventory));
                return true;
            }

            return false;
        }

        public bool ModifyInventoryEntry(Inventory inventory)
        {
            if (inventoryValidator.ValidateDataLength(inventory.ProductName, 4, 50) &&
                inventory.ProductQuantity > 0 && inventory.ProductQuantity < 99)
            {
                dbInstance.RunModificationQuery(QueryizeModify(inventory));
                return true;
            }

            return false;
        }

        public bool DeleteInventoryEntry(Inventory inventory)
        {
            dbInstance.RunDeletionQuery(QueryizeDelete(inventory));
            return true;
        }
    }
}
