using CrimeAnalysisAndReportingSystem.entity;
using dao;
using CrimeAnalysisAndReportingSystem.entity;
using System;
using System.Collections.Generic;

namespace main
{
    class MainModule
    {
        static void Main(string[] args)
        {
            CrimeAnalysisServiceImpl service = new CrimeAnalysisServiceImpl();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=====Welcome to Crime Analysis and Reporting System (C.A.R.S.) =====");
                Console.WriteLine("1. Create Incident");
                Console.WriteLine("2. Update Incident Status");
                Console.WriteLine("3. Get Incidents in Date Range");
                Console.WriteLine("4. Search Incidents by Type");
                Console.WriteLine("5. Generate Incident Report");
                Console.WriteLine("6. Create Case and Associate Incidents");
                Console.WriteLine("7. Get Case Details");
                Console.WriteLine("8. Update Case Details");
                Console.WriteLine("9. View All Cases");
                Console.WriteLine("10. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Incident newIncident = new Incident();
                        Console.Write("Incident Type: ");
                        newIncident.IncidentType = Console.ReadLine();
                        Console.Write("Incident Date (yyyy-mm-dd): ");
                        newIncident.IncidentDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Location: ");
                        newIncident.Location = Console.ReadLine();
                        Console.Write("Description: ");
                        newIncident.Description = Console.ReadLine();
                        Console.Write("Status: ");
                        newIncident.Status = Console.ReadLine();
                        Console.Write("Victim ID: ");
                        newIncident.VictimID = int.Parse(Console.ReadLine());
                        Console.Write("Suspect ID: ");
                        newIncident.SuspectID = int.Parse(Console.ReadLine());

                        bool created = service.CreateIncident(newIncident);
                        Console.WriteLine(created ? "Incident created successfully." : "Failed to create incident.");
                        break;

                    case 2:
                        Console.Write("Enter Incident ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new status: ");
                        string newStatus = Console.ReadLine();

                        bool updated = service.UpdateIncidentStatus(updateId, newStatus);
                        Console.WriteLine(updated ? "Status updated successfully." : "Failed to update status.");
                        break;

                    case 3:
                        Console.Write("Start Date (yyyy-mm-dd): ");
                        DateTime start = DateTime.Parse(Console.ReadLine());
                        Console.Write("End Date (yyyy-mm-dd): ");
                        DateTime end = DateTime.Parse(Console.ReadLine());

                        var rangeIncidents = service.GetIncidentsInDateRange(start, end);
                        foreach (var inc in rangeIncidents)
                        {
                            Console.WriteLine($"ID: {inc.IncidentID}, Type: {inc.IncidentType}, Date: {inc.IncidentDate}, Status: {inc.Status}");
                        }
                        break;

                    case 4:
                        Console.Write("Enter incident type to search: ");
                        string searchType = Console.ReadLine();
                        var foundIncidents = service.SearchIncidents(searchType);
                        foreach (var inc in foundIncidents)
                        {
                            Console.WriteLine($"ID: {inc.IncidentID}, Type: {inc.IncidentType}, Date: {inc.IncidentDate}, Status: {inc.Status}");
                        }
                        break;

                    case 5:
                        Console.Write("Enter Incident ID to generate report: ");
                        int reportId = int.Parse(Console.ReadLine());
                        Incident reportIncident = new Incident { IncidentID = reportId, Description = "Sample Description" }; 
                        Report report = service.GenerateIncidentReport(reportIncident);
                        Console.WriteLine($"Report Generated:\nDate: {report.ReportDate}\nDetails: {report.ReportDetails}\nStatus: {report.Status}");
                        break;

                    case 6:
                        Console.Write("Enter case description: ");
                        string desc = Console.ReadLine();

                        Console.Write("Enter created date (yyyy-MM-dd): ");
                        DateTime createdDate;
                        while (!DateTime.TryParse(Console.ReadLine(), out createdDate))
                        {
                            Console.Write("Invalid date format. Please enter again (yyyy-MM-dd): ");
                        }

                        Console.Write("Enter case status: ");
                        string status = Console.ReadLine();

                        Console.Write("How many incidents to associate? ");
                        int count = int.Parse(Console.ReadLine());

                        List<Incident> incidents = new List<Incident>();
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write("Enter Incident ID: ");
                            int iid = int.Parse(Console.ReadLine());
                            incidents.Add(new Incident { IncidentID = iid });
                        }

                        bool caseCreated = service.CreateCase(desc, createdDate, status, incidents);
                        Console.WriteLine(caseCreated ? "Case created." : "Failed to create case.");
                        break;




                    case 7:
                        Console.Write("Enter Case ID: ");
                        int caseId = int.Parse(Console.ReadLine());

                        try
                        {
                            Case caseDetails = service.GetCaseDetails(caseId);

                            if (caseDetails != null)
                            {
                                Console.WriteLine($"Case ID: {caseDetails.CaseID}, Description: {caseDetails.Description}, Status: {caseDetails.Status}");
                                Console.WriteLine("Associated Incidents:");

                                if (caseDetails.Incidents != null && caseDetails.Incidents.Count > 0)
                                {
                                    foreach (var inc in caseDetails.Incidents)
                                    {
                                        Console.WriteLine($"Incident ID: {inc.IncidentID}, Type: {inc.IncidentType}, Status: {inc.Status}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No incidents associated with this case.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No case found with the provided Case ID.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error retrieving case details: {ex.Message}");
                        }
                        break;


                    case 8:
                        Console.Write("Enter Case ID to update: ");
                        int cid = int.Parse(Console.ReadLine());
                        Console.Write("Enter new description: ");
                        string newDesc = Console.ReadLine();
                        Case updateCase = new Case { CaseID = cid, Description = newDesc };
                        bool updatedCase = service.UpdateCaseDetails(updateCase);
                        Console.WriteLine(updatedCase ? "Case updated." : "Failed to update case.");
                        break;

                    case 9:
                        var allCases = service.GetAllCases();
                        foreach (var c in allCases)
                        {
                            Console.WriteLine($"Case ID: {c.CaseID}, Description: {c.Description}");
                        }
                        break;

                    case 10:
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }

            Console.WriteLine("Thank you for using the C.A.R.S. system!");
        }
    }
}