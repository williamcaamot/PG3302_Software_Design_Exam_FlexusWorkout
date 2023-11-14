using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.Workout;
using Models.Concrete;

public class MyWorkoutsPresenter : Presenter
{
    private readonly User _user;
    private readonly WorkoutService? _workoutservice;
    public MyWorkoutsPresenter(User user, View view, WorkoutService? service = default) : base(view, service)
    {
        _user = user;
        _workoutservice = service;
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
            case "getworkouts":
                MainHandler("getworkouts");
                break;
            case "input":
                int choice;
                if (int.TryParse(input, out choice))
                {
                    if (0 <= choice && choice <= GetWorkouts().Count)
                    {
                        MainHandler(input);
                    } else
                    {
                        MainHandler("invalid");
                    }
                } else
                {
                    MainHandler("invalid");
                } 
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        if (input == "getworkouts") // writes menu choices to view
        {
            var workouts = _user.Workouts;
            for (int i = 0; i < workouts.Count; i++)
            {
                View.DisplayText(i + 1 + " - " + workouts[i].Name);
            }


        } else if (input == "error")
        {
            Console.Clear();
            Console.WriteLine("There was an error receiving input.");
            Thread.Sleep(2000);
        } else if (input == "invalid")
        {
            Console.Clear();
            Console.WriteLine("Invalid menu choice - try again.");
            Thread.Sleep(2000);
        }
        else
        {
            if (int.TryParse(input, out int choice))
            {
                if (choice == 0) // Exit view
                {
                    View.Stop();
                } else
                {
                    // TODO Display that workout somehow here
                    // using GetWorkouts()[choice - 1] as reference to workout object of choice
                }
            }
        }
    }

    private IList<Workout> GetWorkouts()
    {
        // TODO make this return statement work. (add GetWorkouts(_user)
        //return _workoutservice.GetWorkouts(_user);
 return null;
    }
}