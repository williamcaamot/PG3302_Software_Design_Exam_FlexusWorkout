using FlexusWorkout.Model;
using FlexusWorkout.View_model.User;

namespace FlexusWorkout.View.Menu;
using Presenter;

public class LoginView : Menu
{
    public LoginView(Presenter presenter) : base(presenter)
    {
    }

    protected override bool Run()
    {
        User loginUser = new();
        UserAuthentication userAuthentication = new();
        
        Console.Clear();
        Console.WriteLine("--Login menu--");
        Console.WriteLine("Enter your email:");
        loginUser.Email = Console.ReadLine(); //pass 
        Console.WriteLine("Enter your password");
        loginUser.Password = Console.ReadLine();

        try
        {
            loginUser = userAuthentication.Authenticate(loginUser); // Will return the authentiacted user    
        }
        catch (Exception e)
        {
            Console.WriteLine(e); // Need to handle this exception better
            // menu could be in a while loop that doesn' break untless the loginsuer above
            // has loginuser.Authenticated = true (is only true if the user is in fact
            // authentiacted
        }
        
        
        
        // TODO check user db for valid credentials - handle what happens on correct/incorrect
        // TODO load user profile somehow (main menu takes in a user object?)
        MainMenuPresenter mainMenuPresenter = new();
        MainMenu mainMenu = new(mainMenuPresenter); // redirects to main menu
        return false;
    }
}