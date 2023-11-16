using FlexusWorkout.Models;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.WorkoutPlanner;
using WorkoutPlanner = FlexusWorkout.Models.Concrete.WorkoutPlanner;

namespace FlexusWorkout.Presenters.WorkoutPlanner;

public class WorkoutPlannerPresenter : Presenter
{
    private User _user;
    private FlexusDbContext _db;
    private WorkoutDay _workoutDay;

    public WorkoutPlannerPresenter(User user, View view, Service? service = default) : base(view, service)
    {
        _db = new FlexusWorkoutDbContext();
        _user = user;
        _workoutDay = new WorkoutDay();
        view.Run();
    }

    public override void HandleInput(string? key, string? input)
    {
        if (input == null)
        {
        }

        {
            MainHandler("Error");
        }
        if (input == "exit")
        {
            MainHandler(input);
        }

        switch (key)
        {
            case "date":
                if (DateOnly.TryParse(input, out DateOnly choosenDate))
                {
                    DateHandler(choosenDate);
                }
                else
                {
                    MainHandler("invalidDate");
                }

                MainHandler(input);
                break;

            case "getWorkouts":
                MainHandler("getWorkouts");
                break;
            case "workout":
                WorkoutHandler(input);
                break;
        }
    }



    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "exit":
                View.Stop();
                break;
            case "invalidDate":
                Console.Clear();
                Console.WriteLine("Error: Please try again, invalid date format ");
                Thread.Sleep(2500);
                break;
            case "getWorkouts":
                for (int i = 0; i < _user.Workouts.Count; i++)
                {
                    View.DisplayText(i + 1 + " - " + _user.Workouts[i].Name);
                }
                View.Stop();
                break;
        }

    }

    private void DateHandler(DateOnly choosenDate)
    {
        _workoutDay.Date = choosenDate;

    }

    private void WorkoutHandler(string input)
    {
        if (int.TryParse(input, out int choice))
        {
            _workoutDay.Workout = _user.Workouts[choice - 1];

        }
    }
}
   


