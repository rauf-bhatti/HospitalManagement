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

namespace HospitalManagement.Views.PatientViews
{
    /// <summary>
    /// Interaction logic for PatientManagement.xaml
    /// </summary>
    public partial class PatientManagement : Window
    {
        private PatientController controller = new PatientController();

        public PatientManagement()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            this.listView_Main.ItemsSource = controller.GetAllPatients();
        }

        private void Btn_AddPatient_Click(object sender, RoutedEventArgs e)
        {
            PatientEntry PatientEntryForm = new PatientEntry();
            PatientEntryForm.ShowDialog();
            BindData();
        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = listView_Main.SelectedIndex;
            DisplayPatient displayPatient = new DisplayPatient(controller.GetAllPatients()[selectedIndex]);
            displayPatient.ShowDialog();
            BindData();
        }
    }
}