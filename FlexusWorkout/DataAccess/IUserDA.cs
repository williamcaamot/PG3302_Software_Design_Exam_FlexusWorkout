using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.DataAccess;

public interface IUserDA
{
    User Add(User user);
    User Update(User user);
    User GetUserById(int id);
    User GetUserByEmail(User user);
    User GetUserByEmail(String email);
    void Delete(User user);



}