
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Base;
using FlexusWorkout.Views.Workout;
using Org.BouncyCastle.Crypto.Engines;

namespace FlexusWorkout.Presenters.Workout;
using Models.Concrete;

public class CreateWorkoutPresenter : Presenter
{
    private User _user;
    private FlexusDbContext _db;
    private CreateWorkout _view;
    private ExerciseService _service;
    private Workout _workout;
    private ExerciseType _exerciseType;

    public CreateWorkoutPresenter(User user, CreateWorkout view, ExerciseService? service = default) : base(view,
        service)
    {
        _db = new FlexusWorkoutDbContext();
        _user = user;
        _service = service;
        _view = view;

        _workout = new Workout();

        // Run the View loop
        view.Run();
    }

    public override void HandleInput(string? key, string? input)
    {
        if (input == null)
        {
        }

        {
            MainHandler("error");
        }
        switch (key)
        {
            case "name":
                MainHandler("name");
                break;
            case "description":
                MainHandler("description");
                break;
            case "categoryInput":
                CategoryHandler(input);
                break;
            case "exerciseInput":
                ExerciseHandler(input);
                break;
            case "getcategories":
                CategoryHandler("getcategories");
                break;
            case "getexercises":
                ExerciseHandler("getexercises");
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "name":
                _workout.Name = input;
                break;
            case "description":
                _workout.Description = input;
                break;
            case "error":
                break;
        }
    }

    private void CategoryHandler(string? input)
    {
        if (input == "getcategories") // writes menu choices to view
        {
            var categories = GetCategories();
            for (int i = 0; i < categories.Count; i++)
            {
                View.DisplayText(i + 1 + " - " + categories[i].Name);
            }
        }
        else if (input == "invalid")
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
                }
                else
                {
                    _exerciseType = GetCategories()[choice - 1];
                    _view.DisplayExercises(_exerciseType.Name);

                }
            }
        }
    }

    private void ExerciseHandler(string? input)
    {
        {
            if (input == "getexercises") // writes menu choices to view
            {
                var exercises = _exerciseType.Exercises;
                for (int i = 0; i < exercises.Count; i++)
                {
                    View.DisplayText(i + 1 + " - " + exercises[i].Name);
                }
            }
            else if (input == "invalid")
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
                    }
                    else
                    {
                        // TODO customize?????
                        var selectedExercise = _exerciseType.Exercises[choice - 1];
                        ExerciseModifierFactory exerciseModifierFactory = new();
                        if (choice == 1)
                        {
                            exerciseModifierFactory.MakeHarder(selectedExercise);
                        }
                        else if (choice == 2)
                        {
                            exerciseModifierFactory.MakeEasier(selectedExercise);
                        }
                        else
                        {
                            //????????
                        }
                    }
                }
            }
        }
    }

    private IList<ExerciseType> GetCategories()
    {
        return _service.GetExerciseTypes();
    }
}