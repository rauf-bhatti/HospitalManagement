using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HospitalManagement.Controllers;
using HospitalManagement.Models;

namespace HospitalManagement.Views.InventoryViews
{
    /// <summary>
    /// Interaction logic for ViewInventory.xaml
    /// </summary>
    public partial class ViewInventory : Window
    {
        private Inventory inventory;
        private InventoryController inventoryController = new InventoryController();

        public ViewInventory(Inventory inventory)
        {
            this.inventory = inventory;
            InitializeComponent();
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            this.txtBox_ProductName.Text = inventory.ProductName;
            this.txtBox_Quantity.Text = inventory.ProductQuantity.ToString();

            ComboBoxItem item = new ComboBoxItem();
            item.Content = inventory.Category.ToString();
            this.cBox_Category.SelectedValue = inventory.Category.ToString();
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (inventoryController.DeleteInventoryEntry(this.inventory))
            {
                MessageBox.Show($"[Success] Information has been deleted.");
                this.Close();
            }
            else
            {
                MessageBox.Show($"[Error] Information could not be deleted.");
            }
        }

        private void Btn_Modify_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)this.cBox_Category.SelectedItem;


            try
            {
                Models.InventoryCategory category;
                Enum.TryParse<Models.InventoryCategory>(selectedItem.Content.ToString(), out category);


                if (inventoryController.ModifyInventoryEntry(new Inventory(this.inventory.InventoryID, txtBox_ProductName.Text, Convert.ToInt32(txtBox_Quantity.Text), category)))
                {
                    MessageBox.Show($"[Success] Information has been modified.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"[Error] Information could not be modified.");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show($"[Exception Occured] {error.Message}");
            }
        }
    }
}
