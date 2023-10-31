using FlexusWorkout.View_model.User;

namespace FlexusWorkout.Model;

public class UserCrud
{
    private FlexusWorkoutDbContext _flexusWorkoutDbContext = new();
    //TODO move this and use dependency injection from a wrapper class or something similar? The DBCOntext should be initialized elsewhere
    //to make sure we don't have connections here
    
    public User add(User user)
    {
        _flexusWorkoutDbContext.Users.Add(user);
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
    public IList<User> getAllusers()
    {
        IList<User> users = new List<User>();
        return users;
    } 
}