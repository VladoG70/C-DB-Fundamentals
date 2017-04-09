using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlanetHunters.Models;

namespace PlanetHunters.Data.ExportFromDB
    {
    public class ExportDataToJSON
        {
        public static void ExportPlanets()
            {
            using (PlanetHuntersContext context = new PlanetHuntersContext())
                {
                Console.WriteLine("Start Exporting Data <Export Planets by Telescope Name> ...");
                var TelescopeName = context.Telescopes.ToList();

                foreach (Telescope telescope in TelescopeName)
                    {
                    var name = telescope.Name;
                    var exportedPlanets = context.Planets
                        .Where(pl => pl.Discovery.Telescope.Name == name)
                        .Select(planet => new
                            {
                            Name = name,
                            Mass = planet.Mass,
                            Orbit = new
                                {
                                planet.StarSystem.Name
                                }
                            });

                    var planetAsJson = JsonConvert.SerializeObject(exportedPlanets, Formatting.Indented);
                    var fileName = "planets-by-telescope-" + name + ".json";
                    Console.WriteLine($"Saving file: <{fileName}> ...");
                    File.WriteAllText($"../../../PlanetHunters.Export/Exports/{fileName}", planetAsJson);
                    Console.WriteLine("Done!");
                    }
                }
            }

        public static void ExportAstronomers()
            {
            using (PlanetHuntersContext context = new PlanetHuntersContext())
                {
                Console.WriteLine("Start Exporting Data <Export Astronomers by Telescope Name> ...");

                }
            Console.WriteLine("Not READY YET! / Done!");
            }

        }
    }
