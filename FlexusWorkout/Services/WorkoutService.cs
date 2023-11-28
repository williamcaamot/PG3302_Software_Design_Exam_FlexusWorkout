using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;

namespace FlexusWorkout.Services;

public class WorkoutService : Service
{
    private IFlexusDbContext _db;
    public WorkoutService(IFlexusDbContext db)
    {
        _db = db;
    }

    public Workout AddExercise(Workout workout, Exercise exercise)
    {
        workout.Exercises.Add(exercise);
        var updatedWorkout = _db.Workout.Update(workout);
        _db.SaveChanges();
        return updatedWorkout.Entity;
    }

    public Workout AddWorkout(Workout workout)
    {
        var addedWorkout = _db.Workout.Add(workout);
        _db.SaveChanges();
        return addedWorkout.Entity;
    }

    public Workout UpdateWorkout(Workout workout)
    {
        var updatedWorkout = _db.Workout.Update(workout);
        _db.SaveChanges();
        return updatedWorkout.Entity;
    }
    
    
    
}