using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.Workout;
using Models.Concrete;

public class MyWorkoutsPresenter : Presenter
{
    private readonly User _user;

    public MyWorkoutsPresenter(User user, View view) : base(view)
    {
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
            case "getworkouts":
                MainHandler("getworkouts");
                break;
            case "input":
                int choice;
                if (int.TryParse(input, out choice))
                {
                    if (0 <= choice && choice <= _user.Workouts.Count())
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
                    Console.WriteLine($"Workout Name:    {_user.Workouts[choice - 1].Name}");
                    Console.WriteLine($"Description:     {_user.Workouts[choice - 1].Description}");
                    Console.WriteLine($"Exercises:");
                    Console.WriteLine($"{"Exercise Type",-15} {"Name",-20} {"Description", -80}  {"Duration (minutes)",-20} {"Sets",-5} {"Reps",-5} {"Intensity",-10}");
                    Console.WriteLine(new string('-', 150)); // Creates a separator line

                    foreach (var exercise in _user.Workouts[choice - 1].Exercises)
                    {
                        Console.WriteLine($"{exercise.Type,-15} {exercise.Name,-20} {exercise.Description, -80} {exercise.DurationInMinutes, -20} {exercise.Sets,-5}  {exercise.Repetitions,-5}  {exercise.IntensityLevel,-10}");
                    }
                    View.DisplayText("\r\nPress any key to exit.");
                    
                    Console.ReadKey();
                }
            }
        }
    }
}