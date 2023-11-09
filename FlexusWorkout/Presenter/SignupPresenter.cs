namespace FlexusWorkout.Presenter;
using Base;

public class SignupPresenter : Presenter
{
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _password;
    
    public SignupPresenter(View.Base.View view, Model.Base.Model model) : base(view, model)
    {
    }

    public override void HandleInput(string? key, string? input)
    {
        switch (key)
        {
            case "firstname":
                if (input == null)
                {
                    MainHandler("error");
                } else
                {
                    _firstName = input;
                }
                break;
            case "lastname":
                if (input == null)
                {
                    MainHandler("error");
                } else
                {
                    _lastName = input;
                }
                break;
            case "email":
                if (input == null)
                {
                    MainHandler("error");
                } else
                {
                    _email = input;
                }
                break;
            case "password":
                if (input == null)
                {
                    MainHandler("error");
                } else
                {
                    _password = input;
                }
                break;
            case "confirmpassword":
                if (input == null)
                {
                    MainHandler("error");
                } else
                {
                    if (_password == input)
                    {
                        MainHandler("ok");
                    }
                    else
                    {
                        _password = null;
                        MainHandler("didntmatch");
                    }
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