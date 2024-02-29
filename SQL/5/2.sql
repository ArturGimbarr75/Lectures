-- 2. Select all data from the column “PersonalCode” in the table “Employee”.
CREATE PROCEDURE spSelectEmployeePersonalCodes
AS
BEGIN
    SELECT PersonalCode FROM Employee;
END;
