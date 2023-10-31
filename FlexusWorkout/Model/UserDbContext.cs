using FlexusWorkout.View_model.User;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Model;

public class UserDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = Resources/flexus_workout.db"); // @ means backslashes don't need to be escaped
        
    }

    public DbSet<User> Student => Set<User>();
    
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder); // Here we can write
     //   modelBuilder.Entity<Education>().Property(e => e.Name).IsRequired();
    //    // Make the field Name required, the more complex but more flexible way
    //}
}