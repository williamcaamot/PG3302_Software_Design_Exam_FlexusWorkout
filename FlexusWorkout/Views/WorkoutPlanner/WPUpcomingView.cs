using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.WorkoutPlanner;

public class WPUpcomingView : View
{
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("Your upcoming workout plans");
        OnInputReceived("getWorkoutPlans", "");
        var pressKey = Console.ReadKey();
        

    }
}