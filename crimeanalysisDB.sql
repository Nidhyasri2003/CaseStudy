CREATE DATABASE CrimeAnalysisDB;
GO

USE CrimeAnalysisDB;
GO

-- Victims table
CREATE TABLE Victims (
    VictimID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Address NVARCHAR(100),
    PhoneNumber NVARCHAR(20)
);

-- Suspects table
CREATE TABLE Suspects (
    SuspectID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    Address NVARCHAR(100),
    PhoneNumber NVARCHAR(20)
);

-- Law Enforcement Agencies table
CREATE TABLE LawEnforcementAgencies (
    AgencyID INT PRIMARY KEY IDENTITY(1,1),
    AgencyName NVARCHAR(100) NOT NULL,
    Jurisdiction NVARCHAR(100) NOT NULL,
    Address NVARCHAR(100),
    PhoneNumber NVARCHAR(20)
);

-- Officers table
CREATE TABLE Officers (
    OfficerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    BadgeNumber NVARCHAR(20) NOT NULL UNIQUE,
    Rank NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20),
    AgencyID INT FOREIGN KEY REFERENCES LawEnforcementAgencies(AgencyID)
);

-- Incidents table
CREATE TABLE Incidents (
    IncidentID INT PRIMARY KEY IDENTITY(1,1),
    IncidentType NVARCHAR(50) NOT NULL,
    IncidentDate DATETIME NOT NULL,
    Location NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Status NVARCHAR(50) NOT NULL,
    VictimID INT FOREIGN KEY REFERENCES Victims(VictimID),
    SuspectID INT FOREIGN KEY REFERENCES Suspects(SuspectID),
    AgencyID INT FOREIGN KEY REFERENCES LawEnforcementAgencies(AgencyID)
);

-- Evidence table
CREATE TABLE Evidence (
    EvidenceID INT PRIMARY KEY IDENTITY(1,1),
    Description NVARCHAR(MAX) NOT NULL,
    LocationFound NVARCHAR(100) NOT NULL,
    IncidentID INT FOREIGN KEY REFERENCES Incidents(IncidentID)
);

-- Reports table
CREATE TABLE Reports (
    ReportID INT PRIMARY KEY IDENTITY(1,1),
    IncidentID INT FOREIGN KEY REFERENCES Incidents(IncidentID),
    ReportingOfficer INT FOREIGN KEY REFERENCES Officers(OfficerID),
    ReportDate DATETIME NOT NULL,
    ReportDetails NVARCHAR(MAX) NOT NULL,
    Status NVARCHAR(50) NOT NULL
);

-- Cases table
CREATE TABLE Cases (
    CaseID INT PRIMARY KEY IDENTITY(1,1),
    CaseDescription NVARCHAR(MAX) NOT NULL,
    IncidentIDs NVARCHAR(MAX) NOT NULL, -- Will store comma-separated incident IDs
    Status NVARCHAR(50) NOT NULL,
    CreatedDate DATETIME NOT NULL
);

-- Insert sample Law Enforcement Agencies
INSERT INTO LawEnforcementAgencies (AgencyName, Jurisdiction, Address, PhoneNumber)
VALUES 
('Mumbai Police', 'Mumbai', 'Police Headquarters, D.N. Road, Mumbai', '022-22621817'),
('Delhi Police', 'Delhi', 'Police Headquarters, ITO, Delhi', '011-23233333'),
('Bangalore City Police', 'Bangalore', 'Police Commissioner Office, Infantry Road, Bangalore', '080-22212221'),
('Hyderabad Police', 'Hyderabad', 'Police Headquarters, Basheerbagh, Hyderabad', '040-27852020'),
('Chennai Police', 'Chennai', 'Commissioner Office, Egmore, Chennai', '044-28447777'),
('Kolkata Police', 'Kolkata', 'Lalbazar Police Headquarters, Kolkata', '033-22143000'),
('Ahmedabad Police', 'Ahmedabad', 'Police Commissioner Office, Shahibaug, Ahmedabad', '079-25651100'),
('Pune Police', 'Pune', 'Commissioner Office, Camp, Pune', '020-26123333'),
('Jaipur Police', 'Jaipur', 'Police Headquarters, Jaipur', '0141-2741000'),
('Lucknow Police', 'Lucknow', 'Police Headquarters, Hazratganj, Lucknow', '0522-2239200');

-- Insert sample Officers
INSERT INTO Officers (FirstName, LastName, BadgeNumber, Rank, PhoneNumber, AgencyID)
VALUES
('Rajesh', 'Kumar', 'MH101', 'Inspector', '9876543210', 1),
('Priya', 'Sharma', 'MH102', 'Sub-Inspector', '9876543211', 1),
('Amit', 'Patel', 'DL201', 'Inspector', '9876543220', 2),
('Neha', 'Gupta', 'DL202', 'Constable', '9876543221', 2),
('Vikram', 'Singh', 'KA301', 'Inspector', '9876543230', 3),
('Ananya', 'Reddy', 'KA302', 'Sub-Inspector', '9876543231', 3),
('Arjun', 'Mehta', 'TS401', 'Inspector', '9876543240', 4),
('Divya', 'Iyer', 'TS402', 'Constable', '9876543241', 4),
('Sanjay', 'Verma', 'TN501', 'Inspector', '9876543250', 5),
('Meera', 'Joshi', 'TN502', 'Sub-Inspector', '9876543251', 5);

-- Insert sample Victims
INSERT INTO Victims (FirstName, LastName, DateOfBirth, Gender, Address, PhoneNumber)
VALUES
('Arjun', 'Mehta', '1985-05-15', 'Male', '12 Marine Drive, Mumbai', '9876540001'),
('Priyanka', 'Choudhary', '1990-08-22', 'Female', '45 Connaught Place, Delhi', '9876540002'),
('Rahul', 'Sharma', '1978-11-30', 'Male', '78 MG Road, Bangalore', '9876540003'),
('Sunita', 'Patel', '1982-03-10', 'Female', '34 Charminar Road, Hyderabad', '9876540004'),
('Vijay', 'Malhotra', '1975-07-18', 'Male', '56 Marina Beach Road, Chennai', '9876540005'),
('Anjali', 'Kapoor', '1988-09-25', 'Female', '23 Park Street, Kolkata', '9876540006'),
('Sanjay', 'Verma', '1992-01-05', 'Male', '67 Law Garden Road, Ahmedabad', '9876540007'),
('Meera', 'Joshi', '1980-12-12', 'Female', '89 FC Road, Pune', '9876540008'),
('Kiran', 'Nair', '1972-04-20', 'Male', '32 Hawa Mahal Road, Jaipur', '9876540009'),
('Divya', 'Iyer', '1995-06-08', 'Female', '11 Hazratganj, Lucknow', '9876540010');

-- Insert sample Suspects
INSERT INTO Suspects (FirstName, LastName, DateOfBirth, Gender, Address, PhoneNumber)
VALUES
('Ramesh', 'Yadav', '1980-02-14', 'Male', 'Unknown, Mumbai', '9876550001'),
('Suresh', 'Khan', '1975-09-18', 'Male', 'Unknown, Delhi', '9876550002'),
('Deepak', 'Reddy', '1982-07-22', 'Male', 'Unknown, Bangalore', '9876550003'),
('Pooja', 'Shah', '1988-04-30', 'Female', 'Unknown, Hyderabad', '9876550004'),
('Manoj', 'Bose', '1978-11-05', 'Male', 'Unknown, Chennai', '9876550005'),
('Anita', 'Das', '1985-01-25', 'Female', 'Unknown, Kolkata', '9876550006'),
('Vishal', 'Malik', '1990-03-15', 'Male', 'Unknown, Ahmedabad', '9876550007'),
('Geeta', 'Naik', '1983-08-08', 'Female', 'Unknown, Pune', '9876550008'),
('Alok', 'Menon', '1976-12-12', 'Male', 'Unknown, Jaipur', '9876550009'),
('Rashmi', 'Pillai', '1987-05-20', 'Female', 'Unknown, Lucknow', '9876550010');

-- Insert sample Incidents
INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID, AgencyID)
VALUES
('Robbery', '2023-01-15 14:30:00', 'Juhu Beach, Mumbai', 'Chain snatching incident', 'Open', 1, 1, 1),
('Burglary', '2023-02-20 22:45:00', 'GK-1, Delhi', 'House break-in and theft', 'Under Investigation', 2, 2, 2),
('Fraud', '2023-03-10 11:20:00', 'Electronic City, Bangalore', 'Online banking fraud', 'Closed', 3, 3, 3),
('Assault', '2023-04-05 19:15:00', 'Charminar, Hyderabad', 'Physical assault case', 'Open', 4, 4, 4),
('Theft', '2023-05-12 09:30:00', 'T Nagar, Chennai', 'Mobile phone theft', 'Under Investigation', 5, 5, 5),
('Cyber Crime', '2023-06-18 16:45:00', 'Salt Lake, Kolkata', 'Social media hacking', 'Open', 6, 6, 6),
('Vandalism', '2023-07-22 23:10:00', 'Sabarmati Riverfront, Ahmedabad', 'Public property damage', 'Closed', 7, 7, 7),
('Harassment', '2023-08-30 18:20:00', 'Koregaon Park, Pune', 'Workplace harassment', 'Under Investigation', 8, 8, 8),
('Kidnapping', '2023-09-14 07:45:00', 'Amer Road, Jaipur', 'Child kidnapping attempt', 'Open', 9, 9, 9),
('Drug Offense', '2023-10-25 03:30:00', 'Gomti Nagar, Lucknow', 'Drug possession case', 'Closed', 10, 10, 10);

-- Insert sample Evidence
INSERT INTO Evidence (Description, LocationFound, IncidentID)
VALUES
('Gold chain', 'Near Juhu beach sidewalk', 1),
('Crowbar', 'Backyard of GK-1 house', 2),
('Laptop', 'Cyber cafe in Electronic City', 3),
('Blood-stained cloth', 'Charminar alley', 4),
('Stolen mobile', 'Pawn shop in T Nagar', 5),
('Hacking software', 'Salt Lake apartment', 6),
('Spray paint cans', 'Sabarmati Riverfront', 7),
('Threatening letters', 'Koregaon Park office', 8),
('Ransom note', 'Amer Road park', 9),
('Drug packets', 'Gomti Nagar apartment', 10);

-- Insert sample Reports
INSERT INTO Reports (IncidentID, ReportingOfficer, ReportDate, ReportDetails, Status)
VALUES
(1, 1, '2023-01-16', 'Initial report for chain snatching at Juhu Beach', 'Finalized'),
(2, 3, '2023-02-21', 'Preliminary findings for GK-1 burglary', 'Draft'),
(3, 5, '2023-03-11', 'Final report on electronic city fraud case', 'Finalized'),
(4, 7, '2023-04-06', 'Assault case investigation ongoing', 'Draft'),
(5, 9, '2023-05-13', 'Mobile theft report with suspect details', 'Finalized'),
(6, 2, '2023-06-19', 'Cyber crime technical analysis', 'Draft'),
(7, 4, '2023-07-23', 'Vandalism case closed with fines', 'Finalized'),
(8, 6, '2023-08-31', 'Harassment case witness statements', 'Draft'),
(9, 8, '2023-09-15', 'Kidnapping attempt foiled, suspect arrested', 'Finalized'),
(10, 10, '2023-10-26', 'Drug offense complete report', 'Finalized');

-- Insert sample Cases
INSERT INTO Cases (CaseDescription, IncidentIDs, Status, CreatedDate)
VALUES
('Major theft cases in Mumbai', '1,4,7,10', 'Open', '2023-01-20'),
('Delhi property crimes', '2,5,8', 'Under Investigation', '2023-02-25'),
('South India cyber crimes', '3,6,9', 'Closed', '2023-03-15'),
('Violent crimes in North India', '4,7,10', 'Open', '2023-04-10'),
('Financial fraud cases', '1,3,5,9', 'Under Investigation', '2023-05-15'),
('Public property damage cases', '2,7,8', 'Closed', '2023-06-20'),
('Assault and harassment cases', '1,4,8', 'Open', '2023-07-25'),
('Drug related offenses', '5,10', 'Under Investigation', '2023-08-30'),
('Kidnapping attempts', '6,9', 'Closed', '2023-09-05'),
('Cyber crime special cases', '3,6,9', 'Open', '2023-10-10');

select*from cases;
select*from incidents;
select*from reports;
select*from Evidence;
select*from reports;