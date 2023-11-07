using FlexusWorkout.Model;

namespace FlexusWorkout.View.Menu.View.WorkoutPlanner;

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