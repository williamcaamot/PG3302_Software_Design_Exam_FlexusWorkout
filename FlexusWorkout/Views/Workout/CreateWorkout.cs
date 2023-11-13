using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.Workout;

public class CreateWorkout : View
{
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("Creating new workout...");
        Console.WriteLine("Enter a name for workout: ");
        var name = Console.ReadLine();
        OnInputReceived("name", name);
    }
}