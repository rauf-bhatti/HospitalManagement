using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    class PatientHistory
    {
        public Diagnosis MainDiagnosis { get; set; }
        public string Report { get; set; }
        public string Notes { get; set; }
        public Doctor AttendingDoctor { get; set; }
        public DateTime EntryTime { get; set; }
    }
}
