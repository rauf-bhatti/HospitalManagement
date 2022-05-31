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
        private HospitalManagement.Database.Database database = new HospitalManagement.Database.Database();
        private readonly string doctor_get_query = "SELECT * FROM Doctor_Table";
    }
}
