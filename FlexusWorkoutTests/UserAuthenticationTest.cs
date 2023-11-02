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
    public void AddUser_ShouldReturnUserWithValidID()
    {
        // Arange
        User user = new User("test","user","test@gmail.com","password");
        
        // Act
        User addedUser = Service.Add(user);
        
        // Assert
        Assert.That(user.FirstName, Is.EqualTo(addedUser.FirstName));
        Assert.That(user.LastName, Is.EqualTo(addedUser.LastName));
        Assert.That(user.Email, Is.EqualTo(addedUser.Email));
        Assert.That(addedUser.UserId, Is.GreaterThan(-1));
    }

    [Test]
    public void AuthUser_ShouldReturnUserWithFullDetails()
    {
        // Arrange
        User user = new User("test1","user1","test1@gmail.com","password");
        User CheckUser = new User("test1@gmail.com", "password");
        UserAuthentication userAuthentication = new();
        
        // Act
        Service.Add(user);
        var AuthenticatedUser = userAuthentication.Authenticate(CheckUser);
        
        // Assert
        Assert.That(AuthenticatedUser.FirstName, Is.EqualTo(user.FirstName));
        Assert.That(AuthenticatedUser.LastName, Is.EqualTo(user.LastName));
        Assert.That(AuthenticatedUser.Email, Is.EqualTo(user.Email));
        Assert.That(AuthenticatedUser.UserId, Is.GreaterThan(-1));
        Assert.That(AuthenticatedUser.Authenticated, Is.True);
    }
}
