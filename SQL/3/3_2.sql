--11. Select all developers working on the Accounting project​
SELECT Executors.LastName, Executors.Qualification, Execution.Status
FROM Execution
JOIN Projects ON Execution.Project = Projects.ID
JOIN Executors ON Execution.Executor = Executors.ID
WHERE Projects.Name = 'Accounting' AND Execution.Status = 'Developer'

--12. Please select the projects that have promoters without a degree​
SELECT DISTINCT Projects.*
FROM Projects
JOIN Execution ON Projects.ID = Execution.Project
JOIN Executors ON Execution.Executor = Executors.ID
WHERE Executors.Education IS NULL

--13. List the names and qualifications of the people working on the Medium Priority Project​
SELECT DISTINCT Executors.LastName, Executors.Qualification
FROM Projects
JOIN Execution ON Projects.ID = Execution.Project
JOIN Executors ON Execution.Executor = Executors.ID
WHERE Projects.Importance = 'Medium'

--14. Please select the names of the promoters working on projects prior to 01.05.2005​
SELECT DISTINCT Executors.LastName, Executors.Qualification
FROM Projects
JOIN Execution ON Projects.ID = Execution.Project
JOIN Executors ON Execution.Executor = Executors.ID
WHERE Projects.Start < '2005-05-01'

--15. Please select the projects that have VU-educated implementers
SELECT DISTINCT Projects.*
FROM Projects
JOIN Execution ON Projects.ID = Execution.Project
JOIN Executors ON Execution.Executor = Executors.ID
WHERE Executors.Education = 'VU'