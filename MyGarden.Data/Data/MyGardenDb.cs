using Microsoft.EntityFrameworkCore;
using MyGarden.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Data.Data
{
    public class MyGardenDb:DbContext
    {
        public MyGardenDb() : base() { }
        public DbSet<Disease>?Diseases { get; set; }
        public DbSet<GardeningZone>? GardeningZones { get; set; }
        public DbSet<GardenStyle>?GardenStyles { get; set; }
        public DbSet<Pest>? Pests { get; set; }
        public DbSet<PestAndPlant>? PestsAndPlants { get; set; }
        public DbSet<Plant>? Plants { get; set; }
        public DbSet<PlantAndDisease>? PlantsAndDiseases { get; set; }
        public DbSet<PlantAndStyle>?PlantsAndStyles { get; set; }
        public DbSet<PlantType>?PlantTypes { get; set; }
        public DbSet<Image>?Images { get; set; }
        public DbSet<User>?Users { get;set; }
        public DbSet<Worker>? Workers { get; set; }
        public DbSet<Plant_Garden>?Plants_Gardens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PestAndPlant>().HasKey(p => new { p.PestId, p.PlantId });
            modelBuilder.Entity<PlantAndDisease>().HasKey(p => new { p.PlantId, p.DiseaseId });
            modelBuilder.Entity<PlantAndStyle>().HasKey(p => new { p.PlantId, p.StyleId });
            modelBuilder.Entity<Plant_Garden>().HasKey(p =>new {p.PlantId, p.UsersGardenId});

            base.OnModelCreating(modelBuilder); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RCLPPIT\SQLEXPRESS;Initial Catalog=MyGardenDb;Integrated Security=True; TrustServerCertificate=True");
        }
    }
}
