using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkoutTests;

public class UserUnitTest //USER UNIT TESTS = DONE 
{
    [Test]
    public void CreateUser()
    {
        // Arrange
        string firstname = "Flexus";
        string lastname = "BigBoy";
        string email = "flexusi@bigboy.com";
        string password = "SuperAdvancedPassword123";

        
        //Act
        User user = new User(firstname, lastname, email, password);
        
        //Assert
        Assert.That(user.FirstName, Is.EqualTo(firstname));
        Assert.That(user.LastName, Is.EqualTo(lastname));
        Assert.That(user.Email, Is.EqualTo(email));
        Assert.That(user.Password, Is.EqualTo(password));
        Assert.That(user.GetFullName(), Is.EqualTo("Flexus BigBoy"));
    }

    
    [Test]
    public void CreateUser_AndAddWorkout()
    {
        // Arrange
        string firstname = "Flexus";
        string lastname = "BigBoy";
        string email = "flexusi@bigboy.com";
        string password = "SuperAdvancedPassword123";

        Exercise exercise1 = new BalanceExercise("Balance", "Stretchy Stretcher", "An exercise that challenges your stretching abilites", 15, 8,
            "Yoga studio");
        Exercise exercise2 = new BalanceExercise("Balance", "Flexy Pose", "A pose that isn't your typical yoga pose, very challenging but also fun.",
            10, 6, "Yoga studio");

        Workout workout = new Workout();
        workout.Exercises.Add(exercise1);
        workout.Exercises.Add(exercise2);
        
        //Act
        User user = new User(firstname, lastname, email, password);
        user.Workouts.Add(workout);
        
        //Assert
        Assert.That(user.Workouts.Count, Is.EqualTo(1));
        Assert.That(user.Workouts[0].Exercises.Count, Is.EqualTo(2));
        Assert.That(user.Workouts[0].Exercises[0].Name, Is.EqualTo("Stretchy Stretcher"));
        Assert.That(user.Workouts[0].Exercises[1].Name, Is.EqualTo("Flexy Pose"));
    }

    [Test]
    public void CreateUser_AddWorkoutDay()
    {
        // Arrange
        string firstname = "Flexus";
        string lastname = "BigBoy";
        string email = "flexusi@bigboy.com";
        string password = "SuperAdvancedPassword123";

        Exercise exercise1 = new BalanceExercise("Balance", "Stretchy Stretcher", "An exercise that challenges your stretching abilites", 15, 8,
            "Yoga studio");
        Exercise exercise2 = new BalanceExercise("Balance", "Flexy Pose", "A pose that isn't your typical yoga pose, very challenging but also fun.",
            10, 6, "Yoga studio");

        Workout workout = new Workout();
        workout.Name = "Seriously heavy balance workout!";
        workout.Exercises.Add(exercise1);
        workout.Exercises.Add(exercise2);

        WorkoutDay workoutDay = new WorkoutDay(workout, DateTime.Parse("21-12-2019"));
        
        //Act
        User user = new User(firstname, lastname, email, password);
        user.Workouts.Add(workout);
        user.WorkoutDays.Add(workoutDay);
        
        Assert.That(user.WorkoutDays.Count, Is.EqualTo(1));
        Assert.That(user.WorkoutDays[0].Date, Is.EqualTo(DateTime.Parse("21-12-2019")));
        Assert.That(user.WorkoutDays[0].Workout.Name, Is.EqualTo("Seriously heavy balance workout!"));
        Assert.That(user.WorkoutDays[0].Workout.Exercises[0].Name, Is.EqualTo("Stretchy Stretcher"));
        Assert.That(user.WorkoutDays[0].Workout.Exercises[1].Name, Is.EqualTo("Flexy Pose"));
    }
}