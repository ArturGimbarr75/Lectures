-- 6. Select data on what position Giedrius holds.
CREATE PROCEDURE spSelectPositionByName
    @FirstName VARCHAR(255)
AS
BEGIN
    SELECT Position FROM Employee WHERE FirstName = @FirstName;
END;
