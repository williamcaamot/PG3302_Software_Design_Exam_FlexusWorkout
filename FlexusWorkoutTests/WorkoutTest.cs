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
        databaseFiller.FillExercises();
        
    }

    [Test]
    public void exerciseTest()
    {
        //Getting user
        User workoutUser = _userService.GetUserByEmail("test6@example.com");
        
        //Create new workout with user from database 
        Workout workout = new Workout(
            "NewWorkout",
            "This is a cool workout",
            "Strength",
            "Gym")
        {
            User = workoutUser
        };
        Exercise exercise = _exerciseService.GetExercise(1);
        
        
        //Save workout to DB
        workout = _workoutService.addWorkout(workout);

        //Write ID of new workout
        Console.WriteLine(workout.WorkoutId);

        
        workout.Exercises.Add(exercise);
        _workoutService.updateWorkout(workout);
        


        Console.WriteLine(workout.Exercises[0].ExerciseId);

    }
}