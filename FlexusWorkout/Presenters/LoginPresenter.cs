using FlexusWorkout.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.Menu;

namespace FlexusWorkout.Presenters;

public class LoginPresenter : Base.Presenter
{
    private string? _email;
    private string? _password;
    private View _view;
    private MySqlFlexusDbContext _mySqlFlexusDbContext;
    public LoginPresenter(View view, Service service) : base(view, service)
    {
        _view = view;
        _mySqlFlexusDbContext = DbContextManager.Instance;
        // Run the View loop
        _view.Run();   
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
            case "email":
                _email = input;
                break;
            case "password":
                _password = input;
                break;
        }
        
        // both email and password were received successfully
        if (_email != null && _password != null)
        {
            MainHandler("ok");
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "ok":
                User loginUser = new();
                MySqlUserDA mySqlUserDa = new MySqlUserDA(_mySqlFlexusDbContext);
                UserService userService = new(mySqlUserDa);
                try
                {
                    loginUser = userService.LoginUser(_email, _password); // Will return the authentiacted user  
                }
                catch (Exception e)
                {
                    Console.Clear();
                    //Console.WriteLine(e.Message); // ONLY FOR DEBUG USAGE, WE DO NOT WANT TO SEND MORE DETAILED INFO TO END USER
                    _view.DisplayText("Wrong credentials. Try again.");
                    Thread.Sleep(2000); // sleep so user can see error msg.
                    // TODO Write errors to log file???
                }
        
                // TODO check user db for valid credentials - handle what happens on correct/incorrect
                if (loginUser.Authenticated)
                {
                    // redirects to main menu on successful login
                    MainMenu mainMenu = new();
                    MainMenuPresenter mainMenuPresenter = new(mainMenu, loginUser);
                }
                _view.Stop();
                break;
            
            case "error":
                Console.Clear();
                Console.WriteLine("Error getting input. Can't login.");
                Thread.Sleep(2000); // sleep so user can see error msg.
                _view.Stop();
                break;
        }
    }
}