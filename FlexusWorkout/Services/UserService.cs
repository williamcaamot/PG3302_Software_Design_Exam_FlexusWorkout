using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.Services;

public class UserService : Service
{
    private readonly FlexusDbContext _db;
    public UserService(FlexusDbContext db)
    {
        _db = db;
    }
    
    
    private User Add(User user)
    {
        user.Password = hashPassword(user.Password);
        var addeduser =_db.User.Add(user);
        _db.SaveChanges();
        return addeduser.Entity;
    }
    public User update(User user)
    {
        return new User();
    }
    
    public void delete(User user)
    {
        _db.User.Remove(user);
        _db.SaveChanges();
    }
    public User GetUserByEmail(User user)
    {
        var FoundUser = _db.User
            .Include(u => u.Workouts)
            .Include(u => u.WorkoutDays)//eager loading
            .FirstOrDefault(u => u.Email == user.Email);
        return FoundUser ?? new User();
    }
    public User getUserById(int id)
    {
        var FoundUser = _db.User
            .Include(u => u.Workouts)
            .FirstOrDefault(u => u.UserId == id);
        return FoundUser ?? null;
    }
    
    public User GetUserByEmail(String email)
    {
        var FoundUser = _db.User.FirstOrDefault(u => u.Email == email);
        return FoundUser ?? new User();
    }
    
    private User Authenticate(User user) // TAKES A USER IN - AND RETURNS THE AUTHENTICATED USER IF IT IS SUCCESSFUL!
    {
        var foundUser = GetUserByEmail(user);
        if (foundUser.Email == null)
        {
            throw new Exception("Could not find user");
        }
        string hashcheck = hashPassword(user.Password);
        if (hashcheck != foundUser.Password)
        {
            throw new Exception("Input had wrong password");
        }
        foundUser.Authenticated = true;
        return foundUser;
    }

    private string hashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    public User loginUser(string email, string password) //TODO use this instead of authentication method
    {
        User user = new User(email, password);
        User authedUser = Authenticate(user);
        return authedUser;
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
}