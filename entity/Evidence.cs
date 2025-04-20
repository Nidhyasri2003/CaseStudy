using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.entity
{
    public class Evidence
    {
        public int EvidenceID { get; set; }
        public string Description { get; set; }
        public string LocationFound { get; set; }
        public int IncidentID { get; set; }

        public Evidence() { }

        public Evidence(int evidenceID, string desc, string location, int incidentID)
        {
            EvidenceID = evidenceID;
            Description = desc;
            LocationFound = location;
            IncidentID = incidentID;
        }
    }
}