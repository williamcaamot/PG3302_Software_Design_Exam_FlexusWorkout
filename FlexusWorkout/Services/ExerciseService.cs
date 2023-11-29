using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;

namespace FlexusWorkout.Services;

public class ExerciseService : IService
{
    private readonly IExerciseDA _exerciseDa;
    public ExerciseService(IExerciseDA iExerciseDa)
    {
        _exerciseDa = iExerciseDa;
    }

    public IList<ExerciseType> GetExerciseTypes()
    {
        return _exerciseDa.GetExerciseTypes();
    }
    
    public IList<Exercise> GetExercisesByType(string type)
    {
        return _exerciseDa.GetExerciseByType(type);
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
        IList<Exercise> exercises = _exerciseDa.GetExerciseByType(type);

        Random random = new();
        int randomNumber = random.Next(exercises.Count);

        return exercises[randomNumber];
    }

    public void DeleteExercise(Exercise exercise)
    {
        _exerciseDa.DeleteExercise(exercise);
    }
}