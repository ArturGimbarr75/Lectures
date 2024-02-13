-- 1 Select all data from the table “Employee”.
SELECT * FROM Employee

-- 2 Select all data from the column “PersonalCode” in the table “Employee”.
SELECT PersonalCode from Employee

-- 3 Select all data from the columns “FirstName”, “LastName”, “Position” in the table “Employee”.
SELECT FirstName, LastName, Position from Employee

-- 4 Select distinct values from the column DepartmentName in the table “Employee”.
SELECT DISTINCT DepartmentName from Employee

-- 5 Select all data about employees who work in the C# department.​
SELECT * from Employee
WHERE DepartmentName = 'C#'

-- 6 Select data on what position Giedrius holds.​
SELECT Position from Employee
WHERE FirstName = 'Giedrius'

-- 7 Select all data about employees whose birth date is 1986-09-19.​
SELECT * from Employee
WHERE BirthDate = '1986-09-19'

-- 8 Select employee names whose last names are Sabutis.​
SELECT FirstName from Employee
WHERE LastName = 'Sabutis'

-- 9 Select data (first and last names) about developers from the Java department.
SELECT FirstName, LastName from Employee
WHERE DepartmentName = 'Java'

-- 10 Insert a new employee into the table “Employee”, filling in all required fields (personal code, first name, last name, start date, birth date, position, department name, and project number).​
INSERT INTO Employee(PersonalCode, FirstName, LastName, StartDate, BirthDate, Position, DepartmentName, ProjectID)
VALUES ('85054113101', 'Kayla', 'Pitts', '2023-11-19', '1992-03-13', 'Horticulturist, commercial', 'Impact', 5)

-- 11 Insert a new employee into the table “Employee”, only filling in fields (personal code, first name, last name, start date, birth date). Leave position, department name, and project number unfilled.​
INSERT INTO Employee(PersonalCode, FirstName, LastName, StartDate, BirthDate)
VALUES ('85054113302', 'A', 'B', '2023-11-19', '1992-03-13');

-- 12 Fill in the remaining empty fields in the table “Employee” for your previously inserted entry. Assign the employee a position, department, and project.​
UPDATE Employee
SET Position = 'Software Engineer',
    DepartmentName = 'Development',
    ProjectID = 2
WHERE PersonalCode = '85054113302';

-- 13 Delete the table “Employee” record whose personal code is the one you created.​
DELETE from Employee
WHERE PersonalCode IN ('85054113302', '85054113101');

-- 14 Insert two employees with the last name Antanaitis whose position would be “Developer”.​
INSERT INTO Employee(PersonalCode, FirstName, LastName, StartDate, BirthDate, Position, DepartmentName, ProjectID)
VALUES ('85054113102', 'Kayla', 'Antanaitis', '2023-11-19', '1992-03-13', 'Developer', 'Impact', 5),
       ('85054113103', 'Kaylo', 'Antanaitis', '2023-11-19', '1992-03-13', 'Developer', 'Impact', 5)

-- 15 Change the positions of both Antanaitis to “Tester” in one sentence.​
UPDATE Employee
SET Position = 'Tester'
WHERE LastName = 'Antanaitis';

-- 16 Count how many Testers work in the company.
SELECT COUNT(*) from Employee
WHERE Position = 'Tester'