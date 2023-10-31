namespace FlexusWorkout.View.Menu;

public class SignupMenu : Menu
{
    protected override bool Run()
    {
        Console.Clear();
        Console.WriteLine("Creating new account...");
        Console.WriteLine("Enter a username:");
        String? username = Console.ReadLine();
        // TODO check if username is available here
        Console.WriteLine("Enter a password:");
        String? pwInput1 = Console.ReadLine();
        Console.WriteLine("Confirm password:");
        String? pwInput2 = Console.ReadLine();
        
        // check if entered passwords are the same
        if (pwInput1 == pwInput2)
        {
            //TODO create user in db
            //TODO make the new user logged in on creation
            MainMenu mainMenu = new(); // redirect to main menu
            return false;
        }
        // TODO implement a way to cancel signup?
        return true;
    }
}