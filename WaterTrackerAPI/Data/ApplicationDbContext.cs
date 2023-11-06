using Microsoft.EntityFrameworkCore;
using WaterTrackerAPI.Entities;

namespace WaterTrackerAPI.Data
{
    public class ApplicationDbContext : DbContext //Class for the Database
    {
        //Adds tables to DB
        public DbSet<User> Users { get; set; }
        public DbSet<WaterIntake> WaterIntake { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed database
            //add user records to user table
            modelBuilder.Entity<User>().HasData(
                new User {Id=1, FirstName = "Danny", LastName="Maher", Email="dannymaher@gmail.com"},
                new User { Id = 2, FirstName = "Sarah", LastName = "Jenkins", Email = "sarahjenkins@gmail.com" },
                new User { Id = 3, FirstName = "Mike", LastName = "Smith", Email = "mikesmith@gmail.com" },
                new User { Id = 4, FirstName = "Chloe", LastName = "Lee", Email = "chloelee@gmail.com" }
                );
            //add water intake records to waterintake table
            modelBuilder.Entity<WaterIntake>().HasData(
                new WaterIntake { Id = 1,ConsumedWater = 5431,IntakeDate=new DateTime(2023, 5, 1, 8, 30, 52),UserID=1 },
                new WaterIntake { Id = 2, ConsumedWater = 10456, IntakeDate = new DateTime(2023, 5, 3, 17, 24, 5), UserID = 1 },
                new WaterIntake {Id=3, ConsumedWater = 2234, IntakeDate = new DateTime(2023, 8, 12, 12, 36, 51), UserID = 1 },
                new WaterIntake { Id = 4, ConsumedWater = 67777, IntakeDate = new DateTime(2023, 10, 23, 11, 17, 12), UserID = 1 },
                new WaterIntake { Id = 5, ConsumedWater = 9967, IntakeDate = new DateTime(2023, 5, 1, 8, 30, 52), UserID = 2 },
                new WaterIntake { Id = 6, ConsumedWater = 14566, IntakeDate = new DateTime(2023, 5, 3, 18, 24, 5), UserID = 2 },
                new WaterIntake { Id = 7,ConsumedWater = 23412, IntakeDate = new DateTime(2023, 8, 15, 12, 36, 51), UserID = 2 },
                new WaterIntake { Id = 8,ConsumedWater = 17965, IntakeDate = new DateTime(2023, 10, 23, 11, 17, 12), UserID = 2 },
                new WaterIntake { Id = 9,ConsumedWater = 89233, IntakeDate = new DateTime(2023, 5, 1, 8, 30, 52), UserID = 3 },
                new WaterIntake { Id = 10, ConsumedWater = 445556, IntakeDate = new DateTime(2023, 5, 3, 19, 24, 5), UserID = 3 },
                new WaterIntake { Id = 11, ConsumedWater = 1965, IntakeDate = new DateTime(2023, 8, 15, 12, 36, 51), UserID = 3 },
                new WaterIntake { Id = 12, ConsumedWater = 38563, IntakeDate = new DateTime(2023, 10, 22, 11, 17, 12), UserID = 3 },
                new WaterIntake { Id = 13, ConsumedWater = 56238, IntakeDate = new DateTime(2023, 5, 1, 8, 30, 52), UserID = 4 },
                new WaterIntake { Id = 14, ConsumedWater = 77796, IntakeDate = new DateTime(2023, 5, 3, 22, 24, 5), UserID = 4 },
                new WaterIntake { Id = 15, ConsumedWater = 32145, IntakeDate = new DateTime(2023, 8, 15, 12, 36, 51), UserID = 4 },
                new WaterIntake { Id = 16, ConsumedWater = 93485, IntakeDate = new DateTime(2023, 10, 21, 11, 17, 12), UserID = 4 }

                );
        }
    }
}
