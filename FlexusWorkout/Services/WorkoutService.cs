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
        workout.Exercises.Add(exercise);

        return new Workout();
    }
    
    
    
}