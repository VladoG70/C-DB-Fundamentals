--USE MinionsDB

SELECT 
	v.Name,
	COUNT(mv.VillainID) AS MinionsCount
	FROM Villains AS v
JOIN MinionsVillains AS mv
	ON v.Id = mv.VillainID
GROUP BY v.Name
HAVING COUNT(mv.VillainID) > 3
ORDER BY MinionsCount DESC