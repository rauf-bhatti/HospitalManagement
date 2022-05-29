using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Database;
using System.Data;


namespace HospitalManagement.Controllers
{
    class PatientController
    {
        private HospitalManagement.Database.Database dbInstance = new HospitalManagement.Database.Database();
        private readonly string patient_get_query = "SELECT * FROM Patient";

        public List<Patient> GetAllPatients()
        {
            dynamic _dataReader = dbInstance.RunQuery(patient_get_query, 1);
            List<Patient> _patientList = new List<Patient>();
            
            while (_dataReader.Read())
            {
                _patientList.Add(new Patient(Convert.ToInt32(_dataReader["ID_Number"].ToString()), _dataReader["FirstName"].ToString(), _dataReader["LastName"].ToString(), Convert.ToInt32(_dataReader["Age"].ToString()), _dataReader["Address"].ToString()));
            }

            return _patientList;
        }

        public void AddPatientEntry(Patient newPatient)
        {

        }
    }
}
