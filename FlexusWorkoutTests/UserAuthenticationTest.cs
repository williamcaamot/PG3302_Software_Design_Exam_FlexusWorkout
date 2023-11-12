using FlexusWorkout.Services;
using FlexusWorkout.Models.Concrete;

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

    [Test]
    public void AuthUserWithNonExistingEmail_ShouldThrowErrorThatUserEmailDoesntExist()
    {
        //Arrange
        User user = new User("test1","user1","test1@gmail.com","password");
        User CheckUser = new User("thisemaildoesntexist@gmail.com", "password");
        UserAuthentication userAuthentication = new();
        string errormessage = null;
        
        //Act
        try
        {
            userAuthentication.Authenticate(CheckUser);
        }
        catch (Exception e)
        {
            errormessage = e.Message;
        }
        
        //Assert
        Assert.That(errormessage, Is.EqualTo("Could not find user"));
    }
    [Test]
    public void AuthUserWithWrongPassword_ShouldThrowErrorThatPasswordIsWrong()
    {
        //Arrange
        User user = new User("test1","user1","test1@gmail.com","password");
        User CheckUser = new User("test1@gmail.com", "wrongpassword");
        UserAuthentication userAuthentication = new();
        string errormessage = null;
        
        //Act
        Service.Add(user);
        try
        {
            userAuthentication.Authenticate(CheckUser);
        }
        catch (Exception e)
        {
            errormessage = e.Message;
        }
        
        //Assert
        Assert.That(errormessage, Is.EqualTo("Input had wrong password"));
    }
}
