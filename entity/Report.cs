using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.entity
{
    public class Report
    {
        public int ReportID { get; set; }
        public int IncidentID { get; set; }
        public int ReportingOfficerID { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportDetails { get; set; }
        public string Status { get; set; }

        public Report() { }

        public Report(int reportID, int incidentID, int officerID, DateTime date, string details, string status)
        {
            ReportID = reportID;
            IncidentID = incidentID;
            ReportingOfficerID = officerID;
            ReportDate = date;
            ReportDetails = details;
            Status = status;
        }
    }
}
