using FlexusWorkout.Model.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkout.View.Menu;

public class LoginView : Base.View
{
    protected override bool Display()
    {
        
        User loginUser = new();
        UserAuthentication userAuthentication = new();

        while (loginUser.Authenticated == false)
        {
            Console.Clear();
            Console.WriteLine("--Login menu--");
            Console.WriteLine("Enter your email:");
            loginUser.Email = Console.ReadLine();
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
        }
        
        
        
        
        // TODO check user db for valid credentials - handle what happens on correct/incorrect
        // TODO load user profile somehow (main menu takes in a user object?)
        //MainMenuPresenter mainMenuPresenter = new();
        //MainMenu mainMenu = new(mainMenuPresenter); // redirects to main menu
        return false;
    }
}