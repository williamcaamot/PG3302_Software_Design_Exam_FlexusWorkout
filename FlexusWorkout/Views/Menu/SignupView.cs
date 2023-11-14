using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.Menu;
public class SignupView : View
{

    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("Creating new account...");
        
        Console.WriteLine("Enter your first name:");
        var firstName = Console.ReadLine();
        OnInputReceived("firstname", firstName);
        
        Console.WriteLine("Enter your last name:");
        var lastName = Console.ReadLine();
        OnInputReceived("lastname", lastName);
        
        Console.WriteLine("Enter your email:");
        var email = Console.ReadLine();
        OnInputReceived("email", email);
        // TODO check if username is available here
        
        Console.WriteLine("Enter a password:");
        var password = Console.ReadLine();
        OnInputReceived("password", password);
        
        Console.WriteLine("Confirm password:");
        var confirmPassword = Console.ReadLine();
        OnInputReceived("confirmpassword", confirmPassword);
        
        // TODO implement a way to cancel signup?
    }
}