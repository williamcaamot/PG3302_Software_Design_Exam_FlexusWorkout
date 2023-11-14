using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.Workout;

public class ModifyWorkout : View
{
    protected override void Display()
    {
        Console.Clear();
        OnInputReceived("currentlymodifying", "");
        Console.WriteLine("How would you like to modify this workout?");
        Console.WriteLine("1 - Edit exercises in workout");
        Console.WriteLine("2 - Delete this workout");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: ");
        var input = Console.ReadLine();
        OnInputReceived("input", input);
    }
}