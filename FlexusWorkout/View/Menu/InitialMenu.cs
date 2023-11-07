namespace FlexusWorkout.View.Menu;

public class InitialMenu : Base.View
{

    protected override bool Display()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Flexus Workout app!");
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Sign up");
        Console.WriteLine("3 - Log in as guest");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: "); 
        var input = Console.ReadLine();
        if (input != null) OnInputReceived("input", input);

        return false;
    }
}