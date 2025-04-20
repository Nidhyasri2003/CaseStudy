using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.entity
{
    public class Suspect
    {
        public int SuspectID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ContactInfo { get; set; }

        public Suspect() { }

        public Suspect(int suspectID, string firstName, string lastName, DateTime dob, string gender, string contact)
        {
            SuspectID = suspectID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dob;
            Gender = gender;
            ContactInfo = contact;
        }
    }
}