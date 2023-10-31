namespace FlexusWorkout.View_model.WorkoutPlanner;

public class WorkoutPlanner
{
    //Create a calender where user can track/plan workouts
    
    public List<WorkoutSession> WorkoutsPlanned { get; set; } = new();
    
    public void deleteSession(WorkoutSession ws)
    {
        WorkoutsPlanned.Remove(ws);
    }
    
}