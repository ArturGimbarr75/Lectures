-- 12. Delete an employee record.
CREATE PROCEDURE spDeleteEmployee
    @PersonalCode CHAR(11)
AS
BEGIN
    DELETE FROM Employee WHERE PersonalCode = @PersonalCode;
END;