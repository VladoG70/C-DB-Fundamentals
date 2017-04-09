using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Data
    {
    public class Init
        {
        public static void InitDB()
            {
            // Inizializirame/sazdavame bazata
            var context = new PlanetHuntersContext();
            context.Database.Initialize(true);
            Console.WriteLine("DataBase <PlanetHunters> created!");
            }
        }
    }
