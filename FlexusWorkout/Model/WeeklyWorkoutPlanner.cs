namespace FlexusWorkout.View_model.WorkoutPlanner;

public class WeeklyWorkoutPlanner
{

    public int IdOfPlan { get; set; }
    public int UserId { get; set; }
    public List<Exercise> Exercises { get; set; }
    public DayOfWeek DaySet { get; set; }
    
    public WeeklyWorkoutPlanner()
    {
        Exercises = new List<Exercise>();
    }
        

    
}