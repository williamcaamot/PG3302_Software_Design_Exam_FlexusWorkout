using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.DataAccess.DataAccess;

public interface IExerciseDA
{
    public IList<ExerciseType> GetExerciseTypes();
    public Exercise GetExerciseById(int id);
    public Exercise AddExercise(Exercise exercise);
    public IList<Exercise> GetExerciseByType(string type);
    public void DeleteExercise(Exercise exercise);
    
}