-- 7. Select all data about employees whose birth date is 1986-09-19.
CREATE PROCEDURE spSelectEmployeesByBirthDate
    @BirthDate DATE
AS
BEGIN
    SELECT * FROM Employee WHERE BirthDate = @BirthDate;
END;
