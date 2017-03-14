USE MinionsDB

UPDATE Towns
	SET TownName = UPPER(TownName)
WHERE CountryName = @countryName

SELECT
	TownName
	FROM Towns
WHERE CountryName = @countryName