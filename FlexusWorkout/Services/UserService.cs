using FlexusWorkout.View_model.User;

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
    
    public User add(User user)
    {
        _db.User.Add(user);
        _db.SaveChanges();
        Console.WriteLine("Added user");
        return new User();
    }
    
    public User update(User user)
    {
        return new User();
    }
    
    public void delete(int id)
    {
        
    }

    public User getUserById(int id)
    {
        return new User();
    }
    public IList<User> getAllUsers()
    {
        IList<User> users = new List<User>();
        return users;
    }
}