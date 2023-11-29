using FlexusWorkout.DataAccess;
using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkoutTests.Integration_test;

public class UserServiceTest
{
    private UserService _userService;
    private ExerciseService _exerciseService;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        MySqlUserDA mySqlUserDa= new MySqlUserDA(new MySqlFlexusDbContext());
        _userService = new UserService(mySqlUserDa);

    }
    
    [Test]
    public void RegisterUser_ShouldReturnUserWithValidID()
    {
        // Arange
        User user = new User("test","user","test1@gmail.com","password");
        
        // Act
        User addedUser = _userService.RegisterUser(user);
        
        // Assert
        Assert.That(user.FirstName, Is.EqualTo(addedUser.FirstName));
        Assert.That(user.LastName, Is.EqualTo(addedUser.LastName));
        Assert.That(user.Email, Is.EqualTo(addedUser.Email));
        Assert.That(addedUser.UserId, Is.GreaterThan(-1));
        
        //Cleanup
        _userService.Delete(addedUser, "password");
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
            registeredUser = _userService.RegisterUser(user);
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
             registeredUser = _userService.RegisterUser(user1);
             
             try
             {
                 _userService.RegisterUser(user);
             }
             catch (Exception e)
             {
                 errorMessage = e.Message;
             }
             
             // Assert
             Assert.That(errorMessage == "Email already exists");
             
             
             //Cleanup
             _userService.Delete(registeredUser, "password");
             
    }

    [Test]
    public void addUserWithWorkouts_GettingUserShouldReturnUserWithWorkouts()
    {
        //Arrange
        User user = new User("test","user","test1@gmail.com","password");
        Workout workout = new Workout("Test Workout", "Cool Workout");

        



        //Act


        //Assert



        //Cleanup
        //Delete user
    }
    
    
    
}