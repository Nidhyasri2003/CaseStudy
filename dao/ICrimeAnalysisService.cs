using CrimeAnalysisAndReportingSystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeAnalysisAndReportingSystem.dao
{
    public interface ICrimeAnalysisService
    {
        bool CreateIncident(Incident incident);
        bool UpdateIncidentStatus(int incidentId, string newStatus);
        List<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
        List<Incident> SearchIncidents(string incidentType);
        Report GenerateIncidentReport(Incident incident);
        bool CreateCase(string desc, DateTime createdDate, string status, List<Incident> incidents);

        Case GetCaseDetails(int caseId);
        bool UpdateCaseDetails(Case caseDetails);
        List<Case> GetAllCases();
    }
}