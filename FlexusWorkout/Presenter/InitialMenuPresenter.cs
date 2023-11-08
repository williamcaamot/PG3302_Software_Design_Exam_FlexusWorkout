using System.Reflection.Metadata;
using FlexusWorkout.Model.Concrete;

namespace FlexusWorkout.Presenter;
using View.Menu;
using Base;


public class InitialMenuPresenter : MenuPresenter
{
    public InitialMenuPresenter(View.Base.View view) : base(view)
    {
    }

    public override void HandleInput(string? key, string? input)
    {
        switch (key)
        {
            case "input":
                MainHandler(input);
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "0":
                View.Stop();
                break;
            case "1":
                LoginView loginView = new();
                User user = new();
                LoginPresenter loginPresenter = new(loginView, user);
                break;
            case "2":
                SignupView signupView = new();
                User user2 = new();
                //SignupPresenter signupPresenter = new(signupView, user2);
                break;
            case "3":
                GuestMenu guestMenu = new();
                GuestMenuPresenter guestMenuPresenter = new(guestMenu);
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                break;
        }

    }
}