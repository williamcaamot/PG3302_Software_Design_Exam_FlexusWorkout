using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.ExerciseFinder;


namespace FlexusWorkout.Presenters.ExerciseFinder;

public class ExerciseFinderPresenter : Base.Presenter
{
    private readonly ExerciseService _exerciseService;
    public ExerciseFinderPresenter(View view, ExerciseService service) : base(view, service)
    {
        _exerciseService = service;
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
            case "getcategories":
                MainHandler("getcategories");
                break;
            case "input":
                int choice;
                if (int.TryParse(input, out choice))
                {
                    if (0 <= choice && choice <= GetCategories().Count)
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
        if (input == "getcategories") // writes menu choices to view
        {
            var categories = GetCategories();
            for (int i = 0; i < categories.Count; i++)
            {
                View.DisplayText(i + 1 + " - " + categories[i].Name);
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
                    ExerciseSelector exerciseSelector = new();
                    ExerciseSelectorPresenter eSP = new(GetCategories()[choice - 1], exerciseSelector, _exerciseService);
                }
            }
        }
    }

    public IList<ExerciseType> GetCategories()
    {
        var categories = _exerciseService.GetExerciseTypes();
        return categories;
    }
}
