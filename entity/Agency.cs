using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.entity
{
    public class Agency
    {
        public int AgencyID { get; set; }
        public string AgencyName { get; set; }
        public string Jurisdiction { get; set; }
        public string ContactInfo { get; set; }

        public Agency() { }

        public Agency(int agencyID, string agencyName, string jurisdiction, string contact)
        {
            AgencyID = agencyID;
            AgencyName = agencyName;
            Jurisdiction = jurisdiction;
            ContactInfo = contact;
        }
    }
}