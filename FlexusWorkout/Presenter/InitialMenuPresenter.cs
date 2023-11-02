namespace FlexusWorkout.Presenter;
using View.Menu;

public class InitialMenuPresenter : Presenter
{
    public override bool InputHandler(string? input)
    {
        switch (input)
        {
            case "0":
                return false;
            case "1":
                LoginPresenter loginPresenter = new();
                LoginView loginView = new(loginPresenter);
                return true;
            case "2":
                SignupPresenter signupPresenter = new();
                SignupView signupView = new(signupPresenter);
                return true;
            case "3":
                GuestMenuPresenter guestMenuPresenter = new();
                GuestMenu guestMenu = new(guestMenuPresenter);
                return true;
            default:
                Console.WriteLine("Invalid option, try again.");
                return true;
        }

    }
}