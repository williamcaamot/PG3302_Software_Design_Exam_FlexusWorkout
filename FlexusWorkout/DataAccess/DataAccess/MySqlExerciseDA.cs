using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.DataAccess.DataAccess;

public class MySqlExerciseDA : IExerciseDA
{
    private IFlexusDbContext _db;
    public MySqlExerciseDA(IFlexusDbContext db)
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

    public Exercise GetExerciseById(int id)
    {
        //TODO fix this
        return _db.Exercise.FirstOrDefault(e => e.ExerciseId == id);
    }

    public Exercise AddExercise(Exercise exercise)
    {
        var addedExercise = _db.Exercise.Add(exercise);
        _db.SaveChanges();
        return addedExercise.Entity;
    }

    public IList<Exercise> GetExerciseByType(string type)
    {
        return _db.Exercise
            .Where(e => e.Standard == true)
            .Where(e => EF.Property<string>(e, "Type") == type)
            .ToList();
    }

    public void DeleteExercise(Exercise exercise)
    {
        _db.Exercise.Remove(exercise);
        _db.SaveChanges();
    }
}