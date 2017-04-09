using PlanetHunters.Models;

namespace PlanetHunters.Data
    {
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PlanetHuntersContext : DbContext
        {
        public PlanetHuntersContext() : base("name=PlanetHuntersContext")
            {
            //Database.SetInitializer(new DropCreateDatabaseAlways<PlanetHuntersContext>());
            }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Stars-StarSystem-Planets
            modelBuilder.Entity<Star>()
                .HasRequired<StarSystem>(s => s.StarSystem)
                .WithMany(ss => ss.Stars);

            modelBuilder.Entity<Planet>()
                .HasRequired<StarSystem>(p => p.StarSystem)
                .WithMany(ss => ss.Planets);

            // Stars-Discoveries-Planets
            modelBuilder.Entity<Star>()
                .HasOptional<Discovery>(s => s.Discovery) // Moje da bade NULL !!!!!!!!
                .WithMany(d => d.Stars);

            modelBuilder.Entity<Planet>()
                .HasOptional<Discovery>(p => p.Discovery) // Moje da bade NULL !!!!!!!!
                .WithMany(d => d.Planets);

            // Telescope-Discovery
            modelBuilder.Entity<Discovery>()
                .HasRequired<Telescope>(d => d.Telescope)
                .WithMany(t => t.Discoveries);

            // Observers Astronomers-Discoveries
            modelBuilder.Entity<Astronomer>()
                .HasMany<Discovery>(a => a.ObservDiscoveries)
                .WithMany(d => d.Observers)
                .Map(obs =>
                {
                    obs.ToTable("ObserversAstrDisc");
                    obs.MapLeftKey("ObserverAstrId");
                    obs.MapRightKey("ObsDiscoveryId");
                });

            // Pioneers Astronomers-Discoveries
            modelBuilder.Entity<Astronomer>()
                .HasMany<Discovery>(a => a.PioneerDiscoveries)
                .WithMany(d => d.Pioneers)
                .Map(pion =>
                {
                    pion.ToTable("PioneersAstrDisc");
                    pion.MapLeftKey("PioneerAstrId");
                    pion.MapRightKey("PioDiscoveryId");
                });


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }
        public virtual DbSet<Discovery> Discoveries { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Star> Stars { get; set; }
        public virtual DbSet<StarSystem> StarSystems { get; set; }
        public virtual DbSet<Telescope> Telescopes { get; set; }
        }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    }