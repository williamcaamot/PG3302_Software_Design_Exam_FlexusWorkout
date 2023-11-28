using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using FlexusWorkout.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Services;

public class UserService : Service
{
    private readonly MySqlUserDA _mySqlUserDa;

    public UserService(MySqlUserDA mySqlUserDa)
    {

        _mySqlUserDa = mySqlUserDa;
    }
    
    public User Add(User user)
    {
        user.Password = HashPassword(user.Password); //Need to keep this here, should not have this in DAL
        var addeduser = _mySqlUserDa.Add(user);
        return addeduser;
    }
    
    public User Update(User user)
    {
        var updatedUser = _mySqlUserDa.Update(user);
        return updatedUser;
    }
    

    public void Delete(User user)
    {
        _mySqlUserDa.Delete(user);
    }
    public User GetUserByEmail(User user)
    {
        return _mySqlUserDa.GetUserByEmail(user);
    }
    public User GetUserByEmail(String email)
    {
        return _mySqlUserDa.GetUserByEmail(email);
    }
    public User GetUserById(int id)
    {
        return _mySqlUserDa.GetUserById(id);
    }
    
    private User Authenticate(User user) // TAKES A USER IN - AND RETURNS THE AUTHENTICATED USER IF IT IS SUCCESSFUL!
    {
        var foundUser = GetUserByEmail(user);
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

        var checkUser = GetUserByEmail(user);
        if (checkUser.Email != null)
        {
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