using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.entity
{
    public class Case
    {
        public int CaseID { get; set; }
        public string Description { get; set; }
        public List<Incident> Incidents { get; set; }
        public string? Status { get; internal set; }
        public DateTime CreatedDate { get; internal set; }

        public Case()
        {
            Incidents = new List<Incident>();
        }

        public Case(int caseId, string description, List<Incident> incidents)
        {
            CaseID = caseId;
            Description = description;
            Incidents = incidents;
        }
    }
}