
using FlexusWorkout.Models.Base;
using FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Workout;

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
    private Exercise _selectedExercise;
    private ExerciseModifierFactory _exerciseModifierFactory;
    private UserService _userService;

    public CreateWorkoutPresenter(User user, CreateWorkout view, ExerciseService? service = default) : base(view,
        service)
    {
        _db = DbContextManager.Instance;
        _exerciseModifierFactory = new ExerciseModifierFactory();
        _user = user;
        _service = service;
        _view = view;
        _userService = new UserService(_db);

        _workout = new Workout();

        // Run the View loop
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
            case "decoratingChoice":
                DecoratorHandler(input);
                break;
            case "addMore":
                MainHandler(input);
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
            case "yes":
                // go to exercise selection again
                _view.DisplayCategories();
                break;
            case "no":
                _user.Workouts.Add(_workout);
                _user = _userService.update(_user);
                break;
            case "error":
                Console.Clear();
                _view.DisplayText("There was a problem with getting your input");
                Thread.Sleep(2000);
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
        }
    }

    private IList<ExerciseType> GetCategories()
    {
        return _service.GetExerciseTypes();
    }

    private void ExerciseInputHandler(string input)
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
                _selectedExercise = _exerciseType.Exercises[choice - 1];
                _view.DisplayDecoratingChoices();
            }
        }
    }

    private void DecoratorHandler(string input)
    {
        switch (input)
        {
            case "1":
                // Decorate harder
                _selectedExercise = _exerciseModifierFactory.MakeHarder(_selectedExercise);
                _view.DisplayDecoratingChoices();
                break;
            case "2":
                // Decorate easier
                _selectedExercise = _exerciseModifierFactory.MakeEasier(_selectedExercise);
                _view.DisplayDecoratingChoices();
                break;
            case "3":
                // Keep exercise
                _workout.Exercises.Add(_selectedExercise);
                _view.DisplayAddMore();
                break;
        }
    }
}