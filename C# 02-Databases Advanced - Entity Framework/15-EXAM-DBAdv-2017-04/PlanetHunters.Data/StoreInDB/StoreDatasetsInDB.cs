using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PlanetHunters.Data.DTO;
using PlanetHunters.Models;

namespace PlanetHunters.Data.StoreInDB
    {
    public class StoreDatasetsInDB
        {

        #region ADD data from JSON
        public static void AddAstronomers(IEnumerable<AstronomersDto> astronomersDtos)
            {
            Console.WriteLine("Storing <Astronomers> data in DB ...");
            using (PlanetHuntersContext context = new PlanetHuntersContext())
                {
                foreach (AstronomersDto astronomerDto in astronomersDtos)
                    {
                    if (astronomerDto.FirstName == null || astronomerDto.LastName == null)
                        {
                        Console.WriteLine("ERROR: Invalid data format.");
                        }
                    else
                        {
                        Astronomer astronomer = new Astronomer()
                            {
                            FirstName = astronomerDto.FirstName,
                            LastName = astronomerDto.LastName
                            };

                        context.Astronomers.Add(astronomer);
                        Console.WriteLine($"Record {astronomer.FirstName} {astronomer.LastName} successfully imported.");
                        }
                    }

                context.SaveChanges();
                }
            Console.WriteLine("<Astronomers> table stored!");
            }

        public static void AddTelescopes(IEnumerable<TelescopesDto> telescopesDtos)
            {
            Console.WriteLine("Storing <Telescopes> data in DB ...");
            using (PlanetHuntersContext context = new PlanetHuntersContext())
                {
                foreach (TelescopesDto telescopeDto in telescopesDtos)
                    {
                    double telescopeMirrorDiamDouble = telescopeDto.MirrorDiameter == null
                        ? 0
                        : telescopeDto.MirrorDiameter.Value;

                    if (telescopeDto.Name == null || telescopeDto.Location == null || !(telescopeMirrorDiamDouble > 0.0))
                        {
                        Console.WriteLine("ERROR: Invalid data format.");
                        }
                    else
                        {
                        Telescope telescope = new Telescope()
                            {
                            Name = telescopeDto.Name,
                            Location = telescopeDto.Location,
                            MirrorDiameter = telescopeMirrorDiamDouble
                            };

                        context.Telescopes.Add(telescope);
                        Console.WriteLine($"Record {telescope.Name} successfully imported.");
                        }
                    }

                context.SaveChanges();
                }
            Console.WriteLine("<Telescopes> table stored!");
            }

        public static void AddPlanets(IEnumerable<PlanetsDto> planetsDtos)
            {
            Console.WriteLine("Storing <Planets> data in DB ...");
            // Add StarSystems
            using (PlanetHuntersContext context = new PlanetHuntersContext())
                {
                foreach (PlanetsDto planetDto in planetsDtos)
                    {
                    if (planetDto.Name == null || planetDto.StarSystem == null || !(planetDto.Mass > 0.0))
                        {
                        Console.WriteLine("ERROR: Invalid data format.");
                        }
                    else
                        {
                        //Console.WriteLine($"StarSystem from FILE: {planetDto.StarSystem} READED.");

                        StarSystem starSystem = context.StarSystems
                            .Where(ss => ss.Name == planetDto.StarSystem)
                            .FirstOrDefault();
                        //Console.WriteLine($"CHECK StSys NAME from DB {starSystem.Name} -------------------");

                        if (starSystem == null)
                            {
                            context.StarSystems.Add(new StarSystem() { Name = planetDto.StarSystem });
                            context.SaveChanges();
                            //Console.WriteLine($"StarSystem {planetDto.StarSystem} NOT in DB -> successfully ADDED.");
                            }
                        //else
                        //    {
                        //    Console.WriteLine($"StarSystem {planetDto.StarSystem} ALREADY in DB -> {starSystem.Id}");
                        //    }

                        // ADD Planet
                        starSystem = context.StarSystems
                            .Where(ss => ss.Name == planetDto.StarSystem)
                            .FirstOrDefault();

                        Planet planet = new Planet()
                            {
                            Name = planetDto.Name,
                            Mass = planetDto.Mass,
                            StarSystemId = starSystem.Id
                            };

                        context.Planets.Add(planet);
                        context.SaveChanges();
                        Console.WriteLine($"Record {planet.Name} successfully imported.");
                        }
                    }
                }
            Console.WriteLine("<Planets> table stored!");
            }
        #endregion


        #region ADD data from XML
        public static void AddStarsFromXML(XElement starsRoot)
            {
            Console.WriteLine("Storing New <Stars> data in DB ...");

            using (PlanetHuntersContext context = new PlanetHuntersContext())
                {
                foreach (XElement starElement in starsRoot.Elements())
                    {
                    StarsDto starDto = new StarsDto()
                        {
                        Name = starElement.Element("Name").Value,
                        Temperature = int.Parse(starElement.Element("Temperature").Value),
                        StarSystem = starElement.Element("StarSystem").Value
                        };
                    if (starDto.Name == null || starDto.StarSystem == null || !(starDto.Temperature >= 2400))
                        {
                        Console.WriteLine("ERROR: Invalid data format.");
                        }
                    else
                        {
                        StarSystem starSystem = context.StarSystems
                            .Where(ss => ss.Name == starDto.StarSystem)
                            .FirstOrDefault();

                        if (starSystem == null)
                            {
                            context.StarSystems.Add(new StarSystem() { Name = starDto.Name });
                            context.SaveChanges();
                            }

                        starSystem = context.StarSystems
                            .Where(ss => ss.Name == starDto.StarSystem)
                            .FirstOrDefault();

                        Star star = new Star()
                            {
                            Name = starDto.Name,
                            Temperature = starDto.Temperature,
                            StarSystemId = starSystem.Id
                            };

                        context.Stars.Add(star);
                        Console.WriteLine($"Record {star.Name} successfully imported.");
                        }

                    }

                context.SaveChanges();
                }  // End USING
            Console.WriteLine("<Stars> table stored!");
            }

        public static void AddDiscoveriesFromXML(XElement discoveriesRoot)
            {
            Console.WriteLine("Storing New <Discoveries> data in DB ...");

            using (PlanetHuntersContext context = new PlanetHuntersContext())
                {
                

                //context.SaveChanges();
                }  // End USING
            Console.WriteLine("<Discoveries> table stored!");
            }


        #endregion


        }
    }
