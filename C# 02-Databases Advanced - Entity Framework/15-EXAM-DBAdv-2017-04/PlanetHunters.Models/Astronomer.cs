using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PlanetHunters.Models
    {
    public class Astronomer
        {
        public Astronomer()
        {
            this.PioneerDiscoveries = new HashSet<Discovery>();
            this.ObservDiscoveries = new HashSet<Discovery>();
        }

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        // Nav PROPs
        public virtual ICollection<Discovery> PioneerDiscoveries { get; set; }
        public virtual ICollection<Discovery> ObservDiscoveries { get; set; }
        }
    }
