using FlexusWorkout;
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
        FlexusWorkoutDbContext flexusWorkoutDbContext = new();
        
        _userService = new UserService(flexusWorkoutDbContext);
        _workoutService = new WorkoutService(flexusWorkoutDbContext);
        _exerciseService = new ExerciseService(flexusWorkoutDbContext);

        
        DatabaseFiller databaseFiller = new();
        //databaseFiller.FillUsers();
        //databaseFiller.FillExercises();
        
    }

    [Test]
    public void exerciseTest()
    {


        User workoutUser = _userService.GetUserByEmail("test6@example.com");
        
        //Now both user and exercises are added to DB, now create a new workout 
        Workout workout = new Workout(
            "NewWorkout",
            "This is a cool workout",
            "Strength",
            "Gym")
        {
            User = workoutUser
        };
        //workout.User = user;

        workout = _workoutService.addWorkout(workout);


        Console.WriteLine(workout.WorkoutId);
        
    }
}