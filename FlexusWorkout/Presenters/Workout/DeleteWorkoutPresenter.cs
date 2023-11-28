using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.Workout;

public class DeleteWorkoutPresenter : Presenter
{
    private User _user;
    public DeleteWorkoutPresenter(User user, View view, Service? service = default) : base(view, service)
    {
        _user = user;
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
            case "getworkouts":
                WorkoutHandler("getworkouts");
                break;
            case "input":
                WorkoutInputHandler(input);
                break;
        }
    }


    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "error":
                Console.Clear();
                View.DisplayText("There was a problem with getting your input");
                Thread.Sleep(2000);
                break;
        }
    }
    
    private void WorkoutHandler(string input)
    {
        if (input == "getworkouts") // writes menu choices to view
        {
            var workouts = _user.Workouts;
            for (int i = 0; i < workouts.Count; i++)
            {
                View.DisplayText(i + 1 + " - " + workouts[i].Name);
            }
        }
        else if (input == "invalid")
        {
            Console.Clear();
            Console.WriteLine("Invalid menu choice - try again.");
            Thread.Sleep(2000);
        }
    }
    
    private void WorkoutInputHandler(string? input)
    {
        // Handling exercises selection input
        if (int.TryParse(input, out int choice))
        {
            if (choice == 0) // Exit view
            {
                View.Stop();
            }
            else
            {
                // TODO uncomment line below with working Delete method.
                //Service.deleteWorkoutById(_user.Workouts[choice - 1]);
                View.Stop();
            }
        }
    }
}
