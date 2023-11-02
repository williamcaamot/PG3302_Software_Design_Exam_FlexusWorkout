using System.Text.RegularExpressions;

namespace FlexusWorkout.View.Menu;
using Presenter;

public class InitialMenu : Menu
{
    public InitialMenu(Presenter presenter) : base(presenter)
    {
    }

    protected override bool Run()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Flexus Workout app!");
        Console.WriteLine("1 - Login");
        Console.WriteLine("2 - Sign up");
        Console.WriteLine("3 - Log in as guest");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: ");

        return Presenter.InputHandler(Console.ReadLine());
        
    }
}