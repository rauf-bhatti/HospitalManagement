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
    /// Interaction logic for DoctorEntry.xaml
    /// </summary>
    /// 
    public partial class DoctorEntry : Window
    {
        private DoctorController doctorController = new DoctorController();
        public DoctorEntry()
        {
            InitializeComponent();
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)this.cBox_Specialization.SelectedItem;

            try
            {
                Models.Specialization specialization;
                Enum.TryParse<Models.Specialization>(selectedItem.Content.ToString(), out specialization);

                if (this.doctorController.AddDoctorEntry(new Models.Doctor(0, this.txtBox_FirstName.Text, this.txtBox_LastName.Text, Convert.ToInt32(this.txtBox_Age.Text), this.txtBox_Address.Text, specialization, Convert.ToInt32(this.txtBox_Salary.Text))))
                {
                    MessageBox.Show("[Success] Entry has been inserted.");
                }
                else
                {
                    MessageBox.Show("[Success] No entry was inserted.");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show($"[Exception Occured] Some error occured! Please try entering again! Message: {error.Message}");
            }
           
        }
    }
}
