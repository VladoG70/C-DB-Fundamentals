using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetHunters.Models
    {
    public class Telescope
        {
        public Telescope()
        {
            this.Discoveries = new HashSet<Discovery>();
        }

        private double mirorDiameter;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public double MirrorDiameter
            {
            get
            {
                return mirorDiameter;
            }
            set
                {
                double checkDiam = value;
                if (checkDiam > 0.0)
                    {
                    this.mirorDiameter = value;
                    }
                else
                    {
                    throw new Exception("Invalid Miror Diameter!");
                    }
                }
            }

        // Nav PROPs
        public virtual ICollection<Discovery> Discoveries { get; set; }
        }
    }
