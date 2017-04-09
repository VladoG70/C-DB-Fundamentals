using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlanetHunters.Data.DTO;
using PlanetHunters.Data.StoreInDB;

namespace PlanetHunters.Import
    {
    public class JsonImport
        {
        public static void ImportAstronomers()
            {
            Console.WriteLine("Reading File <astronomers.json> ...");
            var json = File.ReadAllText("../../../datasets/astronomers.json");
            var astronomersDtos = JsonConvert.DeserializeObject<IEnumerable<AstronomersDto>>(json);

            StoreDatasetsInDB.AddAstronomers(astronomersDtos);
            }


        public static void ImportTelescopes()
            {
            Console.WriteLine("Reading File <telescopes.json> ...");
            var json = File.ReadAllText("../../../datasets/telescopes.json");
            var telescopesDtos = JsonConvert.DeserializeObject<IEnumerable<TelescopesDto>>(json);

            StoreDatasetsInDB.AddTelescopes(telescopesDtos);
            }

        public static void ImportPlanets()
            {
            Console.WriteLine("Reading File <planets.json> ...");
            var json = File.ReadAllText("../../../datasets/planets.json");
            var planetsDtos = JsonConvert.DeserializeObject<IEnumerable<PlanetsDto>>(json);

            StoreDatasetsInDB.AddPlanets(planetsDtos);
            }

        }
    }
