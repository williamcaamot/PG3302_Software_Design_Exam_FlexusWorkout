using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;

namespace FlexusWorkout.Services;

public class WorkoutService : Service
{
    private FlexusWorkoutDbContext _db;
    public WorkoutService()
    {
        _db = new FlexusWorkoutDbContext();
    }

    public Workout addExercise(Workout workout, Exercise exercise)
    {
        workout.Exercises.Add(exercise); //Todo check if exercise already exists
        var addedWorkout = _db.Workout.Update(workout);
        return addedWorkout.Entity;
    }

    public Workout addWorkout(Workout workout)
    {
        var addedWorkout = _db.Workout.Add(workout);
        return addedWorkout.Entity;
    }
    
    
    
}