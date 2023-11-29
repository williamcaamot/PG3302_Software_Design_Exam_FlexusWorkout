using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

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
        throw new NotImplementedException();
    }

    public Exercise GetExerciseById(int id)
    {
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
        throw new NotImplementedException();
    }

    public void DeleteExercise(Exercise exercise)
    {
        throw new NotImplementedException();
    }
}