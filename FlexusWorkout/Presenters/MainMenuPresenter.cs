using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Presenters.ExerciseFinder;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.ExerciseFinder;
using FlexusWorkout.Views.Menu;

namespace FlexusWorkout.Presenters;

public class MainMenuPresenter : MenuPresenter
{
    private User _user;
    private FlexusWorkoutDbContext _flexusWorkoutDbContext;
    public MainMenuPresenter(View view, User user) : base(view)
    {
        _flexusWorkoutDbContext = new();
        _user = user;
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
                // Exit view
                View.Stop();
                break;
            case "1":
                // TODO add redirect to WorkoutPlanner View here
                break;
            case "2":
                // TODO add redirect to WorkoutMenu here
                WorkoutMenu workoutMenu = new();
                WorkoutMenuPresenter workoutMenuPresenter = new(workoutMenu);
                break;
            case "3":
                ExerciseService exerciseService = new(_flexusWorkoutDbContext);
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