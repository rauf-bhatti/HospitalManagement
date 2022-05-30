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
using HospitalManagement.Models;
using HospitalManagement.Controllers;

namespace HospitalManagement.Views.PatientViews
{
    /// <summary>
    /// Interaction logic for DisplayPatient.xaml
    /// </summary>
    public partial class DisplayPatient : Window
    {
        private PatientController patientController = new PatientController();
        private Patient patient;
        public DisplayPatient(Patient patient)
        {
            this.patient = patient;
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            txtBox_FirstName.Text = patient.FirstName;
            txtBox_LastName.Text = patient.LastName;
            txtBox_Age.Text = Convert.ToString(patient.Age);
            txtBox_Address.Text = patient.Address;
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (patientController.DeletePatientEntry(new Patient(patient.ID_Number, txtBox_FirstName.Text, txtBox_LastName.Text, Convert.ToInt32(txtBox_Age.Text), txtBox_Address.Text)))
            {
                MessageBox.Show($"[Success] Information for patient no. PT{patient.ID_Number} has been deleted.");
                this.Close();
            }
            else
            {
                MessageBox.Show($"[Error] Information for patient no. PT{patient.ID_Number} could not be deleted.");
            }
        }

        private void Btn_Modify_Click(object sender, RoutedEventArgs e)
        {
            if (patientController.ModifyPatientEntry(new Patient(patient.ID_Number, txtBox_FirstName.Text, txtBox_LastName.Text, Convert.ToInt32(txtBox_Age.Text), txtBox_Address.Text)))
            {
                MessageBox.Show($"[Success] Information for patient no. PT{patient.ID_Number} has been modified.");
                this.Close();
            }
            else
            {
                MessageBox.Show($"[Error] Information for patient no. PT{patient.ID_Number} could not be modified.");
            }
        }
    }
}
