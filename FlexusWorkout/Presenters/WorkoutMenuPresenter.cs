using System.Diagnostics;
using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Presenters.Workout;
using FlexusWorkout.Services;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.Workout;

namespace FlexusWorkout.Presenters;

public class WorkoutMenuPresenter : MenuPresenter
{
    private User _user;
    private IFlexusDbContext _db;
    private MySqlExerciseDA _mySqlExerciseDa;
    public WorkoutMenuPresenter(View view, User user) : base(view)
    {
        _db = DbContextManager.Instance;
        _user = user;
        _mySqlExerciseDa = new(_db);
        // Run the View loop
        view.Run();
    }

    public override void HandleInput(string? key, string? input)
    {
        if (input == null)
        {
            MainHandler("error");
        }
        switch (key)
        {
            case "input":
                MainHandler(input);
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "0":
                View.Stop();
                break;
            case "1":
                MyWorkouts myWorkouts = new();
                MyWorkoutsPresenter myWorkoutsPresenter = new(_user, myWorkouts);
                break;
            case "2":
                ExerciseService exerciseService = new(_mySqlExerciseDa);
                CreateWorkout createWorkout = new();
                CreateWorkoutPresenter createWorkoutPresenter = new(_user, createWorkout, exerciseService);
                break;
            case "3":
                DeleteWorkout deleteWorkout = new();
                DeleteWorkoutPresenter deleteWorkoutPresenter = new(_user, deleteWorkout);
                break;
            case "error":
                Console.Clear();
                Console.WriteLine("There was en error getting your input.");
                Thread.Sleep(2000);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid option, try again.");
                Thread.Sleep(2000);
                break;
        }
    }
}