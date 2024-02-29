-- 8. Select employee names whose last names are Sabutis.
CREATE PROCEDURE spSelectEmployeeByLastName
    @LastName VARCHAR(255)
AS
BEGIN
    SELECT FirstName, LastName FROM Employee WHERE LastName = @LastName;
END;
