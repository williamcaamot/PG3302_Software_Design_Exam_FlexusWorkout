using System.Security.Cryptography;
using System.Text;
using FlexusWorkout.Model.Base.User;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FlexusWorkout.Model;

public class UserService
{
    
    private readonly FlexusWorkoutDbContext _db;

    public UserService() //TODO NEED TO EDIT THIS TO USE DEPENDENCY INJECTION
    {
        _db = new();
    }
    //TODO move this and use dependency injection from a wrapper class or something similar? The DBCOntext should be initialized elsewhere
    //to make sure we don't have connections here
    
    public User Add(User user)
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

    public User GetUserByEmail(User user)
    {
        var FoundUser = _db.User.FirstOrDefault(u => u.Email == user.Email);
        return FoundUser ?? new User();
    }
    
    public User update(User user)
    {
        return new User();
    }
    
    public void delete(int id)
    {
        
    }
}