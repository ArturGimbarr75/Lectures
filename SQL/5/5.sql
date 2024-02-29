-- 5. Select all data about employees who work in the C# department.
CREATE PROCEDURE spSelectEmployeesByDepartment
    @DepartmentName VARCHAR(255)
AS
BEGIN
    SELECT * FROM Employee WHERE DepartmentName = @DepartmentName;
END;
