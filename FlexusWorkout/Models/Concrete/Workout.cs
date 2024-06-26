using System.ComponentModel.DataAnnotations;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Models.Concrete;

public class Workout
{
    [Key]
    public int? WorkoutId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual List<Exercise> Exercises { get; set; }
    public virtual User User { get; set; }

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
    
}