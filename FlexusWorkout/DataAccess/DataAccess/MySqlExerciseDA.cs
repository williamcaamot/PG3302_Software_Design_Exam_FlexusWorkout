using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.DataAccess.DataAccess;

public class MySqlExerciseDA : IExerciseDA
{
    public IList<ExerciseType> GetExerciseTypes()
    {
        throw new NotImplementedException();
    }

    public Exercise GetExerciseById(int id)
    {
        throw new NotImplementedException();
    }

    public Exercise AddExercise(Exercise exercise)
    {
        throw new NotImplementedException();
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