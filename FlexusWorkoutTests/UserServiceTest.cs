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
    
    
    
}