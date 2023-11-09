using FlexusWorkout.Model.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkoutTests;
public class UserServiceTest
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
    public void RegisterUserCorrectly_ShouldReturnRegisteredUser()
    {
        // Arrange
        User user = new User("test","user","test@gmail.com","password");
        User registeredUser;
        
        //Act
        registeredUser = Service.registerUser(user);
        
        // Assert
        Assert.That(registeredUser.UserId != null);
    }
    
    [Test]
    public void RegisterUserWithWrongEmailFormat_ShouldThrowError()
    {
        // Arrange
        User user = new User("test","user","test.com","password");
        User registeredUser;
        string errorMessage = null;
        
        //Act
        try
        {
            registeredUser = Service.registerUser(user);
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
        }
        
        // Assert
        Assert.That(errorMessage == "Email is not formatted correctly");
    }
    [Test]
    public void RegisterUserWithExistingEmail_ShouldThrowError()
    {
        // Arrange
        User user1 = new User("test","user","test.com","password");
        User user = new User("test","user","test.com","password");
        User registeredUser;
        string errorMessage = null;
        
        //Act
        Service.registerUser(user1);
        
        try
        {
            registeredUser = Service.registerUser(user);
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
        }
        
        // Assert
        Assert.That(errorMessage == "Email already exists");
    }

    
    
}