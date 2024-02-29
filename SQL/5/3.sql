-- 3. Select all data from the columns “FirstName”, “LastName”, “Position” in the table “Employee”.
CREATE PROCEDURE spSelectEmployeeNamesAndPosition
AS
BEGIN
    SELECT FirstName, LastName, Position FROM Employee;
END;