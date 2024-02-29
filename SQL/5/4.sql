-- 4. Select distinct values from the column DepartmentName in the table “Employee”.
CREATE PROCEDURE spSelectDistinctDepartmentNames
AS
BEGIN
    SELECT DISTINCT DepartmentName FROM Employee;
END;
