using FlexusWorkout.Model.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkout.View.Menu;

public class LoginView : Base.View
{
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("--Login menu--");
        
        Console.WriteLine("Enter your email:");
        var email = Console.ReadLine();
        OnInputReceived("email", email);
        
        Console.WriteLine("Enter your password");
        var password = Console.ReadLine();
        OnInputReceived("password", password);
        
    }
}