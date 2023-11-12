using FlexusWorkout.Models;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Views.WorkoutPlanner;
using WorkoutPlanner = FlexusWorkout.Models.Concrete.WorkoutPlanner;

namespace FlexusWorkout.Presenters;

public class WorkoutPlannerPresenter
{
    private IWorkoutPlannerView _view;
    private WorkoutPlanner _workoutPlanner;
    private WorkoutPlannerMenu _menu;
    private ExerciseService _exerciseService;

    public WorkoutPlannerPresenter(IWorkoutPlannerView _view, WorkoutPlanner _workoutPlanner, WorkoutPlannerMenu _menu, ExerciseService _exerciseService)
    {
        this._menu = _menu;
        this._workoutPlanner = _workoutPlanner;
        this._view = _view;
        this._exerciseService = _exerciseService;
    }
    
    public void CreatePlan()
    {
        List<string> daysInWeek = new List<string>
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        WeeklyWorkoutPlanner weeklyPlan = new WeeklyWorkoutPlanner();

        foreach (var day in daysInWeek)
        {
            Console.WriteLine($"Creating a plan for {day}");
            
            //Retrive exercises from db
            IList<Exercise> available = _exerciseService.GetExercisesByType("Strength");

            //convert the exersices to list
            List<string> exercisesNames = available.Select(exercise => exercise.Name).ToList();
            var chooseExercise = _view.SelectExercise(day, exercisesNames);
            //_workoutPlanner.BuildWorkout(day, chooseExercise);
        }

        _menu.addWeeklyPlan(_workoutPlanner.GetWorkouts());
    }
    
    //UNDER HERE SHOULD LOGIC TO RETRIVE AVALABLE EXERCISES FROM THE DATABASE BE!!!!!!!!!!!!!!!!
    private List<string> retriveExercisesFromDB()
    {

        return new List<string>
        {
            "Exercise 1",
            "Exercise 2",
            "Exercise 3",
        };
    }
    
    
} 