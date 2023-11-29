using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkoutTests;

public class WorkoutDayUnitTest
{
    private Workout _workout;
    [OneTimeSetUp]
    public void WorkoutDayUnitTestSetup()
    {
        Exercise exercise1 = new BalanceExercise("Balance", "Stretchy Stretcher", "An exercise that challenges your stretching abilites", 15, 8,
            "Yoga studio");
        Exercise exercise2 = new BalanceExercise("Balance", "Flexy Pose", "A pose that isn't your typical yoga pose, very challenging but also fun.",
            10, 6, "Yoga studio");

        _workout = new Workout();
        _workout.Name = "Balance workout";
        _workout.Description = "A pretty unusual balance workout!";
        _workout.Exercises.Add(exercise1);
        _workout.Exercises.Add(exercise2);
    }
    
    
    
    [Test]
    public void CreateWorkoutDay_WithWorkoutContainingExercises()
    {
        //Arrange
        DateTime date = DateTime.Parse("24-12-2023");
        Workout workout = _workout;
        
        //Act
        WorkoutDay workoutDay = new WorkoutDay(workout, date); //DD/MM/YYYY is output with time
        
        //Assert
        Assert.That((workoutDay.Date.ToString().Split(" ")[0]), Is.EqualTo("24/12/2023"));
        Assert.That(workoutDay.Workout.Description, Is.EqualTo("A pretty unusual balance workout!"));
        Assert.That(workoutDay.Workout.Name, Is.EqualTo("Balance workout"));
        Assert.That(workoutDay.Workout.Exercises[0].Name, Is.EqualTo("Stretchy Stretcher"));
        Assert.That(workoutDay.Workout.Exercises[0].Description, Is.EqualTo("An exercise that challenges your stretching abilites"));
        Assert.That(workoutDay.Workout.Exercises[1].Name, Is.EqualTo("Flexy Pose"));
        Assert.That(workoutDay.Workout.Exercises[1].Description, Is.EqualTo("A pose that isn't your typical yoga pose, very challenging but also fun."));
    }
}