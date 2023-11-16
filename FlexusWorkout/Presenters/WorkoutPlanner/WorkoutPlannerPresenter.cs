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
    private WorkoutPlannerView _view;
    private UserService _userService;

    public WorkoutPlannerPresenter(User user, WorkoutPlannerView view, Service? service = default) : base(view, service)
    {
        _view = view;
        _db = DbContextManager.Instance;
        _user = user;
        _workoutDay = new WorkoutDay();
        _userService = new UserService(_db);
        
        view.Run();
    }

    public override void HandleInput(string? key, string? input)
    {
        if (input == null)
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
                if (DateTime.TryParse(input, out DateTime choosenDate))
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
            case "checkForWorkouts":
                MainHandler("checkForWorkouts");
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
            case "checkForWorkouts":
                if (_user.Workouts.Count == 0)
                {
                    _view.DisplayNoWorkouts();
                    _view.DisplayText("\r\nPress any key to exit.");
                    Console.ReadKey();
                    _view.Stop();
                } else
                {
                    _view.DisplayPrevWorkouts();
                }
                break;
            case "getWorkouts":
                for (int i = 0; i < _user.Workouts.Count; i++)
                {
                    _view.DisplayText(i + 1 + " - " + _user.Workouts[i].Name);
                }
                _view.Stop();
                break;
        }

    }

    private void DateHandler(DateTime choosenDate)
    {
        _workoutDay.Date = choosenDate;

    }

    private void WorkoutHandler(string input)
    {
        if (int.TryParse(input, out int choice))
        {
            _workoutDay.Workout = _user.Workouts[choice - 1];
            _user.WorkoutDays.Add(_workoutDay);
            _user = _userService.update(_user);
        }
    }
}
   


