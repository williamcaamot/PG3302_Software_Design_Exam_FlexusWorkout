using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.Menu;

namespace FlexusWorkout.Presenters;
using Base;

public class SignupPresenter : Presenter
{
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _password;
    private readonly MySqlFlexusDbContext _mySqlFlexusDbContext;
    
    public SignupPresenter(View view, IService service) : base(view, service)
    {
        _mySqlFlexusDbContext = DbContextManager.Instance;
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
                MySqlUserDA mySqlUserDa = new MySqlUserDA(_mySqlFlexusDbContext);
                UserService service = new(mySqlUserDa);
                User user = new User(_firstName, _lastName, _email, _password);
                try
                {
                    user = service.RegisterUser(user);
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