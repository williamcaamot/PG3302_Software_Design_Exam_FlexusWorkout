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
        _exerciseService.AddExercise(strengthExercise1);
        _exerciseService.AddExercise(strengthExercise2);
        
        
        User user = new User("William", "Aamot", "william@aamot.no", "abcd");
        _userService.registerUser(user);





    }
}