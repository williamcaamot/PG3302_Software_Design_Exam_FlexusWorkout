using FlexusWorkout.DataAccess;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using Moq;

namespace FlexusWorkoutTests;

public class UserServiceUnitTest
{

    private Mock<IUserDA> _mockUserDA;
    [SetUp]
    public void SetUp()
    {
        _mockUserDA = new(MockBehavior.Default);    
    }

    [Test]
    public void registerUser_shouldReturnSameUserWithoutPassword()
    {
        //Arrange
        _mockUserDA.Setup(m => m.GetUserByEmail(It.IsAny<User>())).Returns(new User());
        _mockUserDA.Setup(m => m.Add(It.IsAny<User>()))
            .Callback((User user) => user.UserId = 1)
            .Returns((User user) => user);
        UserService userService = new UserService(_mockUserDA.Object);
        User user = new User("Test", "User", "test@user.com", "abcd");
        
        //Act
        var registeredUser = userService.RegisterUser(user);

        //Assert
        Assert.That(registeredUser.FirstName, Is.EqualTo(user.FirstName));
        Assert.That(registeredUser.LastName, Is.EqualTo(user.LastName));
        Assert.That(registeredUser.Email, Is.EqualTo(user.Email));
        Assert.That(registeredUser.GetFullName(), Is.EqualTo(user.GetFullName()));
        Assert.That(registeredUser.Authenticated, Is.True);
        
        _mockUserDA.VerifyAll();
        
    }
    
    [Test]
    public void registerUser_ShouldThrowErrorEmailNotFormatCorrectly()
    {
        //Arrange
        UserService userService = new UserService(_mockUserDA.Object);
        User user = new User("Test", "User", "thisIsNotACorrectEmail", "abcd");
        String errorMessage = "";
        
        //Act
        try
        {
            var registeredUser = userService.RegisterUser(user);
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
        }

        //Assert
        Assert.That(errorMessage, Is.EqualTo("Email is not formatted correctly"));
        _mockUserDA.VerifyAll();
        
    }
    
    
    

    [Test]
    public void loginUser_ShouldThrowExceptionUserNotFound()
    {
        //Arrange
        _mockUserDA.Setup(m => m.GetUserByEmail(It.IsAny<User>())).Returns(new User());
        UserService userService = new UserService(_mockUserDA.Object);
        string errorMessage = "";
        
        //Act
        try
        {
            userService.LoginUser("test@flexus.no", "abcd");
        }
        catch (Exception e)
        {
            errorMessage = e.Message;
        }
        
        //Assert
        Assert.That(errorMessage, Is.EqualTo("Could not find user"));
        
        _mockUserDA.VerifyAll();
    }
    
    [Test]
    public void loginUser_ShouldReturnUserLoggedIn()
    {
        //Arrange
        List<User> users = new List<User> { new User("coolio", "userio", "coolio@flexus.no", "abcd") };
        
        _mockUserDA.Setup(m => m.Add(It.IsAny<User>()))
            .Callback((User user) => users.Add(user))
            .Returns((User user) => user);
        _mockUserDA.Setup(m => m.GetUserByEmail(It.IsAny<User>())).Returns(
            (User inputUser) => inputUser.Email == users.Last().Email ? users.Last() : new User()
            );
        User user = new User("Test", "User", "test@user.com", "abcd");
        UserService userService = new UserService(_mockUserDA.Object);
        
        //Act
        var registeredUser = userService.RegisterUser(user);
        var loggedInUSer = userService.LoginUser("test@user.com", "abcd");
        
        
        //Assert
        Assert.That(loggedInUSer.Authenticated, Is.True);
        Assert.That(registeredUser.Authenticated, Is.True);
        Assert.That(loggedInUSer.FirstName, Is.EqualTo("Test"));
        Assert.That(loggedInUSer.LastName, Is.EqualTo("User"));
        Assert.That(loggedInUSer.Email, Is.EqualTo("test@user.com"));
        
        
        _mockUserDA.VerifyAll();
    }
}