namespace FlexusWorkout.View.Menu;

public class LoginMenu : Menu
{
    public override bool Run()
    {
        Console.Clear();
        Console.WriteLine("Enter your username:");
        String? username = Console.ReadLine();
        Console.WriteLine("Enter your password");
        String? password = Console.ReadLine();

        MainMenu mainMenu = new();
        return false;
    }
}