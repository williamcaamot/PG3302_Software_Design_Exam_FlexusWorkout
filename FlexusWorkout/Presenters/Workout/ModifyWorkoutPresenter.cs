using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.Workout;

public class ModifyWorkoutPresenter : MenuPresenter
{
    private User _user;
    public ModifyWorkoutPresenter(User user, View view, Service? service = default) : base(view)
    {
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
            case "currentlymodifying":
                MainHandler(key);
                break;
            case "input":
                MainHandler(input);
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "currentlymodifying":
                View.DisplayText("Currently modifying workout - \"" + _user.Workouts[0] + "\"");
                break;
            case "0":
                View.Stop();
                break;
            case "1":
                break;
            case "2":
                break;
            case "3":
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