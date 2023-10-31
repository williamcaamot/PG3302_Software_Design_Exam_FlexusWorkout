using Microsoft.VisualBasic;

namespace FlexusWorkout.View_model.WorkoutPlanner;

public class workoutSession
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateAndTime Date { get; set; }
}