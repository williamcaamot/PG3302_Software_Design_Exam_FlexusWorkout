using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Decorator.Factories;
using FlexusWorkout.Decorator.Factories.Base;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services;
using FlexusWorkout.Views.Workout;

namespace FlexusWorkout.Presenters.Workout;
using Models.Concrete;

public class CreateWorkoutPresenter : Presenter
{
    private User _user;
    private CreateWorkout _view;
    private ExerciseService _service;
    private Workout _workout;
    private ExerciseType _exerciseType;
    private Exercise _selectedExercise;
    private DecoratorFactory? _decoratorFactory;
    private ExerciseDecoratorFactory? _exerciseDecoratorFactory;
    private readonly UserService _userService;
    private string _workoutName;
    private string _workoutDescription;

    public CreateWorkoutPresenter(User user, CreateWorkout view, ExerciseService? service = default) : base(view,
        service)
    {
        var db = DbContextManager.Instance;
        _user = user;
        _service = service;
        _view = view;
        var mySqlUserDa = new MySqlUserDA(db);
        _userService = new UserService(mySqlUserDa);

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
                _workoutName = input;
                MainHandler("name");
                break;
            case "description":
                _workoutDescription = input;
                MainHandler("description");
                break;
            case "categoryInput":
                CategoryInputHandler(input);
                break;
            case "exerciseInput":
                ExerciseInputHandler(input);
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
                if (input == "1")
                {
                    MainHandler("yes");
                } else if (input == "2")
                {
                    MainHandler("no");
                } else
                {
                   MainHandler("invalid"); 
                }
                break;
            case "showDecoratorInfo":
                MainHandler(key);
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "name":
                _workout.Name = _workoutName;
                break;
            case "description":
                _workout.Description = _workoutDescription;
                break;
            case "yes":
                // go to exercise selection again
                _view.DisplayCategories();
                break;
            case "no":
                try
                {
                    _user.Workouts.Add(_workout);
                    _user = _userService.Update(_user);
                    _view.DisplayText("Successfully added workout!"); //TODO SHOULD PROABLY CHANGE THIS TO SOMETHING BETTER
                    _view.DisplayText("Returning...");
                    Thread.Sleep(2000);
                }
                catch (Exception e)
                {
                    _view.DisplayText($"An error occured");
                    _view.DisplayText(e.Message);
                    Thread.Sleep(2000);
                }
                break;
            case "showDecoratorInfo":
                if (_selectedExercise.Type == "Strength")
                {
                    _view.DisplayText("Current repetitions: " + _selectedExercise.Repetitions);
                    _view.DisplayText("Current sets: " + _selectedExercise.Sets);   
                } else if (_selectedExercise.Type == "Cardio")
                {
                    _view.DisplayText("Current intensity level: " + _selectedExercise.IntensityLevel);
                } else if (_selectedExercise.Type == "Balance")
                {
                    _view.DisplayText("Current duration (minutes): " + _selectedExercise.DurationInMinutes);   
                }
                break;
            case "error":
                Console.Clear();
                _view.DisplayText("There was a problem with getting your input");
                Thread.Sleep(2000);
                break;
        }
    }
    
    private IList<ExerciseType> GetCategories()
    {
        return _service.GetExerciseTypes();
    }
    
    private void CategoryHandler(string? input)
    {
        if (input == "getcategories") // writes menu choices to view
        {
            var categories = GetCategories();
            for (int i = 0; i < categories.Count; i++)
            {
                _view.DisplayText(i + 1 + " - " + categories[i].Name);
            }
        }
        else if (input == "invalid")
        {
            Console.Clear();
            Console.WriteLine("Invalid menu choice - try again.");
            Thread.Sleep(2000);
        }
    }
    
    private void CategoryInputHandler(string? input)
    {
        if (int.TryParse(input, out int choice))
        {
            if (choice == 0) // Exit view
            {
                View.Stop();
            } else // TODO fix errors when giving wrong input
            {
                _exerciseType = GetCategories()[choice - 1];
                _view.DisplayExercises(_exerciseType.Name);
            }
        }
    }

    private void ExerciseHandler(string? input)
    {
        if (input == "getexercises") // writes menu choices to view
        {
            var exercises = _exerciseType.Exercises;
            for (int i = 0; i < exercises.Count; i++)
            {
                View.DisplayText(i + 1 + " - " + exercises[i].Name);
            }
        }
    }


    private void ExerciseInputHandler(string input)
    {
        // Handling exercises selection input
        if (int.TryParse(input, out int choice))
        {
            if (choice == 0) // Exit view
            {
                _view.Stop();
            } else // TODO fix errors when giving wrong input
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
                _decoratorFactory = new DecoratorFactory(_selectedExercise);
                _exerciseDecoratorFactory = _decoratorFactory.CreateFactory();
                _selectedExercise = _exerciseDecoratorFactory.MakeHarder();
                _view.DisplayDecoratingChoices();
                break;
            case "2":
                // Decorate easier
                _decoratorFactory = new DecoratorFactory(_selectedExercise);
                _exerciseDecoratorFactory = _decoratorFactory.CreateFactory();
                _selectedExercise = _exerciseDecoratorFactory.MakeEasier();
                _view.DisplayDecoratingChoices();
                break;
            case "3":
                // Keep exercise
                if (_selectedExercise.Standard == false)
                {
                    try
                    {
                        _selectedExercise = _service.AddExercise(_selectedExercise);
                        _workout.Exercises.Add(_service.GetExercise(_selectedExercise.ExerciseId));
                    }
                    catch (Exception e)
                    {
                        _view.DisplayText(e.Message);
                    }
                }
                else
                {
                    try
                    {
                        _workout.Exercises.Add(_service.GetExercise(_selectedExercise.ExerciseId));
                    }
                    catch (Exception e)
                    {
                        _view.DisplayText(e.Message);
                    }
                }
                _view.DisplayAddMore();
                break;
        }
    }
}