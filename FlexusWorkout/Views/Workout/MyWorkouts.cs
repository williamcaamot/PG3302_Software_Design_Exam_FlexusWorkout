using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.Workout;

public class MyWorkouts : View
{
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("-- My Workouts --");
        Console.WriteLine("Here is all your existing workouts:");
        OnInputReceived("getworkouts", "");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: ");
        var input = Console.ReadLine();
        OnInputReceived("input", input);
    }
}