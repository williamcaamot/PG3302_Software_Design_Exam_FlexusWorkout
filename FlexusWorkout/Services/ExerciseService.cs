using System.Collections;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Cmp;

namespace FlexusWorkout.Services;

public class ExerciseService : Service
{
    private readonly FlexusDbContext _db;
    //TODO NEED TO EDIT THIS TO USE DEPENDENCY INJECTION

    public ExerciseService(FlexusDbContext db)
    {
        _db = db;
    }

    public IList<ExerciseType> GetExerciseTypes()
    {
        IList<ExerciseType> exerciseTypes = _db.Exercise
            .Where(e => e.Standard == true)
            .Select(e => new ExerciseType(EF.Property<string>(e, "Type")))
            .Distinct()
            .ToList();
        return exerciseTypes;
    }
    
    public IList<Exercise> GetExercisesByType(string type)
    {
        return _db.Exercise
            .Where(e => e.Standard == true)
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

    public Exercise getRandomExercise(string type)
    {
        IList<Exercise> exercises = GetExercisesByType(type);

        Random random = new();
        int randomNumber = random.Next(exercises.Count);

        return exercises[randomNumber];
    }
}