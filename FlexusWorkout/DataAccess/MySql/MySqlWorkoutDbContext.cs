using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.DataAccess.MySql;

public class MySqlWorkoutDbContext : DbContext, WorkoutDbContext
{
    public DbSet<User> User { get; }
    public DbSet<Exercise> Exercise { get; }
    public DbSet<Workout> Workout { get; }
}