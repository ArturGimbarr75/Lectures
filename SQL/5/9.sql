-- 9. Select data (first and last names) about developers from the Java department.
CREATE PROCEDURE spSelectDevelopersFromDepartment
    @DepartmentName VARCHAR(255),
    @Position VARCHAR(255)
AS
BEGIN
    SELECT FirstName, LastName FROM Employee WHERE DepartmentName = @DepartmentName AND Position = @Position;
END;
