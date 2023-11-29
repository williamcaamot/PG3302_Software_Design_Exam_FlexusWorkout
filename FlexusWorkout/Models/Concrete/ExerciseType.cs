using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Services;

namespace FlexusWorkout.Models.Concrete;

public class ExerciseType
{
    public string Name { get; }
    public List<Exercise> Exercises { get; set; }

    public int Count
    {
        get => Exercises.Count;
    }

    public ExerciseType(string name)
    {
        Name = name;
        Exercises = new List<Exercise>();
        
        // populate Exercises list

    }

    public void AddExercise(Exercise exercise)
    {
        Exercises.Add(exercise);
    }

}