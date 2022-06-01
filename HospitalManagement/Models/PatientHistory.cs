using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Models
{
    public class PatientHistory
    {
        public int EntryNo { get; set; }
        public int PatientID { get; set; }
        public Diagnosis MainDiagnosis { get; set; }
        public string Report { get; set; }
        public string Notes { get; set; }
        public string AttendingDoctor { get; set; }
        public DateTime EntryDate { get; set; }

        public PatientHistory(int EntryNo, Diagnosis MainDiagnosis, string Report, string Notes, string AttendingDoctor, DateTime EntryDate, int PatientID)
        {
            this.EntryNo = EntryNo;
            this.MainDiagnosis = MainDiagnosis;
            this.Report = Report;
            this.Notes = Notes;
            this.AttendingDoctor = AttendingDoctor;
            this.EntryDate = EntryDate;
            this.PatientID = PatientID;
        }
    }
}
