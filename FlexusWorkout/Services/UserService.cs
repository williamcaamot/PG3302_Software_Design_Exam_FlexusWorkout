using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Services;

public class UserService : Service
{
    private readonly FlexusWorkoutDbContext _db;

    public UserService() //TODO NEED TO EDIT THIS TO USE DEPENDENCY INJECTION
    
    {
        _db = new();
    }
    //TODO move this and use dependency injection from a wrapper class or something similar? The DBCOntext should be initialized elsewhere
    //to make sure we don't have connections here


    
    public User loginUser(string email, string password) //TODO use this instead of authentication method
    {
        UserAuthentication userAuthentication = new();
        User user = new User(email, password);
        User authedUser = userAuthentication.Authenticate(user);
        return authedUser;
    }
    
    public User GetUserByEmail(User user)
    {
        var FoundUser = _db.User.FirstOrDefault(u => u.Email == user.Email);
        return FoundUser ?? new User();
    }
    public User GetUserByEmail(String email)
    {
        var FoundUser = _db.User.FirstOrDefault(u => u.Email == email);
        return FoundUser ?? new User();
    }
    
    private User Add(User user)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            String hashPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            user.Password = hashPassword;
        }
        var addeduser =_db.User.Add(user);
        _db.SaveChanges();
        return addeduser.Entity;
    }
    public User registerUser(User user)
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
    
    
    
    public User update(User user)
    {
        return new User();
    }
    
    public void delete(int id)
    {
        
    }
}