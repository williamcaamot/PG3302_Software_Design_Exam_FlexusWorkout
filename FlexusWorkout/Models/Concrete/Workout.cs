using FlexusWorkout.Models.Base;
using FlexusWorkout.Services;

namespace FlexusWorkout.Models.Concrete;

public class Workout
{
    public int? workoutId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public IList<Exercise> Exercises { get; set; }
    public string type { get; set; }
    public string location { get; set; }
    

    public Workout()
    {

    }
    
    
    
}