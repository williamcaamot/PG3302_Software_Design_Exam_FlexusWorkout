using FlexusWorkout.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkoutTests.Integration_test;

public class UserServiceTest
{
    private UserService _service;
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        MySqlUserDA mySqlUserDa= new MySqlUserDA(new MySqlFlexusDbContext());
        _service = new UserService(mySqlUserDa);
    }
    
    [Test]
    public void RegisterUser_ShouldReturnUserWithValidID()
    {
        // Arange
        User user = new User("test","user","test1@gmail.com","password");
        
        // Act
        User addedUser = _service.RegisterUser(user);
        
        // Assert
        Assert.That(user.FirstName, Is.EqualTo(addedUser.FirstName));
        Assert.That(user.LastName, Is.EqualTo(addedUser.LastName));
        Assert.That(user.Email, Is.EqualTo(addedUser.Email));
        Assert.That(addedUser.UserId, Is.GreaterThan(-1));
        
        //Cleanup
        _service.Delete(addedUser, "password");
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
            registeredUser = _service.RegisterUser(user);
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
             User user1 = new User("test","user","test3@test.com","password");
             User user = new User("test","user","test3@test.com","password");
             User registeredUser;
             string errorMessage = null;
             
             //Act
             _service.RegisterUser(user1);
             
             try
             {
                 registeredUser = _service.RegisterUser(user);
             }
             catch (Exception e)
             {
                 errorMessage = e.Message;
             }
             
             // Assert
             Assert.That(errorMessage == "Email already exists");
         }
}