using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Presenters.ExerciseFinder;
using FlexusWorkout.Services;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.ExerciseFinder;

namespace FlexusWorkout.Presenters;

public class GuestMenuPresenter : MenuPresenter
{
    private readonly IFlexusDbContext _flexusWorkoutDbContext;
    public GuestMenuPresenter(View view) : base(view)
    {
        _flexusWorkoutDbContext = DbContextManager.Instance;
        // Run the View loop
        view.Run();
    }


    public override void HandleInput(string? key, string? input)
    {
        if (input == null)
        {
            MainHandler("error");
            return;
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
                ExerciseService exerciseService = new(_flexusWorkoutDbContext);
                ExerciseFinderMenu exerciseFinderMenu = new();
                ExerciseFinderPresenter exerciseFinderPresenter = new(exerciseFinderMenu, exerciseService);
                break;
            case "error":
                Console.Clear();
                Console.WriteLine("There was en error getting your input.");
                Thread.Sleep(2000);
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                break;
        }
    }
}