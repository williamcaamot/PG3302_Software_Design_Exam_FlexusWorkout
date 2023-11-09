using FlexusWorkout.Model.Base;
using FlexusWorkout.Services;

namespace FlexusWorkout.Model.Concrete;

public class Workout
{
    public int? Id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public IList<Exercise> Exercises { get; set; }
    public string type { get; set; }
    public string location { get; set; }
    

    public Workout()
    {

    }
    
    
    
}