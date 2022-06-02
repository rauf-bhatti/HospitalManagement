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

namespace HospitalManagement.Views.DoctorViews
{
    /// <summary>
    /// Interaction logic for DoctorManagement.xaml
    /// </summary>
    public partial class DoctorManagement : Window
    {
        private DoctorController doctorController = new DoctorController();
        public DoctorManagement()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            this.listView_Main.ItemsSource = this.doctorController.GetAllDoctors();
        }

        private void Btn_AddPhysician_Click(object sender, RoutedEventArgs e)
        {
            DoctorEntry doctorEntryForm = new DoctorEntry();
            doctorEntryForm.ShowDialog();
            BindData();
        }

        private void listView_Main_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex = listView_Main.SelectedIndex;
            ViewDoctor _viewDoctor = new ViewDoctor(doctorController.GetAllDoctors()[selectedIndex]);
            _viewDoctor.ShowDialog();
        }
    }
}
