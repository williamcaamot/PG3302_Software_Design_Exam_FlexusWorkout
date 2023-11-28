using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Presenters.ExerciseFinder;
using FlexusWorkout.Presenters.WorkoutPlanner;
using FlexusWorkout.Services;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.ExerciseFinder;
using FlexusWorkout.Views.Menu;
using FlexusWorkout.Views.WorkoutPlanner;

namespace FlexusWorkout.Presenters;

public class MainMenuPresenter : MenuPresenter
{
    private User _user;
    private MySqlFlexusDbContext _mySqlFlexusDbContext;
    public MainMenuPresenter(View view, User user) : base(view)
    {
        _mySqlFlexusDbContext = DbContextManager.Instance;
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
            case "greetuser":
                MainHandler("greetuser");
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
            case "greetuser":
                View.DisplayText("What would you like to do, " + _user.GetFullName() + "?");
                break;
            case "0":
                // Exit view
                View.Stop();
                break;
            case "1":
                WorkoutPlannerMenu workoutPlannerMenu = new();
                WPPRresenterMenu wppRresenterMenu = new(workoutPlannerMenu, _user);
                break;
            case "2":
                WorkoutMenu workoutMenu = new();
                WorkoutMenuPresenter workoutMenuPresenter = new(workoutMenu, _user);
                break;
            case "3":
                ExerciseService exerciseService = new(_mySqlFlexusDbContext);
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