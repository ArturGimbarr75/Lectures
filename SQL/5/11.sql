-- 11. Update to fill the remaining fields for an employee.
CREATE PROCEDURE spUpdateEmployee
    @PersonalCode CHAR(11),
    @Position VARCHAR(255),
    @DepartmentName VARCHAR(255),
    @ProjectID INTEGER
AS
BEGIN
    UPDATE Employee
    SET Position = @Position, DepartmentName = @DepartmentName, ProjectID = @ProjectID
    WHERE PersonalCode = @PersonalCode;
END;
