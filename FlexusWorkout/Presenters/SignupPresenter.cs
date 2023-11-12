using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters;

public class SignupPresenter : Base.Presenter
{
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _password;
    
    public SignupPresenter(View view, Service service) : base(view, service)
    {
    }

    public override void HandleInput(string? key, string? input)
    {
        if (input == null)
        {
            MainHandler("error");
            return;
        }
        switch (key)
        {
            case "firstname":
                _firstName = input;
                break;
            case "lastname":
                _lastName = input;
                break;
            case "email":
                _email = input;
                break;
            case "password":
                _password = input;
                break;
            case "confirmpassword":
                if (_password == input)
                {
                    MainHandler("ok");
                } else
                {
                    _password = null;
                    MainHandler("didntmatch");
                }
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "ok":
                // TODO add sign up code here.
                break;
            case "error":
                Console.Clear();
                Console.WriteLine("There was en error getting your input.");
                Thread.Sleep(2000);
                break;
            case "didntmatch":
                Console.Clear();
                Console.WriteLine("The passwords did not match.");
                Thread.Sleep(2000);
                break;
        }
        View.Stop();
    }
}