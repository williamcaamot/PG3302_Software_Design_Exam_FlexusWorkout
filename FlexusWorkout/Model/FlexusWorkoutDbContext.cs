using FlexusWorkout.View_model.User;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Model;

public class FlexusWorkoutDbContext : DbContext
{// One DB context for project to keep things simple
    public DbSet<User> Users => Set<User>();
    
    // set for workouts
    // set for workout plans
    
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = Resources/School.db"); // @ means backslashes don't need to be escaped
    }
    
    
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder); // Here we can write
     //   modelBuilder.Entity<Education>().Property(e => e.Name).IsRequired();
    //    // Make the field Name required, the more complex but more flexible way
    //}
}