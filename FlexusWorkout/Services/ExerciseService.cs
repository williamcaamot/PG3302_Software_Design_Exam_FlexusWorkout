using FlexusWorkout.Services.Repository;
using FlexusWorkout.Model.Base;
using FlexusWorkout.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Services;

public class ExerciseService : Service
{
    private readonly FlexusWorkoutDbContext _db;
    public ExerciseService() //TODO NEED TO EDIT THIS TO USE DEPENDENCY INJECTION
    {
        _db = new();
    }

    public IList<String> getExerciseTypes()
    {
        IList<String> Exercises = _db.Exercise
            .Select(e => e.Type)
            .Distinct()
            .ToList();
        
        return Exercises;
    }
    
    public IList<Exercise> GetExercisesByType(string type)
    {
        return _db.Exercise
            .Where(e => EF.Property<string>(e, "Type") == type)
            .ToList();
    }
    
    public Exercise AddExercise(Exercise exercise)
    {
        var addedExercise = _db.Exercise.Add(exercise);
        _db.SaveChanges();
        return addedExercise.Entity;
    }
}