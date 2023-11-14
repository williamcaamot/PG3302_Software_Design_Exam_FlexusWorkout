using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.ExerciseFinder;

public class ExerciseSelector : View
{
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("Which exercise would you like to look at?");
        OnInputReceived("getexercises", "");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: "); 
        var input = Console.ReadLine();
        OnInputReceived("input", input);
    }
}