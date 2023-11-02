using FlexusWorkout.View_model;
using FlexusWorkout.View_model.User;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Model;

public class FlexusWorkoutDbContext : DbContext
{// One DB context for project to keep things simple
    
    public DbSet<User> User => Set<User>();
    public DbSet<Exercise> Exercise => Set<Exercise>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = Resources/Flexus.db"); // @ means backslashes don't need to be escaped
    }
}