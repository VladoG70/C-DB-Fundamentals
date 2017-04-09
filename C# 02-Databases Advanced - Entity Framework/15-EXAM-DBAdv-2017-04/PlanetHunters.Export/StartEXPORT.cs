using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data.ExportFromDB;

namespace PlanetHunters.Export
    {
    class StartEXPORT
        {
        static void Main(string[] args)
            {
            #region EXPORT to JSON
            //ExportDataToJSON.ExportPlanets();
            ExportDataToJSON.ExportAstronomers();

            #endregion

            #region EXPORT to XML
            //ExportDataToXML.ExportStarsXML();

            #endregion
            }
        }
    }
