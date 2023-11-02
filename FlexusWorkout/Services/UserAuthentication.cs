using System.Security.Cryptography;
using System.Text;
using FlexusWorkout.View_model.User;

namespace FlexusWorkout.Model;

public class UserAuthentication
{
    public User AuthenticateUser(User user)
    {
        UserService userService = new();
        
        
        var founduser = userService.GetUserByEmail(user);
        string hashcheck;
        
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            hashcheck = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        if (hashcheck == user.Password)
        {
            return founduser; //Returns the authenticated user
        }
        
        return new User();
    }

}