-- 15. Count how many Testers work in the company.
CREATE PROCEDURE spCountEmployeesByPosition
    @Position VARCHAR(255)
AS
BEGIN
    SELECT COUNT(*) AS TesterCount
    FROM Employee
    WHERE Position = @Position;
END;
