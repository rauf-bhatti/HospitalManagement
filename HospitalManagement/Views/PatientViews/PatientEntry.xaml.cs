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

namespace HospitalManagement.Views.PatientViews
{
    /// <summary>
    /// Interaction logic for PatientEntry.xaml
    /// </summary>
    public partial class PatientEntry : Window
    {
        private PatientController patientController = new PatientController();

        public PatientEntry()
        {
            InitializeComponent();
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            bool flag = patientController.AddPatientEntry(new Patient(-1, txtBox_FirstName.Text, txtBox_LastName.Text, Convert.ToInt32(txtBox_Age.Text), txtBox_Address.Text));

            if (!flag)
                MessageBox.Show("[Error] One of your fields have invalid data.");
            else
                MessageBox.Show("[Success] Patient record inserted.");
        }
    }
}
