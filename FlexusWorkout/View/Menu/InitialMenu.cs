using System.Text.RegularExpressions;

namespace FlexusWorkout.View.Menu;

public class InitialMenu : Menu
{
    public override bool Run()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Flexus Workout app!");
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Sign up");
        Console.WriteLine("3 - Log in as guest");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "0":
                return false;
            case "1":
                LoginMenu loginMenu = new();
                return true;
            case "2":
                Console.WriteLine("To Signup menu");
                return true;
            case "3":
                GuestMenu guestMenu = new();
                return true;
            default:
                Console.WriteLine("Invalid option, try again.");
                return true;
        }
    }
}