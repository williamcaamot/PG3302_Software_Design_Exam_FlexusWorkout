using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace FlexusWorkoutTests.mock;

public class UserServiceMockTest
{
    private UserService userService;
    private Mock<FlexusDbContext> dbContextMock;

    [SetUp]
    public void SetUpBeforeEachTest()
    {
        // Arrange
        dbContextMock = new Mock<FlexusDbContext>();
        userService = new UserService(dbContextMock.Object);
    }
    
    
    [Test]
    public void RegisterUser_ShouldReturnUserWithValidID()
    {
        // Arrange
        var user = new User("test", "user", "test1@gmail.com", "password");

        // Mocking the behavior of the DbContext
        var dbSetMock = new Mock<DbSet<User>>();

        
        
        //dbContextMock.Setup(d => d.User).Returns(dbSetMock.Object);

        // Act
        
        var addedUser = userService.registerUser(user);
        
        Console.WriteLine(user);
        Console.WriteLine(addedUser);
        // Assert
        Assert.That(user.FirstName, Is.EqualTo(addedUser.FirstName));
        Assert.That(user.LastName, Is.EqualTo(addedUser.LastName));
        Assert.That(user.Email, Is.EqualTo(addedUser.Email));
        Assert.That(addedUser.UserId, Is.GreaterThan(0));
    }
}