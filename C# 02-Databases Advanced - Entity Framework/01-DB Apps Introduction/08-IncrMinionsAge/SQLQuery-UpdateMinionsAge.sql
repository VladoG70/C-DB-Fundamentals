USE MinionsDB

UPDATE Minions
	SET Age = Age + 1
WHERE Id = @minionsID