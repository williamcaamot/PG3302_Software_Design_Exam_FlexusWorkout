namespace FlexusWorkout.Views.Menu;

public class WorkoutMenu : Base.View
{

    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("--Workout Menu--");
        Console.WriteLine("1 - Show your existing workouts");
        Console.WriteLine("2 - Add a new workout");
        Console.WriteLine("3 - Delete an existing workout");
        Console.WriteLine("0 - Back");
        Console.Write("\r\nSelect an option: ");
        var input = Console.ReadLine();
        OnInputReceived("input", input);
    }
}