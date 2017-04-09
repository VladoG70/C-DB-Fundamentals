using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetHunters.Data;

namespace PlanetHunters.App
    {
    class StartUp
        {
        static void Main(string[] args)
            {
            // INIT & Create DB
            Console.WriteLine("Creating & Initializing DATABASE <PlanetHunters> ...");
            Init.InitDB();

            }
        }
    }
