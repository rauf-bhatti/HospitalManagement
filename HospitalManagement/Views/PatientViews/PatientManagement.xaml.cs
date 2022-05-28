﻿using System;
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
        }

        private void Btn_AddPatient_Click(object sender, RoutedEventArgs e)
        {
            PatientEntry PatientEntryForm = new PatientEntry();
            PatientEntryForm.ShowDialog();
        }
    }
}
