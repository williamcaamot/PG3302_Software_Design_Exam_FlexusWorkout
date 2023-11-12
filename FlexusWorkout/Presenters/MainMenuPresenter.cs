<<<<<<< Updated upstream:FlexusWorkout/Presenter/MainMenuPresenter.cs
using FlexusWorkout.Model.Concrete;

namespace FlexusWorkout.Presenter;
using View.Menu;
using Base;

public class MainMenuPresenter : MenuPresenter
{

    private User _user;
    public MainMenuPresenter(View.Base.View view, User user) : base(view)
=======
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Presenters.ExerciseFinder;
using FlexusWorkout.Services;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.ExerciseFinder;

namespace FlexusWorkout.Presenters;

public class MainMenuPresenter : MenuPresenter
{
    public MainMenuPresenter(View view) : base(view)
>>>>>>> Stashed changes:FlexusWorkout/Presenters/MainMenuPresenter.cs
    {
        _user = user;
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
                // Exit view
                View.Stop();
                break;
            case "1":
                // TODO add redirect to WorkoutPlanner View here
                break;
            case "2":
                // TODO add redirect to WorkoutMenu here
                //WorkoutMenuPresenter workoutMenuPresenter = new();
            case "3":
                ExerciseService exerciseService = new();
                ExerciseFinderMenu exerciseFinderMenu = new();
                ExerciseFinderPresenter exerciseFinderPresenter = new(exerciseFinderMenu, exerciseService);
                break;
            case "error":
                Console.Clear();
                Console.WriteLine("There was an error receiving input.");
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