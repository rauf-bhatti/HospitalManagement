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

namespace HospitalManagement.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btn_MngPatients_Click(object sender, RoutedEventArgs e)
        {
            PatientViews.PatientManagement ptnManagement = new PatientViews.PatientManagement();
            ptnManagement.ShowDialog();
        }

        private void Btn_ManageInventory_Click(object sender, RoutedEventArgs e)
        {
            InventoryViews.InventoryManagement invManagement = new InventoryViews.InventoryManagement();
            invManagement.ShowDialog();
        }

        private void Btn_ManagePhysicians_Click(object sender, RoutedEventArgs e)
        {
            DoctorViews.DoctorManagement docManagement = new DoctorViews.DoctorManagement();
            docManagement.ShowDialog();
        }
    }
}
