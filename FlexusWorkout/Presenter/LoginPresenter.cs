using FlexusWorkout.Services.Base;
using FlexusWorkout.View.Menu;

namespace FlexusWorkout.Presenter;
using Base;
using Model.Concrete;
using Services;

public class LoginPresenter : Presenter
{
    private string? _email;
    private string? _password;
    public LoginPresenter(View.Base.View view, Service service) : base(view, service)
    {
        
    }

    // TODO Add LoginPresenter
    public override void HandleInput(string? key, string? input)
    {
        switch (key)
        {
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
                UserAuthentication userAuthentication = new();

                loginUser.Email = _email;
                loginUser.Password = _password;
                
                try
                {
                    loginUser = userAuthentication.Authenticate(loginUser); // Will return the authentiacted user    
                }
                catch (Exception e)
                {
                    Console.Clear();
                    //Console.WriteLine(e.Message); // ONLY FOR DEBUG USAGE, WE DO NOT WANT TO SEND MORE DETAILED INFO TO END USER
                    Console.WriteLine("Wrong credentials. Try again.");
                    Thread.Sleep(2000); // sleep so user can see error msg.
                    // TODO Write errors to log file???
                }
        
                // TODO check user db for valid credentials - handle what happens on correct/incorrect
                if (loginUser.Authenticated)
                {
                    // redirects to main menu on successful login
                    // TODO load user profile somehow (main menu takes in a user object?)
                    MainMenu mainMenu = new();
                    MainMenuPresenter mainMenuPresenter = new(mainMenu);
                }
                View.Stop();
                break;
            
            case "error":
                Console.Clear();
                Console.WriteLine("Error getting input. Can't login.");
                Thread.Sleep(2000); // sleep so user can see error msg.
                View.Stop();
                break;
        }
    }
}