using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.DataAccess;

public interface IUserDA
{
    User Add(User user);
    
}