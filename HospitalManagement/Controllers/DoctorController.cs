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
    class DoctorController : Controller
    {
        private DoctorValidator doctorValidator = new DoctorValidator();
        private readonly string doctor_get_query = "SELECT * FROM Doctor_Table";

        private string QueryizeInsert(Doctor newDoctor)
        {
            return $"INSERT INTO Doctor_Table(FirstName, LastName, Age, Address, Specialization, Salary) VALUES('{newDoctor.FirstName}', '{newDoctor.LastName}', {newDoctor.Age}, '{newDoctor.Address}', '{newDoctor.Specialization}', '{newDoctor.Salary}');";
        }

        private string QueryizeModify(Doctor newDoctor)
        {
            return $"UPDATE Doctor_Table SET FirstName = '{newDoctor.FirstName}', LastName = '{newDoctor.LastName}', Age = {newDoctor.Age}, Address = {newDoctor.Address}, Specialization = {newDoctor.Specialization}, Salary = '{newDoctor.Salary}' WHERE ID_Number = {newDoctor.ID_Number}";
        }

        private string QueryizeDelete(Doctor newDoctor)
        {
            return $"DELETE FROM Doctor_Table WHERE ID_Number = {newDoctor.ID_Number}";
        }

        private Specialization GetSpecializationFromString(string str)
        {
            Specialization docSpecialization = new Specialization();
            Enum.TryParse<Specialization>(str, true, out docSpecialization);
            return docSpecialization;
        }

        public List<Doctor> GetAllDoctors()
        {
            dynamic _dataReader = dbInstance.RunReceiveQuery(doctor_get_query, 1);
            List<Doctor> _doctorList = new List<Doctor>();
            try
            {
                while (_dataReader.Read())
                {
                    _doctorList.Add(new Doctor(Convert.ToInt32(_dataReader["ID_Number"].ToString()), _dataReader["FirstName"].ToString(), _dataReader["LastName"].ToString(), Convert.ToInt32(_dataReader["Age"].ToString()), _dataReader["Address"].ToString(), GetSpecializationFromString(_dataReader["Specialization"].ToString()), Convert.ToInt32(_dataReader["Salary"].ToString())));
                }
                return _doctorList;
            }
            catch(Exception error)
            {
                Console.WriteLine($"[Logging] {error.Message}");
                return null;
            }
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

        public bool ModifyDoctorEntry(Doctor newDoctor)
        {
            if (doctorValidator.ValidateDataLength(newDoctor.FirstName, 3, 25) &&
               doctorValidator.ValidateDataLength(newDoctor.LastName, 3, 25) &&
               doctorValidator.ValidateDataLength(newDoctor.Address, 3, 100) &&
               doctorValidator.ValidateData(newDoctor.FirstName) &&
               doctorValidator.ValidateData(newDoctor.LastName) &&
               newDoctor.Age > 0 && newDoctor.Age < 100 &&
               newDoctor.Salary > 0 && newDoctor.Salary < 500000)
            {
                dbInstance.RunInsertionQuery(QueryizeModify(newDoctor));
                return true;
            }
            return false;
        }

        public bool DeleteDoctorEntry(Doctor newDoctor)
        {
            if (dbInstance.RunDeletionQuery(QueryizeDelete(newDoctor)) > 0)
            {
                return true;
            }

            return false;
        }
    }
}
