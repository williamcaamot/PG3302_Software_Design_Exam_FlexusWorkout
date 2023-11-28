using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.DataAccess.Repository;

public interface IFlexusDbContext
{
    int SaveChanges();
    DbSet<User> User { get; }
    DbSet<Exercise> Exercise { get; }
    DbSet<Workout> Workout { get; }
    DbSet<WorkoutDay> WorkoutDay { get; }
}