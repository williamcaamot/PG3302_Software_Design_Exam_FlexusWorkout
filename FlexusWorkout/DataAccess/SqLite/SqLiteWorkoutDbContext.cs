using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.DataAccess.SqLite;

public class SqLiteWorkoutDbContext : DbContext, WorkoutDbContext 
{
    public DbSet<User> User { get; }
    public DbSet<Exercise> Exercise { get; }
    public DbSet<Workout> Workout { get; }
}