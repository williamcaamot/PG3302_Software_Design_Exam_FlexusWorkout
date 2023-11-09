namespace FlexusWorkout.View.Menu;

public class GuestMenu : Base.View
{
    
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("-- Logged in as Guest --");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1 - Look up an exercise");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: ");
        var input = Console.ReadLine();
        if (input != null) OnInputReceived("input", input);
    }
}