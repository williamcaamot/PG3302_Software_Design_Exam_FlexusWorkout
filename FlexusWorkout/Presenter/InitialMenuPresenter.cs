using System.Reflection.Metadata;
using FlexusWorkout.Model.Concrete;
using FlexusWorkout.Services;

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
                // exit view
                View.Stop();
                break;
            case "1":
                // send user to login view
                LoginView loginView = new();
                UserService userService = new();
                LoginPresenter loginPresenter = new(loginView, userService);
                break;
            case "2":
                // send user to signup view
                SignupView signupView = new();
                UserService userService2 = new();
                SignupPresenter signupPresenter = new(signupView, userService2);
                break;
            case "3":
                // send user to guest menu
                GuestMenu guestMenu = new();
                GuestMenuPresenter guestMenuPresenter = new(guestMenu);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid option, try again...");
                Thread.Sleep(2000);
                break;
        }

    }
}