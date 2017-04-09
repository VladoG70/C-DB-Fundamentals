using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PlanetHunters.Data.ExportFromDB;

namespace PlanetHunters.Data.ExportFromDB
    {
    public class ExportDataToXML
        {
        public static void ExportStarsXML()
            {
            using (PlanetHuntersContext context = new PlanetHuntersContext())
                {
                Console.WriteLine("Start Exporting Data <Export Stars> ...");
                var starsQ = context.Stars
                    .OrderBy(s => s.Id)
                    .Select(star => new
                        {
                        Name = ""
                        });

                XDocument starsDocument = new XDocument();
                XElement starsXml = new XElement("Stars");

                foreach (var starXML in starsQ)
                    {
                    XElement starElement = new XElement("Star", starXML.Name);
                    
                  
                    //foreach (Person victim in exportedAnomly.victims)
                    //    {
                    //    XElement victimElement = new XElement("victim");
                    //    victimElement.SetAttributeValue("name", victim.Name);

                    //    anomalyVictimsElement.Add(victimElement);
                    //    }
                    //anomalyElement.Add(anomalyVictimsElement);
                    //anomaliesXml.Add(anomalyElement);
                    }

                starsDocument.Add(starsXml);
                Console.WriteLine("Saving file: <anomalies.xml> ...");
                starsDocument.Save("../../../PlanetHunters.Export/Exports/stars.xml");
                Console.WriteLine("Done!");
                }
            }
        }
    }
