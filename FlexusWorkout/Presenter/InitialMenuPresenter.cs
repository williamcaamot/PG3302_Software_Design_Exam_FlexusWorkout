using FlexusWorkout.Model.Concrete;

namespace FlexusWorkout.Presenter;
using View.Menu;
using Base;


public class InitialMenuPresenter : MenuPresenter
{
    public InitialMenuPresenter(View.Base.View view) : base(view)
    {
    }

    public override bool InputHandler(string? input)
    {
        switch (input)
        {
            case "0":
                return false;
            case "1":
                LoginView loginView = new();
                User user = new();
                //LoginPresenter loginPresenter = new(loginView, user)
                    ;
                return true;
            case "2":
                SignupView signupView = new();
                User user2 = new();
                //SignupPresenter signupPresenter = new(signupView, user2);
                return true;
            case "3":
                GuestMenu guestMenu = new();
                GuestMenuPresenter guestMenuPresenter = new(guestMenu);
                return true;
            default:
                Console.WriteLine("Invalid option, try again.");
                return true;
        }

    }
}