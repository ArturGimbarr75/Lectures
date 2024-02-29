-- 10. Insert a new employee into the table “Employee”.
-- Insert with all fields
CREATE PROCEDURE spInsertEmployee
    @PersonalCode CHAR(11),
    @FirstName VARCHAR(255),
    @LastName VARCHAR(255),
    @StartDate DATE,
    @BirthDate DATE,
    @Position VARCHAR(255) = NULL,  -- Nullable parameters for flexible inserts
    @DepartmentName VARCHAR(255) = NULL,
    @ProjectID INTEGER = NULL
AS
BEGIN
    INSERT INTO Employee (PersonalCode, FirstName, LastName, StartDate, BirthDate, Position, DepartmentName, ProjectID)
    VALUES (@PersonalCode, @FirstName, @LastName, @StartDate, @BirthDate, @Position, @DepartmentName, @ProjectID);
END;
