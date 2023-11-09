using FlexusWorkout.Model.Base;
using FlexusWorkout.Model.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.View.Menu.Model;

public class FlexusWorkoutDbContext : DbContext
{// One DB context for project to keep things simple
    
    public DbSet<User> User => Set<User>();
    public DbSet<Exercise> Exercise => Set<Exercise>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = Resources/Flexus.db"); // @ means backslashes don't need to be escaped
    } //TODO TAKE THIS AS AN ARGUMENT WHEN CALLING THE METHOD - SO WE CAN USE ANOTHER DATABASE FOR TESTING PURPOSES
    // TODO SOMEHOW REFERENCE THE LOCAL DB OR NOT OVERRIDE IT EVERY TIME WHEN SENDING IT IN
    
    
    // So that we only need ONE context for the three subclasses of exercise
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Exercise>()
            .HasDiscriminator<string>("Discriminator")
            .HasValue<StrengthExercise>("Strength")
            .HasValue<BalanceExercise>("Balance")
            .HasValue<CardioExercise>("Cardio");
    }
}