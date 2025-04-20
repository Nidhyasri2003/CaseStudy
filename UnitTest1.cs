using NUnit.Framework;
using CrimeAnalysisAndReportingSystem.dao;
using CrimeAnalysisAndReportingSystem.entity;
using System;
using System.Collections.Generic;
using dao;
namespace CrimeAnalysisTests
{
    public class Tests
    {
         
        private CrimeAnalysisServiceImpl service;

        [SetUp]
        public void Setup()
        {
            service = new CrimeAnalysisServiceImpl();
        }

        // ? 1. Incident Creation: Does the method insert incident successfully?
        [Test]
        public void CreateIncident_ShouldInsertIncidentCorrectly()
        {
            Incident incident = new Incident
            {
                IncidentType = "Test Robbery",
                IncidentDate = DateTime.Now,
                Location = "Test Location",
                Description = "Test Robbery Description",
                Status = "Open",
                VictimID = 1000,    
                SuspectID = 1    
            };

            bool result = service.CreateIncident(incident);
            Assert.IsTrue(result, "Incident should be created successfully.");
        }

        // ? 2. Incident Creation: Are the attributes stored correctly?
        [Test]
        public void CreateIncident_ShouldStoreCorrectAttributes()
        {
            string expectedType = "Test Theft";
            string expectedDescription = "Test case description";

            Incident incident = new Incident
            {
                IncidentType = expectedType,
                IncidentDate = DateTime.Today,
                Location = "Test Zone",
                Description = expectedDescription,
                Status = "Open",
                VictimID = 1,
                SuspectID = 1
            };

            bool created = service.CreateIncident(incident);
            Assert.IsTrue(created);

            List<Incident> incidents = service.SearchIncidents(expectedType);
            Assert.IsTrue(incidents.Exists(i => i.Description == expectedDescription),
                          "The created incident should exist with the correct description.");
        }

        // ? 3. Incident Status Update: Should update status successfully
        [Test]
        public void UpdateIncidentStatus_ShouldUpdateSuccessfully()
        {
            int incidentId = 1;  
            string newStatus = "Closed";

            bool updated = service.UpdateIncidentStatus(incidentId, newStatus);
            Assert.IsTrue(updated, "Status should be updated.");
        }

        // ? 4. Incident Status Update: Should handle invalid ID gracefully
        [Test]
        public void UpdateIncidentStatus_InvalidId_ShouldReturnFalse()
        {
            int invalidIncidentId = 9999; 
            string status = "Closed";

            bool result = service.UpdateIncidentStatus(invalidIncidentId, status);
            Assert.IsFalse(result, "Should return false for non-existent incident ID.");
        }
    }
}