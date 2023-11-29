using FlexusWorkout.DataAccess;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using Moq;

namespace FlexusWorkoutTests;

public class UserServiceUnitTest
{
    private Mock<IUserDA> _mockUserDA;

    public UserServiceUnitTest()
    {
        _mockUserDA = new(MockBehavior.Default);
    }

    [Test]
    public void registerUser()
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
        
    }
    
    
    
}