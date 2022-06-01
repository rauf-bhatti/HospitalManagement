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
    /// Interaction logic for AddPatientHistory.xaml
    /// </summary>
    public partial class AddPatientHistory : Window
    {
        private int patientID;
        private PatientHistoryController patientHistoryController = new PatientHistoryController();
        public AddPatientHistory(int patientID, string Name)
        {
            this.patientID = patientID;
            InitializeComponent();
            InitializeSettings(Name);
        }

        private void InitializeSettings(string Name)
        {
            this.lbl_Main.Content = $"Entering Patient History for {Name}";


            DoctorController _doctorContext = new DoctorController();
            List<Models.Doctor> _doctorList = _doctorContext.GetAllDoctors();
            List<ComboBoxItem> _comboBoxItems = new List<ComboBoxItem>();

            for (int i = 0; i < _doctorList.Count; i++)
            {
                ComboBoxItem itemToAdd = new ComboBoxItem();
                itemToAdd.Content = _doctorList.ElementAt(i).ID_Number + ", " + _doctorList.ElementAt(i).FirstName + ", " + _doctorList.ElementAt(i).Specialization.ToString();
                _comboBoxItems.Add(itemToAdd);
            }

            this.cBox_AttendingDoctor.ItemsSource = _comboBoxItems;
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem c_diagnosis = (ComboBoxItem)cBox_Diagnosis.SelectedItem;
            ComboBoxItem attendingDoctor = (ComboBoxItem)cBox_AttendingDoctor.SelectedItem;

            Models.Diagnosis diagnosis;

            try
            {
                Enum.TryParse<Models.Diagnosis>(c_diagnosis.Content.ToString(), out diagnosis);

                if (patientHistoryController.InsertPatientHistory(new Models.PatientHistory(0, diagnosis, txtBox_Report.Text, txtBox_Notes.Text, attendingDoctor.Content.ToString(), date_EntryDate.SelectedDate.Value, patientID), patientID))
                {
                    MessageBox.Show($"[Success] Patient History for patient with ID {patientID} was added");
                }
                else
                {
                    MessageBox.Show("[Error] Some error occured. Try again!");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show($"[Error] Could not add Patiend History due to the error: {error.Message}");
            }
        }
    }
}
