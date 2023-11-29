using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace FlexusWorkout.DataAccess;

public class MySqlUserDA : IUserDA
{
    private IFlexusDbContext _db;
    public MySqlUserDA(IFlexusDbContext db)
    {
        _db = db;
    }
    
    public User Add(User user)
    {
        var addeduser =_db.User.Add(user);
        _db.SaveChanges();
        addeduser.Entity.Password = null;
        return addeduser.Entity;
    }

    public User Update(User user)
    {
        try
        {
            var updatedUser = _db.User.Update(user);
            _db.SaveChanges();
            updatedUser.Entity.Password = null;
            return updatedUser.Entity;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public User GetUserById(int id)
    {
        var FoundUser = _db.User
            .Include(u => u.Workouts)
            .FirstOrDefault(u => u.UserId == id);
        FoundUser.Password = null;
        return FoundUser ?? new User();
    }

    public User GetUserByEmail(User user)
    {
        var FoundUser = _db.User
            .Include(u => u.Workouts)
            .Include(u => u.WorkoutDays)//eager loading
            .FirstOrDefault(u => u.Email == user.Email);
        FoundUser.Password = null;
        return FoundUser ?? new User();
    }

    public User GetUserByEmail(string email)
    {
        var FoundUser = _db.User.FirstOrDefault(u => u.Email == email);
        FoundUser.Password = null;
        return FoundUser ?? new User();
    }

    public void Delete(User user)
    {
        _db.User.Remove(user);
        _db.SaveChanges();
    }
}