using FlexusWorkout.Model.Base;
using FlexusWorkout.Services;

namespace FlexusWorkout.Model.Concrete;

public class Workout
{
    public int? Id { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public IList<Exercise> Exercises { get; set; }
    
    public string Name { get; set; }
    public string Type { get; set; }



    public Workout()
    {

        Exercises = new List<Exercise>();
    }
    
    
    
}