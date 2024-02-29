-- 14. Change the positions of both Antanaitis to “Tester” in one sentence.
CREATE PROCEDURE spUpdatePositionByLastName
    @LastName VARCHAR(255),
    @NewPosition VARCHAR(255)
AS
BEGIN
    UPDATE Employee
    SET Position = @NewPosition
    WHERE LastName = @LastName;
END;
