using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Utilities;
using HospitalManagement.Database;
using HospitalManagement.Models;

namespace HospitalManagement.Controllers
{
    class DoctorController
    {
        private DoctorValidator doctorValidator = new DoctorValidator();
        private HospitalManagement.Database.Database dbInstance = new HospitalManagement.Database.Database();
        private readonly string doctor_get_query = "SELECT * FROM Doctor_Table";

        private string QueryizeInsert(Doctor newDoctor)
        {
            return $"INSERT INTO Doctor_Table(FirstName, LastName, Age, Address, Specialization, Salary) VALUES('{newDoctor.FirstName}', '{newDoctor.LastName}', {newDoctor.Age}, '{newDoctor.Address}', '{newDoctor.Specialization}', '{newDoctor.Salary}');";
        }

        public List<Doctor> GetAllDoctors()
        {
            dynamic _dataReader = dbInstance.RunReceiveQuery(doctor_get_query, 1);
            List<Doctor> _doctorList = new List<Doctor>();

            while (_dataReader.Read())
            {
                Specialization docSpecialization;
                Enum.TryParse<Specialization>(_dataReader["Specialization"].ToString(), out docSpecialization);
                _doctorList.Add(new Doctor(Convert.ToInt32(_dataReader["ID_Number"].ToString()), _dataReader["FirstName"].ToString(), _dataReader["LastName"].ToString(), Convert.ToInt32(_dataReader["Age"].ToString()), _dataReader["Address"].ToString(), docSpecialization, Convert.ToInt32(_dataReader["Salary"].ToString())));
            }

            return _doctorList;
        }

        public bool AddDoctorEntry(Doctor newDoctor)
        {
            if (doctorValidator.ValidateDataLength(newDoctor.FirstName, 3, 25) &&
               doctorValidator.ValidateDataLength(newDoctor.LastName, 3, 25) &&
               doctorValidator.ValidateDataLength(newDoctor.Address, 3, 100) &&
               doctorValidator.ValidateData(newDoctor.FirstName) &&
               doctorValidator.ValidateData(newDoctor.LastName) &&
               newDoctor.Age > 0 && newDoctor.Age < 100 &&
               newDoctor.Salary > 0 && newDoctor.Salary < 500000)
            {
                dbInstance.RunInsertionQuery(QueryizeInsert(newDoctor));
                return true;
            }
            return false;
        }
    }
}
