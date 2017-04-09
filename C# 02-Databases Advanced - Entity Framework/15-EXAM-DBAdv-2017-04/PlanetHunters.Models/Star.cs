using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
    {
    public class Star
        {
        private int temperature;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Temperature
            {
            get
                {
                return temperature;
                }
            set
                {
                int checkTemp = value;
                if (checkTemp >= 2400)
                    {
                    this.temperature = value;
                    }
                else
                    {
                    throw new Exception("Invalid Temperature (lower than 2400K)!");
                    }
                }
            }

        // Nav PROPs
        public int StarSystemId { get; set; }
        public virtual StarSystem StarSystem { get; set; }

        public int? DiscoveryId { get; set; }
        public virtual Discovery Discovery { get; set; }



        }
    }
