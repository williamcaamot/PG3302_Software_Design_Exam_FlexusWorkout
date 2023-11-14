using FlexusWorkout.Models;

namespace FlexusWorkout.Views.WorkoutPlanner;

public class WorkoutPlannerMenu
{
    private List<WeeklyWorkoutPlanner> _weeklyWorkoutPlanners;

    public WorkoutPlannerMenu()
    {
        _weeklyWorkoutPlanners = new List<WeeklyWorkoutPlanner>();
    }

    public void addWeeklyPlan(List<WeeklyWorkoutPlanner> weekPlan)
    {
        _weeklyWorkoutPlanners.AddRange(weekPlan);
        Console.WriteLine("Your plan was added successfully");
    }
}