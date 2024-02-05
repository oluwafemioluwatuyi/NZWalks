using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)

        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data from Difficulties
            //Easy, Medium, Hard

            var difficulties = new List<Difficulty>([

            new Difficulty()
            {
                Id = Guid.Parse("d1d7b601-bcf3-4102-b063-df8c79529e45"),
                Name = "Easy"

            },

            new Difficulty()
            {
                Id = Guid.Parse("8015b003-21c2-4e7a-a5a1-8941f9db2207"),
                Name = "Medium"

            },

            new Difficulty()
            {
                Id = Guid.Parse("96b40537-98a5-4637-8496-571800a8eb7d"),
                Name = "Hard"

            }

            ]);


            // SEED DIFFICULTIES TO THE DATABASE

            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            // seed data for regions

            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("dc1307ed-e03b-434b-8e6b-b6f3b241bc49"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = ""
                },
                new Region()
                {
                    Id = Guid.Parse("7748f429-6407-4ab1-837f-7c5de0f65e12"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = null
                },

                new Region()

                {
                    Id = Guid.Parse("f689f64e-67c9-491a-b275-ffb126cc92ef"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },

                new Region()
                {
                    Id = Guid.Parse("0c8cb674-f1f9-4f9f-ad1e-c40e7124481e"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = null
                },

                new Region()
                {
                    Id = Guid.Parse("720ae01e-ff1f-4159-a541-554fe89b13c3"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = null
                },

                new Region()
                {
                    Id = Guid.Parse("93e3b356-9b99-40c3-86c5-4252213935fd"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = null
                }

            };

            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
