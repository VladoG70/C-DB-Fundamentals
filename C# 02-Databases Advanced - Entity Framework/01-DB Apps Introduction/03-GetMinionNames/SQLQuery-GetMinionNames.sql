USE MinionsDB

SELECT 
	m.Id,
	m.Name,
	m.Age
	FROM Minions AS m
JOIN MinionsVillains AS mv
	ON m.Id = mv.MinionID
WHERE mv.VillainID = @villainId