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
    public IList<Exercise> Exercises { get; set; }
    public User User { get; set; }

    public Workout(string name, string description)
    {
        Name = name;
        Description = description;

        
        Exercises = new List<Exercise>();
    }

    public Workout()
    {
    }



}