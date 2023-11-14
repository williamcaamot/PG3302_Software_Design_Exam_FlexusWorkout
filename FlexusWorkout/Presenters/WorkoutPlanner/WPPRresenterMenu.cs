using System.Runtime.InteropServices.JavaScript;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ZstdSharp.Unsafe;
using View = FlexusWorkout.Views.Base.View;

namespace FlexusWorkout.Presenters.WorkoutPlanner;

public class WPPRresenterMenu : Presenter
{
    public WPPRresenterMenu(View view, Service? service = default) : base(view, service)
    {
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
                break;
            case "2":
                //todo plan a new workoutday
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