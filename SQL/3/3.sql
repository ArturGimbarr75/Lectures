--1.Select the names of the staff members together with the name of the project they work on.​
SELECT Employee.FirstName, Project.Name
FROM Employee
LEFT JOIN Project
ON Employee.ProjectID = Project.ID

--2.Select the names of the staff working on the project in Kaunas and the name of the project.​
SELECT Employee.FirstName, Project.Name
FROM Employee
LEFT JOIN Project
ON Employee.ProjectID = Project.ID
WHERE Project.Name = 'Kaunas'

--3.Select all the Registry Centre project implementers working in the Testing Department.​
SELECT Employee.*, Project.Name
FROM Employee
JOIN Project
ON Employee.ProjectID = Project.ID
WHERE Project.Name = 'RegistryCenter'

--4.Select all the women working in the Izola project and display their names and the name of the project.​
SELECT Employee.FirstName, Project.Name
FROM Employee
JOIN Project
ON Employee.ProjectID = Project.ID
WHERE Employee.FirstName LIKE '%a' AND Project.Name = 'Izola'

--5.Select the names of the departments with the number of employees working in them.​
SELECT DepartmentName, COUNT(*) AS WorkersCount
FROM Employee
GROUP BY DepartmentName

--6.Restrict the result of query #5 to show only departments with at least 5 employees.​
SELECT DepartmentName, COUNT(*) AS WorkersCount
FROM Employee
GROUP BY DepartmentName
HAVING COUNT(*) >= 5

--7.Please select the names of the staff members, together with the names of the departments in which they work, but who are not the heads of those departments.​
SELECT Employee.FirstName, Employee.DepartmentName
FROM Employee
JOIN Department
ON Employee.DepartmentName = Department.Name
WHERE Employee.PersonalCode != Department.ManagerPersonalCode

SELECT Employee.FirstName AS Head, Employee.DepartmentName
FROM Employee
JOIN Department
ON Employee.DepartmentName = Department.Name
WHERE Employee.PersonalCode = Department.ManagerPersonalCode

--8.Create a new record in the table "EMPLOYEE" (personal code: 38807117896, first name: Pranas, last name:Logis, Employed since: 2009-11-12, year of birth: 1988-11-14, title: null, department_name: null, project_id: null).​
--INSERT INTO Employee(PersonalCode, FirstName, LastName, StartDate, BirthDate)
--VALUES ('38807117896', 'Pranas', 'Logis', '2009-11-12', '1988-11-14')

--9.Select the names of the staff and the name of the department. Show even staff who do not work in any department (take the department name from the DEPARTMENT table).​
SELECT Employee.FirstName, Department.Name
FROM Employee
FULL JOIN Department
ON Employee.DepartmentName = Department.Name

--10.Please modify the query in point 1# to show only names and project names with more than 4 employees.​
SELECT Project.Name, COUNT(*) AS EmployeeCount
FROM Employee
JOIN Project ON Employee.ProjectID = Project.ID
GROUP BY Project.Name

SELECT Project.Name, COUNT(*) AS EmployeeCount
FROM Employee
JOIN Project ON Employee.ProjectID = Project.ID
GROUP BY Project.Name
HAVING COUNT(*) > 4;
