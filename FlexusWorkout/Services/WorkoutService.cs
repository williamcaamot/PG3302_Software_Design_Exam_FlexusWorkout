using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;

namespace FlexusWorkout.Services;

public class WorkoutService : Service
{
    private FlexusDbContext _db;
    public WorkoutService(FlexusDbContext db)
    {
        _db = db;
    }

    public Workout addExercise(Workout workout, Exercise exercise)
    {
        workout.Exercises.Add(exercise); //Todo check if exercise already exists
        var addedWorkout = _db.Workout.Update(workout);
        _db.SaveChanges();
        return addedWorkout.Entity;
    }

    public Workout addWorkout(Workout workout)
    {
        var addedWorkout = _db.Workout.Add(workout);
        Console.WriteLine($"Added a workout, this is the id {addedWorkout.Entity.WorkoutId}");
        _db.SaveChanges();
        return addedWorkout.Entity;
    }
    
    
    
}