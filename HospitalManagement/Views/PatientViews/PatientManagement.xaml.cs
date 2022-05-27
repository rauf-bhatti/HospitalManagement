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

namespace HospitalManagement.Views.PatientViews
{
    /// <summary>
    /// Interaction logic for PatientManagement.xaml
    /// </summary>
    public partial class PatientManagement : Window
    {
        public PatientManagement()
        {
            InitializeComponent();
            TestingSomething();
        }

        private void TestingSomething()
        {
            List<Test> testList = new List<Test>();

            for (int i = 0; i < 10; i++)
                testList.Add(new Test());

            this.listView_Main.ItemsSource = testList;
        }


    }

    public class Test
    {
        public Test()
        {
            this.Name = "Helo";
            this.Name2 = "asddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd";
        }
        public string Name { get; set; }
        public string Name2 { get; set; }
    }
}
