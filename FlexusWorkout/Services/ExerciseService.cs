using System.Collections;
using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Services;

public class ExerciseService : Service
{
    private readonly IFlexusDbContext _db;

    private readonly IExerciseDA _exerciseDa;
    //TODO NEED TO EDIT THIS TO USE DEPENDENCY INJECTION

    public ExerciseService(IFlexusDbContext db)
    {
        _db = db;
        _exerciseDa = new MySqlExerciseDA(_db);
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
        return _exerciseDa.GetExerciseById(id);
    }
    
    public Exercise AddExercise(Exercise exercise)
    {
        return _exerciseDa.AddExercise(exercise);
    }

    public Exercise GetRandomExercise(string type)
    {
        IList<Exercise> exercises = GetExercisesByType(type);

        Random random = new();
        int randomNumber = random.Next(exercises.Count);

        return exercises[randomNumber];
    }

    public void DeleteExercise(Exercise exercise)
    {
        _db.Exercise.Remove(exercise);
        _db.SaveChanges();
    }
    
}