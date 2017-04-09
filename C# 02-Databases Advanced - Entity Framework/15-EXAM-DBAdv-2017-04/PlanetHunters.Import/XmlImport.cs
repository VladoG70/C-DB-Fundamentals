using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PlanetHunters.Data.StoreInDB;

namespace PlanetHunters.Import
    {
    public class XmlImport
        {
        public static void ImporStarsFromXML()
            {
            Console.WriteLine("Reading File <stars.xml> ...");
            XDocument starsDocument = XDocument.Load("../../../datasets/stars.xml");
            XElement starsRoot = starsDocument.Root;

            StoreDatasetsInDB.AddStarsFromXML(starsRoot);
            }

        public static void ImporDiscoveriesFromXML()
            {
            Console.WriteLine("Reading File <discoveries.xml> ...");
            XDocument discoveriesDocument = XDocument.Load("../../../datasets/discoveries.xml");
            XElement discoveriesRoot = discoveriesDocument.Root;

            StoreDatasetsInDB.AddDiscoveriesFromXML(discoveriesRoot);
            }

        }
    }
