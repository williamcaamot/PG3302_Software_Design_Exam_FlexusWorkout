using FlexusWorkout.DataAccess;
using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
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
        MySqlFlexusDbContext mySqlFlexusDbContext = new();
        MySqlUserDA mySqlUserDa= new MySqlUserDA(mySqlFlexusDbContext);
        MySqlExerciseDA mySqlExerciseDa = new MySqlExerciseDA(mySqlFlexusDbContext);
        _userService = new UserService(mySqlUserDa);
        _exerciseService = new ExerciseService(mySqlExerciseDa);
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
        Exercise exercise1 = _exerciseService.GetRandomExercise("Strength");
        Exercise exercise2 = _exerciseService.GetRandomExercise("Strength");

        workout.Exercises.Add(exercise1);
        workout.Exercises.Add(exercise2);
        
        //Act
        var addedUser = _userService.RegisterUser(user);
        addedUser.Workouts.Add(workout);
        var updatedUser = _userService.Update(user);

        //Assert
        
        Assert.That(updatedUser.Workouts[0].Exercises[0].Name, Is.EqualTo(exercise1.Name));
        Assert.That(updatedUser.Workouts[0].Exercises[1].Name, Is.EqualTo(exercise2.Name));
        Assert.That(updatedUser.Workouts[0].Exercises[0].Description, Is.EqualTo(exercise1.Description));
        Assert.That(updatedUser.Workouts[0].Exercises[1].Description, Is.EqualTo(exercise2.Description));

        //Cleanup
        _userService.Delete(updatedUser, "password");
    }
    
    
    [Test]
    public void addUserWithWorkoutDay_ShouldReturnUserWithWorkoutDays()
    {
        //Arrange
        User user = new User("test","user","test1@gmail.com","password");
        Workout workout = new Workout("Test Workout", "Cool Workout");
        Exercise exercise1 = _exerciseService.GetRandomExercise("Strength");
        Exercise exercise2 = _exerciseService.GetRandomExercise("Strength");
        WorkoutDay workoutDay = new WorkoutDay(workout, DateTime.Parse("21-12-2019"));

        workout.Exercises.Add(exercise1);
        workout.Exercises.Add(exercise2);
        
        //Act
        var addedUser = _userService.RegisterUser(user);
        addedUser.Workouts.Add(workout);
        addedUser.WorkoutDays.Add(workoutDay);
        var updatedUser = _userService.Update(user);

        //Assert
        Assert.That(updatedUser.Workouts[0].Exercises[0].Name, Is.EqualTo(exercise1.Name));
        Assert.That(updatedUser.Workouts[0].Exercises[1].Name, Is.EqualTo(exercise2.Name));
        Assert.That(updatedUser.Workouts[0].Exercises[0].Description, Is.EqualTo(exercise1.Description));
        Assert.That(updatedUser.Workouts[0].Exercises[1].Description, Is.EqualTo(exercise2.Description));
        
        Assert.That(updatedUser.WorkoutDays[0].Workout.Name, Is.EqualTo("Test Workout"));
        Assert.That(updatedUser.WorkoutDays[0].Workout.Description, Is.EqualTo("Cool Workout"));

        //Cleanup
        _userService.Delete(updatedUser, "password");
    }
}