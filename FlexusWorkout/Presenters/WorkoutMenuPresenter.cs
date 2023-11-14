using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Presenters.Workout;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.Workout;
using ModifyWorkout = FlexusWorkout.Views.Workout.ModifyWorkout;

namespace FlexusWorkout.Presenters;

public class WorkoutMenuPresenter : MenuPresenter
{
    private User _user;
    private FlexusDbContext _db;
    public WorkoutMenuPresenter(View view, User user) : base(view)
    {
        _db = DbContextManager.Instance;;
        _user = user;
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
                WorkoutService workoutService = new(_db);
                CreateWorkout createWorkout = new();
                CreateWorkoutPresenter createWorkoutPresenter = new(_user, createWorkout, workoutService);
                break;
            case "3":
                ModifyWorkout modifyWorkout = new();
                ModifyWorkoutPresenter modifyWorkoutPresenter = new(_user, modifyWorkout);
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