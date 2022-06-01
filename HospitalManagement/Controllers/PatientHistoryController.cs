using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Models;

namespace HospitalManagement.Controllers
{
    class PatientHistoryController : Controller
    {

        private string QueryizeInsert(PatientHistory newHistory, int patientID)
        {
            return $"iNSERT INTO Patient_History (MainDiagnosis, Report, Notes, AttendingDoctor, EntryDate, PatientID) VALUES('{newHistory.MainDiagnosis}', '{newHistory.Report}', '{newHistory.Notes}', '{newHistory.AttendingDoctor}', '{newHistory.EntryDate}', {patientID});";
        }

        public List<PatientHistory> GetAllPatientHistory(int patientID)
        {
            string history_get_query = $"SELECT * FROM Patient_History WHERE PatientID = {patientID}";

            dynamic _dataReader = dbInstance.RunReceiveQuery(history_get_query, 1);
            List<PatientHistory> _historyList = new List<PatientHistory>();

            while (_dataReader.Read())
            {
                Diagnosis diagnosis;
                Enum.TryParse<Diagnosis>(_dataReader["MainDiagnosis"].ToString(), out diagnosis);
                _historyList.Add(new PatientHistory(Convert.ToInt32(_dataReader["EntryNo"].ToString()), diagnosis, _dataReader["Report"].ToString(), _dataReader["Notes"].ToString(), _dataReader["AttendingDoctor"].ToString(), Convert.ToDateTime(_dataReader["EntryDate"].ToString()), Convert.ToInt32(_dataReader["PatientID"].ToString())));
            }

            return _historyList;
        }

        public bool InsertPatientHistory(PatientHistory newHistory, int patientID)
        {
            dbInstance.RunInsertionQuery(QueryizeInsert(newHistory, patientID));
            return true;
        }
    }
}
