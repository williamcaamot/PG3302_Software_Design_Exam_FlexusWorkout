namespace FlexusWorkout.View.Menu;
using Presenter;
public class SignupView : Base.View
{

    protected override void Display()
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
            //MainMenuBasePresenter mainMenuBasePresenter = new();
            //MainMenu mainMenu = new(mainMenuBasePresenter); // redirect to main menu
        }
        // TODO implement a way to cancel signup?
    }
}