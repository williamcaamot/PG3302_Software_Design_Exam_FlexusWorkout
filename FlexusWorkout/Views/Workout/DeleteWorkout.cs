using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.Workout;

public class DeleteWorkout : View
{
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("Delete an existing workout:");
        OnInputReceived("getworkouts", "");
        
        Console.WriteLine("0 - Back");
        Console.Write("\r\nSelect an exercise: ");
        var input = Console.ReadLine();
        OnInputReceived("input", input);

    }
}