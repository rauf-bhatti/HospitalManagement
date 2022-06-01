using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Database;
using HospitalManagement.Utilities;

namespace HospitalManagement.Controllers
{
    public abstract class Controller
    {
        protected HospitalManagement.Database.Database dbInstance = new HospitalManagement.Database.Database();
    }
}
