namespace FlexusWorkout.Views.ExerciseFinder;

public class ExerciseFinderMenu : Base.View
{
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("-- Exercise Finder --");
        Console.WriteLine("Find an exercise:");
        OnInputReceived("getcategories", "");
        Console.WriteLine("0 - Back");
        Console.Write("\r\nSelect an option: "); 
        var input = Console.ReadLine();
        OnInputReceived("input", input);
    }
}