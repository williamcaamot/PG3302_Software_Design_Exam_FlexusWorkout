using System.Collections;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Services;

public class ExerciseService : Service
{
    private readonly FlexusDbContext _db;
    //TODO NEED TO EDIT THIS TO USE DEPENDENCY INJECTION

    public ExerciseService(FlexusDbContext db)
    {
        _db = db;
    }

    public IList<ExerciseType> getExerciseTypes()
    {
        /*IList<String> exerciseTypes = _db.Exercise
            .Select(e => e.Type)
            .Distinct()
            .ToList();
        */
        IList<ExerciseType> exerciseTypes = _db.Exercise
            .Select(e => new ExerciseType(EF.Property<string>(e, "Type")))
            .Distinct()
            .ToList();
        return exerciseTypes;
    }
    
    public IList<Exercise> GetExercisesByType(string type)
    {
        return _db.Exercise
            .Where(e => EF.Property<string>(e, "Type") == type)
            .ToList();
    }

    public Exercise GetExercise(int id)
    {
        return _db.Exercise.FirstOrDefault(e => e.ExerciseId == id);
    }
    
    public Exercise AddExercise(Exercise exercise)
    {
        var addedExercise = _db.Exercise.Add(exercise);
        _db.SaveChanges();
        return addedExercise.Entity;
    }
}