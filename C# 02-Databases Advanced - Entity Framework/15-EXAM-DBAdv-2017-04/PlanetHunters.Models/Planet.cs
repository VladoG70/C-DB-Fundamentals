using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
    {
    public class Planet
        {
        private double mass;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Mass
            {
            get
                {
                return mass;
                }
            set
                {
                double checkMass = value;
                if (checkMass > 0.0)
                    {
                    this.mass = value;
                    }
                else
                    {
                    throw new Exception("Invalid Planet Mass!");
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
