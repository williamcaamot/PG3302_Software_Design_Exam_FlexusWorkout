using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using Google.Protobuf;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Services.Repository;

public class FlexusWorkoutDbContext : DbContext, FlexusDbContext
{// One DB context for project to keep things simple
    
    public DbSet<User> User => Set<User>();
    public DbSet<Exercise> Exercise => Set<Exercise>();
    public DbSet<Workout> Workout => Set<Workout>();
    public DbSet<WorkoutDay> WorkoutDay => Set<WorkoutDay>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.UseMySQL("server=localhost;port=3200;database=db;user=user;password=password;");
        //optionsBuilder.UseSqlite(@"Data Source = Resources/Flexus.db");
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.Entity<Exercise>()  // So that we only need ONE context for the three subclasses of exercise
            .HasDiscriminator<string>("Discriminator")
            .HasValue<StrengthExercise>("Strength")
            .HasValue<BalanceExercise>("Balance")
            .HasValue<CardioExercise>("Cardio");
        
        modelBuilder.Entity<Workout>() //Should create a join table
            .HasMany(e => e.Exercises)
            .WithMany();
        
    }
    public new int SaveChanges()
    {
        return base.SaveChanges();
    }
}