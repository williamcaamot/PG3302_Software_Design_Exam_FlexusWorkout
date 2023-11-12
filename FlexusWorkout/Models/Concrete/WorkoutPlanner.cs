using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Models.Concrete;

public class WorkoutPlanner
{
    private List<WeeklyWorkoutPlanner> weekPlans;

    public WorkoutPlanner()
    {
        weekPlans = new List<WeeklyWorkoutPlanner>();
    }

    public List<WeeklyWorkoutPlanner> GetWorkouts()
    {
        return weekPlans;
    }

    public void BuildWorkout(string day, List<Exercise> exercises)
    {
        var session = new WeeklyWorkoutPlanner(day, exercises);
        weekPlans.Add(session);
    }
    
}