using FlexusWorkout.Models;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.WorkoutPlanner;

public class WorkoutPlannerMenu : View
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

    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("Workoutplanner Menu");
        Console.WriteLine("1- Show the weekly plan");
        Console.WriteLine("2- Plan a new week");
        Console.WriteLine("0- Exit");
        var userInput = Console.ReadLine();
        OnInputReceived("input", userInput);

    }
}