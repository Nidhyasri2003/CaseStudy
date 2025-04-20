using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.entity
{
    public class Officer
    {
        public int OfficerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BadgeNumber { get; set; }
        public string Rank { get; set; }
        public string ContactInfo { get; set; }
        public int AgencyID { get; set; }

        public Officer() { }

        public Officer(int officerID, string firstName, string lastName, string badge, string rank, string contact, int agencyID)
        {
            OfficerID = officerID;
            FirstName = firstName;
            LastName = lastName;
            BadgeNumber = badge;
            Rank = rank;
            ContactInfo = contact;
            AgencyID = agencyID;
        }
    }
}