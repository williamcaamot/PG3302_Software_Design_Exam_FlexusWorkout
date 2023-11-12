using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace FlexusWorkoutTests;

public class WorkoutTest
{
    private UserService _userService;
    private WorkoutService _workoutService;
    private ExerciseService _exerciseService;

    [SetUp]
    public void insertData()
    {
        _userService = new UserService();
        _workoutService = new WorkoutService();
        _exerciseService = new ExerciseService();
    }

    [Test]
    public void exerciseTest()
    {
        StrengthExercise strengthExercise1 = new StrengthExercise("Strength", "Deadlift", "A compound movement that works the back, glutes, and legs.", null,
            8, 3, "Barbell", 5, "Gym");
        StrengthExercise strengthExercise2 = new StrengthExercise("Strength", "Squats", "A lower body exercise focusing on the thighs, hips, and buttocks.",
            null, 12, 3, "Barbell", 4, "Gym");
        strengthExercise1 = (StrengthExercise)_exerciseService.AddExercise(strengthExercise1);
        strengthExercise2 = (StrengthExercise)_exerciseService.AddExercise(strengthExercise2);
        
        User user = new User("William", "Aamot", "william@aamot.no", "abcd");
        try
        {
            user = _userService.registerUser(user);
        }
        catch (Exception e)
        {
            
        }
        
        
        
        Console.WriteLine(user.UserId);
        
        
        
        //Now both user and exercises are added to DB, now create a new workout 
        Workout workout = new Workout(
            "NewWorkout",
            "This is a cool workout",
            "Strength",
            "Gym")
        {
            User = _userService.GetUserByEmail("william@aamot.no")
        };
        //workout.User = user;

        workout = _workoutService.addWorkout(workout);
        
        
        
        var user2 = _userService.GetUserByEmail("william@aamot.no");

        foreach (var potatoe in user2.Workouts)
        {
            Console.WriteLine(potatoe.WorkoutId);
            Console.WriteLine(potatoe.User.FirstName);
        }
    }
}