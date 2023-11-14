using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.Menu;
using ZstdSharp.Unsafe;

namespace FlexusWorkout.Presenters;
using Base;

public class SignupPresenter : Presenter
{
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _password;
    private FlexusWorkoutDbContext _flexusWorkoutDbContext;
    
    public SignupPresenter(View view, Service service) : base(view, service)
    {
        _flexusWorkoutDbContext = new();
        // Run the View loop
        view.Run();
    }

    public override void HandleInput(string? key, string? input)
    {
        if (input == null)
        {
            MainHandler("error");
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
                    //TODO Should this password checking logic be here or should it be moved to the register user method? 
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
                UserService service = new(_flexusWorkoutDbContext);
                User user = new User(_firstName, _lastName, _email, _password);
                try
                {
                    user = service.registerUser(user);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(2000);
                }

                if (user.Authenticated)
                {
                    MainMenu mainMenu = new();
                    MainMenuPresenter mainMenuPresenter = new(mainMenu, user);
                }
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