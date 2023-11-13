using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Presenters.Workout;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.Workout;

namespace FlexusWorkout.Presenters;

public class WorkoutMenuPresenter : MenuPresenter
{
    private User _user;
    private FlexusDbContext _db;
    public WorkoutMenuPresenter(View view, User user) : base(view)
    {
        _db = new FlexusWorkoutDbContext();
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
                // TODO add redirect to CreateWorkout View here
                break;
            case "3":
                //TODO add view to delete
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