using System.Runtime.InteropServices.JavaScript;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ZstdSharp.Unsafe;
using View = FlexusWorkout.Views.Base.View;

namespace FlexusWorkout.Presenters.WorkoutPlanner;

public class WPPRresenterMenu : Presenter
{
    private readonly User _user;

    public WPPRresenterMenu(View view, User user) : base(view)
    {
        _user = user;
        View.Run();
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
                ShowWeekMenu showWeekMenu = new ShowWeekMenu();
                //Show the menu
                foreach (var workoutDay in _user.WorkoutDays)
                {
                    Console.WriteLine(workoutDay.Workout.Name);
                }
                Thread.Sleep(2000);
                break;
            case "2":
                //TODO create a new menu
                // First select date in the new menu
                // This new menu needs options to either create a new workout or use an exisiting
                break;
            case "error":
                Console.Clear();
                Console.WriteLine("There was an error receiving input");
                Thread.Sleep(2000);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid input, please try again");
                Thread.Sleep(2000);
                break;
        }
    }
}