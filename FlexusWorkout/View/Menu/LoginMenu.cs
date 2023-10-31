namespace FlexusWorkout.View.Menu;

public class LoginMenu : Menu
{
    protected override bool Run()
    {
        Console.Clear();
        Console.WriteLine("--Login menu--");
        Console.WriteLine("Enter your username:");
        String? username = Console.ReadLine();
        Console.WriteLine("Enter your password");
        String? password = Console.ReadLine();
        // TODO check user db for valid credentials - handle what happens on correct/incorrect
        // TODO load user profile somehow (main menu takes in a user object?)
        MainMenu mainMenu = new(); // redirects to main menu
        return false;
    }
}