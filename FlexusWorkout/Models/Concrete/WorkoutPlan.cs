using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Models.Concrete;

public class WorkoutPlan : Model
{
    public DateOnly Date { get; set; }
    public Workout Workout { get; set; }
    
    public WorkoutPlan()
    {
        
    }
}