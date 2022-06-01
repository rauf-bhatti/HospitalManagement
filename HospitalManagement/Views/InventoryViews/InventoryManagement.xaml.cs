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

namespace HospitalManagement.Views.InventoryViews
{
    /// <summary>
    /// Interaction logic for InventoryManagement.xaml
    /// </summary>
    public partial class InventoryManagement : Window
    {
        private InventoryController inventoryController = new InventoryController();

        public InventoryManagement()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            this.listView_Main.ItemsSource = inventoryController.GetAllInventoryItems();
        }

        private void Btn_AddInventory_Click(object sender, RoutedEventArgs e)
        {
            InventoryEntry inventoryEntryForm = new InventoryEntry();
            inventoryEntryForm.ShowDialog();
            BindData();
        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = listView_Main.SelectedIndex;
            ViewInventory viewInventory = new ViewInventory(inventoryController.GetAllInventoryItems()[selectedIndex]);
            viewInventory.ShowDialog();
            BindData();

        }
    }
}
