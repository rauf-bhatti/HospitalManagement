using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;
using HospitalManagement.Database;
using HospitalManagement.Utilities;

namespace HospitalManagement.Controllers
{
    class MainController : Controller
    {
        private LoginValidator loginValidator = new LoginValidator();

        private string QueryizeInsert(string username, string password)
        {
            return $"INSERT INTO Admin_Table (username, user_password) VALUES '{username}', '{password}'";
        }

        private string QueryizeGet(string username, string password)
        {
            return $"SELECT * FROM Admin_Table WHERE username = '{username}' AND user_password = '{password}'";
        }

        public bool AddUser(string username, string password)
        {
            if (loginValidator.ValidateDataLength(username, 3, 8) && 
                loginValidator.ValidateDataLength(password, 8, 20) &&
                loginValidator.ValidateData(password))
            {
                //PassQueryToDB(username, password, QueryizeInsert(username, password));
                return true;
            }

            return false;
        }

        public bool ValidateLogin(string username, string password)
        {
            return dbInstance.RunValidationQuery(QueryizeGet(username, password)) != null ? true : false;
        }
    }
}
