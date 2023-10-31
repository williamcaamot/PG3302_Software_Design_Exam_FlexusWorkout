using FlexusWorkout.View_model.User;

namespace FlexusWorkout.Model;

public class UserCrud
{
    public User add(User user)
    {
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