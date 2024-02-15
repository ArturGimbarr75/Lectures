-- 1 Select data about the employee (personal code, first name, and last name) from the table Employee who were born on July 20, 1988.​
SELECT PersonalCode, FirstName, LastName
FROM Employee
WHERE BirthDate = '1988.07.20'

-- 2 Select all data about employees from the table Employee who were born up to July 29, 1988.​
SELECT *
FROM Employee
WHERE BirthDate < '1988.07.29'

-- 3 Select data about employees (start date and birth year) from the table Employee who were employed from October 30, 2009, to November 11, 2012.​
SELECT StartDate, BirthDate
FROM Employee
WHERE '2012.11.11' > StartDate and StartDate > '2009.10.30'

-- 4 Select data about employees (first name, Department, and Project ID) from the table Employee who work on projects 2 and 3. (Use the IN operator).​
SELECT FirstName, DepartmentName, ProjectID
FROM Employee
WHERE ProjectID IN ( 2, 3 )

-- 5 Select data (first name, last name, and personal code) about all females from the table Employee (using the LIKE operator).​
SELECT FirstName, LastName, PersonalCode
FROM Employee
WHERE FirstName LIKE '%a'

-- 6 Select all data about all employees from the table Employee who were born on the 12th day (using the LIKE operator).​
SELECT *
FROM Employee
WHERE BirthDate LIKE '____-__-12'

-- 7 Select all projects from the table Project where the third letter of the project name is ‘u’.​
SELECT *
FROM Project
WHERE Name LIKE '__u%'

-- 8 Select all employees from the table Employee who have no assigned position.​
SELECT *
FROM Employee
WHERE Position is null

-- 9 Select data about the employee (first name, last name, start date, and position) that meet the conditions: (working from 2011-02-12 and their position is Developers).​
SELECT FirstName, LastName, StartDate, Position
FROM Employee
WHERE StartDate >= '2011-02-12' AND Position = 'Developer'

-- 10 Select data about employees (first name, last name, department name, and project ID) from the table Employee with the condition that they are from the Java department or project 1.​
SELECT FirstName, LastName, DepartmentName, ProjectID FROM Employee
WHERE DepartmentName = 'Java' or ProjectID = 1

-- 11 Select all employee names except those whose names start with the letter ‘S’.​
SELECT FirstName
FROM Employee
WHERE FirstName NOT LIKE 'S%'

-- 12 Select data (first name, start date, and birth year) from the table Employee about all employees except those who were employed from October 30, 2009, to November 11, 2012.​
SELECT FirstName, StartDate, BirthDate
FROM Employee
WHERE StartDate >= '2009-10-30' or StartDate <= '2012-11-11'

-- 13 Select data about employees (first name, last name, and birth year) from the table Employee and sort all data from the oldest person to the youngest.​
SELECT FirstName, LastName, BirthDate
FROM Employee
ORDER BY BirthDate

-- 14 Select data about employees (first name, last name, and birth year) from the table Employee and sort all data from the youngest person to the oldest.​
SELECT FirstName, LastName, BirthDate
FROM Employee
ORDER BY BirthDate DESC

-- 15 Select from the table Employee the project ID which would be the minimum number and the maximum number.​
SELECT MIN(ProjectID) AS Min, MAX(ProjectID) AS Max
FROM Employee

-- 16 Select data about the project and how many people are assigned to it from the table Employee (project number and the number of participants).​
SELECT ProjectID, COUNT(*) AS ParticipantsCount
FROM Employee
GROUP BY ProjectID

-- 17 Select data (project number, position, count) from the table Employee on how many developers are working for each project.​
SELECT ProjectID, Position, COUNT(*) AS DevelopersCount
FROM Employee
GROUP BY ProjectID, Position
ORDER BY ProjectID

SELECT ProjectID, Position, COUNT(*) AS DevelopersCount
FROM Employee
GROUP BY ProjectID, Position
HAVING Position = 'Developer'
ORDER BY ProjectID

-- 18 Amend the query from point #17 to show only those projects where at least 2 employees work.​
SELECT ProjectID, Position, COUNT(*) AS DevelopersCount
FROM Employee
GROUP BY ProjectID, Position
HAVING COUNT(*) >= 2 
ORDER BY ProjectID

SELECT ProjectID, COUNT(*) AS DevelopersCount
FROM Employee
WHERE Position = 'Developer'
GROUP BY ProjectID
HAVING COUNT(*) >= 2
ORDER BY ProjectID;