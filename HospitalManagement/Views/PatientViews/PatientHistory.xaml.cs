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
    /// Interaction logic for PatientHistory.xaml
    /// </summary>
    public partial class PatientHistory : Window
    {
        private int patientID;
        private string patientName;
        private PatientHistoryController patientHistoryController = new PatientHistoryController(); 

        public PatientHistory(int patientID, string patientName)
        {
            this.patientID = patientID;
            this.patientName = patientName;

            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            listView_Main.ItemsSource = patientHistoryController.GetAllPatientHistory(patientID);
        }

        private void Btn_AddHistory_Click(object sender, RoutedEventArgs e)
        {
            AddPatientHistory addPatientHistoryWindow = new AddPatientHistory(patientID, patientName);
            addPatientHistoryWindow.ShowDialog();
            BindData();
        }
    }
}