using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Database;

namespace HospitalManagement.Controllers
{
    class PatientController
    {   
        private string QuerizePatientEntry(Patient newPatient)
        {
            string returnQuery = "INSERT INTO Patients_Table (FirstName, LastName, Age, Address) VALUES (";

            return returnQuery;
        }

        public void AddPatientEntry(Patient newPatient)
        {

        }
    }
}
