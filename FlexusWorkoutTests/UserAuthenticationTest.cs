using System.Diagnostics.Contracts;
using FlexusWorkout.Model;
using FlexusWorkout.View_model.User;
using SQLitePCL;

namespace FlexusWorkoutTests;

public class UserAuthenticationTest
{
    private UserService Service;
    [OneTimeSetUp]
    public void SetUpBeforeEachTest()
    {
        Service = new UserService();
    }
    
    
    [Test]
    public void shouldAddUserToDbAndReturnSameUserWithId()
    {
        User user = new User("test","user","test@gmail.com","password");
        User addedUser = Service.Add(user);
        
        Assert.That(user.FirstName, Is.EqualTo(addedUser.FirstName));
        Assert.That(user.LastName, Is.EqualTo(addedUser.LastName));
        Assert.That(user.Email, Is.EqualTo(addedUser.Email));
        Assert.That(user.FirstName, Is.EqualTo(addedUser.FirstName));
        Assert.IsNotNull(addedUser.UserId );
    }

    [Test]
    public void shoudlAuthenticateUser()
    {
        User user = new User("test1","user1","test1@gmail.com","password");
        Service.Add(user);
        
        
        User CheckUser = new User("test1@gmail.com", "password");
        UserAuthentication userAuthentication = new();
        var autheduser = userAuthentication.AuthenticateUser(CheckUser);

        
        Console.WriteLine(user.FirstName);
        //Assert.That(user.FirstName, Is.EqualTo(autheduser.FirstName));
        Assert.IsNotNull(autheduser.FirstName);

    }
    
    

}
