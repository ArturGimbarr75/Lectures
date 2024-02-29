-- 1. Select all data from the table “Employee”.
CREATE PROCEDURE spSelectAllEmployees
AS
BEGIN
    SELECT * FROM Employee;
END;