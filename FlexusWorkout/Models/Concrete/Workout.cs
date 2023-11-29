using System.ComponentModel.DataAnnotations;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Services;

namespace FlexusWorkout.Models.Concrete;

public class Workout
{
    [Key]
    public int? WorkoutId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Exercise> Exercises { get; set; }
    public virtual User User { get; set; }
    public virtual int UserId { get; set; }

    public Workout(string name, string description)
    {
        Name = name;
        Description = description;

        
        Exercises = new List<Exercise>();
    }

    public Workout()
    {
        Exercises = new List<Exercise>();
    }

    public override string ToString()
    {
        string theString = $"{Name}" + //BUG Workout doesn't know about exercises in this context, so the tostring won't work
                           "\r\n---------------" +
                           $"\r\n{Description}" +
                           "\r\n---------------" +
                           $"\r\nExercises:";
        foreach (var exercise in Exercises)
        {
            theString.Concat("\r\n" + exercise.Name);
        }
        return theString;
    }
}