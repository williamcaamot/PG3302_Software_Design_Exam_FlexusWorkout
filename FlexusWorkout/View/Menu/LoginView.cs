namespace FlexusWorkout.View.Menu;
using Presenter;

public class LoginView : Menu
{
    public LoginView(Presenter presenter) : base(presenter)
    {
    }

    protected override bool Run()
    {
        Console.Clear();
        Console.WriteLine("--Login menu--");
        Console.WriteLine("Enter your username:");
        String? username = Console.ReadLine(); //pass 
        Console.WriteLine("Enter your password");
        String? password = Console.ReadLine(); 
        // TODO check user db for valid credentials - handle what happens on correct/incorrect
        // TODO load user profile somehow (main menu takes in a user object?)
        MainMenuPresenter mainMenuPresenter = new();
        MainMenu mainMenu = new(mainMenuPresenter); // redirects to main menu
        return false;
    }
}