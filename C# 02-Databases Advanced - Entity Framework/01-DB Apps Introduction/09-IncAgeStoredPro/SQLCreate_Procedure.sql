USE MinionsDB

CREATE PROCEDURE usp_GetOlder (
@MinionID INT)
AS
BEGIN
	UPDATE Minions
		SET Age = Age + 1
	WHERE Id = @MinionID
END