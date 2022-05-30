using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Database;
using HospitalManagement.Utilities;
using System.Data;

namespace HospitalManagement.Controllers
{
    class PatientController
    {
        private PatientValidator patientValidator = new PatientValidator();
        private HospitalManagement.Database.Database dbInstance = new HospitalManagement.Database.Database();
        private readonly string patient_get_query = "SELECT * FROM Patient";

        private string QueryizeInsert(Patient newPatient)
        {
            return $"INSERT INTO Patient(FirstName, LastName, Age, Address) VALUES('{newPatient.FirstName}', '{newPatient.LastName}', {newPatient.Age}, '{newPatient.Address}');";

        }


        public List<Patient> GetAllPatients()
        {
            dynamic _dataReader = dbInstance.RunReceiveQuery(patient_get_query, 1);
            List<Patient> _patientList = new List<Patient>();
            
            while (_dataReader.Read())
            {
                _patientList.Add(new Patient(Convert.ToInt32(_dataReader["ID_Number"].ToString()), _dataReader["FirstName"].ToString(), _dataReader["LastName"].ToString(), Convert.ToInt32(_dataReader["Age"].ToString()), _dataReader["Address"].ToString()));
            }

            return _patientList;
        }


        public bool AddPatientEntry(Patient newPatient)
        {
            if (patientValidator.ValidateDataLength(newPatient.FirstName, 3, 25) &&
                patientValidator.ValidateDataLength(newPatient.LastName, 3, 25) &&
                patientValidator.ValidateDataLength(newPatient.Address, 3, 25) &&
                patientValidator.ValidateData(newPatient.FirstName) &&
                patientValidator.ValidateData(newPatient.LastName) &&
                newPatient.Age > 0 && newPatient.Age < 100)
            {
                dbInstance.RunInsertionQuery(QueryizeInsert(newPatient));
                return true;
            }

            return false;
        }
    }
}
