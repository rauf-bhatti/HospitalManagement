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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HospitalManagement.Views;
using HospitalManagement.Controllers;

namespace HospitalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainController mainController = new MainController();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            
            if (mainController.ValidateLogin(txtBox_username.Text, txtBox_password.Password))
            {
                Dashboard dashboard = new Dashboard();
                this.Hide();
                dashboard.ShowDialog();
            }
            else
            {
                MessageBox.Show("[Login Error] Wrong Username/Password");
            }
        }
    }
}
