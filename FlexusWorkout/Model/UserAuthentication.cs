using FlexusWorkout.View_model.User;

namespace FlexusWorkout.Model;

public class UserAuthentication
{
    public User AuthenticateUser(User user)
    {
        //Check that password & username is set before starting the auth process
        //What should be identifier/unique (in addition to ID username should probably also be unique)
        //auth based on an incoming user with password & username
        
        
        //Create user in menu for logging in and then authenticate to return something
        
        
        return new User(); // Should menu check if returned user is in fact authenticated? Or should something else be returned?
    }

}