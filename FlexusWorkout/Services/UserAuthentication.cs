using System.Security.Cryptography;
using System.Text;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.Services;

public class UserAuthentication
{ //TODO move this to userService
    public User Authenticate(User user) // TAKES A USER IN - AND RETURNS THE AUTHENTICATED USER IF IT IS SUCCESSFUL!
    {
        UserService userService = new(); //TODO create dependency injection on this
        
        var foundUser = userService.GetUserByEmail(user);
        if (foundUser.Email == null)
        {
            throw new Exception("Could not find user");
        }
        string hashcheck;
        using (SHA256 sha256 = SHA256.Create()) //TODO create a method on this that can be used multiple places
        {                                       // Can also be an extension method on class string, is this something we did in the project?
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            hashcheck = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
        
        if (hashcheck != foundUser.Password)
        {
            throw new Exception("Input had wrong password");
        }
        foundUser.Authenticated = true;
        return foundUser;
    }
}