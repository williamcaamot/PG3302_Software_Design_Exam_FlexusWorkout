using System.Net.Mail;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using FlexusWorkout.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Services;

public class UserService : Service
{
    private readonly IUserDA _userDA;

    public UserService(IUserDA iUserDa)
    {

        _userDA = iUserDa;
    }
    
    public User Add(User user)
    {
        user.Password = HashPassword(user.Password); //Need to keep this here, should not have this in DAL
        var addeduser = _userDA.Add(user);
        return addeduser;
    }
    
    public User Update(User user)
    {
        var updatedUser = _userDA.Update(user);
        return updatedUser;
    }
    

    public void Delete(User user, string password)
    {
        if (user == null)
        {
            throw new Exception("User information is not complete!");
        }
        
        var checkUser = _userDA.GetUserByEmail(user.Email);
        if (checkUser == null)
        {
            throw new Exception("Could not find user");
        }
        var checkPassword = HashPassword(password);
        if (checkUser.Password == checkPassword)
        {
            _userDA.Delete(user);    
        }
        else
        {
            throw new Exception("Password not correct!"); //Generic to not expose information to user, not that useful in our application
        }
    }
    public User GetUserByEmail(String email)
    {
        return _userDA.GetUserByEmail(email);
    }
    public User GetUserById(int id)
    {
        return _userDA.GetUserById(id);
    }
    
    private User Authenticate(User user) // TAKES A USER IN - AND RETURNS THE AUTHENTICATED USER IF IT IS SUCCESSFUL!
    {
        var foundUser = _userDA.GetUserByEmail(user);
        if (foundUser.Email == null)
        {
            throw new Exception("Could not find user");
        }
        string hashcheck = HashPassword(user.Password);
        if (hashcheck != foundUser.Password)
        {
            throw new Exception("Input had wrong password");
        }
        foundUser.Authenticated = true;
        return foundUser;
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    public User LoginUser(string email, string password) //TODO use this instead of authentication method
    {
        User user = new User(email, password);
        User authedUser = Authenticate(user);
        return authedUser;
    }
    public User RegisterUser(User user)
    {
        try //Verify that the email is in fact an email
        {
            var email = new MailAddress(user.Email);
        }
        catch (Exception e)
        {
            throw new Exception("Email is not formatted correctly");
        }

        var checkUser = _userDA.GetUserByEmail(user);
        if (checkUser.Email != null)
        {
            Console.WriteLine(checkUser.Email);
            throw new Exception("Email already exists");
        }
        var newUser = Add(user);
        newUser.Authenticated = true;
        return newUser;
    }
    public User RegisterUser(string firstname, string lastname, string email, string password, string confirmPassword)
    {
        //Check that passwords are the same
        User user = new User(firstname, lastname, email, password);
        return RegisterUser(user);
    }
    
    
}