using FlexusWorkout.View.Menu.Model;
using FlexusWorkout.Model.Base;
using FlexusWorkout.Model.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Services;

public class ExerciseService {
    private readonly FlexusWorkoutDbContext _db;
    public ExerciseService() //TODO NEED TO EDIT THIS TO USE DEPENDENCY INJECTION
    {
        _db = new();
    }
    
    public IList<Exercise> GetExercisesByType(string type)
    {
        return _db.Exercise
            .Where(e => EF.Property<string>(e, "ExerciseType") == type)
            .ToList();
    }
    
    public Exercise AddExercise(Exercise exercise)
    {
        var addedExercise = _db.Exercise.Add(exercise);
        _db.SaveChanges();
        return addedExercise.Entity;
    }
}