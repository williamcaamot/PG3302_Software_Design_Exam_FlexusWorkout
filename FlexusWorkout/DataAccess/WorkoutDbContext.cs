using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.DataAccess;

public interface WorkoutDbContext
{
    int SaveChanges();
    DbSet<User> User { get; }
    DbSet<Exercise> Exercise { get; }
    DbSet<Workout> Workout { get; }
}