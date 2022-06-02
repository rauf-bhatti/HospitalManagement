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

namespace HospitalManagement.Views.DoctorViews
{
    /// <summary>
    /// Interaction logic for ViewDoctor.xaml
    /// </summary>
    public partial class ViewDoctor : Window
    {
        private DoctorController doctorController = new DoctorController();
        private Doctor doctor;
        public ViewDoctor(Doctor doctor)
        {
            this.doctor = doctor;
            InitializeComponent();
            InitializeSettings();
        }

        private void InitializeSettings()
        {
            this.txtBox_FirstName.Text = doctor.FirstName;
            this.txtBox_LastName.Text = doctor.LastName;
            this.txtBox_Age.Text = doctor.Age.ToString();
            this.txtBox_Address.Text = doctor.Address;
            this.txtBox_Salary.Text = doctor.Salary.ToString();
            this.cBox_Specialization.SelectedItem = doctor.Specialization;
        }

        private void Btn_Modify_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)this.cBox_Specialization.SelectedItem;

            try
            {
                Models.Specialization specialization;
                Enum.TryParse<Models.Specialization>(selectedItem.Content.ToString(), out specialization);

                if (this.doctorController.ModifyDoctorEntry(new Models.Doctor(doctor.ID_Number, this.txtBox_FirstName.Text, this.txtBox_LastName.Text, Convert.ToInt32(this.txtBox_Age.Text), this.txtBox_Address.Text, specialization, Convert.ToInt32(this.txtBox_Salary.Text))))
                {
                    MessageBox.Show("[Success] Entry has been modified.");
                }
                else
                {
                    MessageBox.Show("[Error] No entry was modified.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show($"[Exception Occured] Some error occured! Please try entering again! Message: {error.Message}");
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.doctorController.DeleteDoctorEntry(doctor))
            {
                MessageBox.Show("[Success] Entry has been deleted.");
            }
            else
            {
                MessageBox.Show("[Error] Entry could not be deleted.");
            }
        }
    }
}
