using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using Google.Protobuf;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Services.Repository;

public class FlexusWorkoutDbContext : DbContext
{// One DB context for project to keep things simple
    
    public DbSet<User> User => Set<User>();
    public DbSet<Exercise> Exercise => Set<Exercise>();
    public DbSet<Workout> Workout => Set<Workout>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseMySQL("server=localhost;port=3200;database=db;user=user;password=password;");
        optionsBuilder.UseSqlite(@"Data Source = Resources/Flexus.db");
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