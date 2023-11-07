using FlexusWorkout.Model;

namespace FlexusWorkout.View.WorkoutPlanner;

public class WeeklyWorkoutPlan
{
    public List<WeeklyWorkoutPlanner> WeeklyWorkouts { get; set; }

    public WeeklyWorkoutPlan()
    {
        WeeklyWorkouts = new List<WeeklyWorkoutPlanner>();
    }

    public void AddWorkout(WeeklyWorkoutPlanner weeklyPlan)
    {
        WeeklyWorkouts.Add(weeklyPlan);
    }
}