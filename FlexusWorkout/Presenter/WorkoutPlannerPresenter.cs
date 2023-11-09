using FlexusWorkout.Model;
using FlexusWorkout.Model.Base;
using FlexusWorkout.Model.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.View.Menu.View.WorkoutPlanner;
using FlexusWorkout.View.WorkoutPlanner;
using WorkoutPlanner = FlexusWorkout.Model.Concrete.WorkoutPlanner;

namespace FlexusWorkout.Presenter;
using Base;

public class WorkoutPlannerPresenter
{
    private IWorkoutPlannerView _view;
    private WorkoutPlanner _workoutPlanner;
    private WorkoutPlannerMenu _menu;
    private ExerciseService _exerciseService;

    public WorkoutPlannerPresenter(IWorkoutPlannerView _view, WorkoutPlanner _workoutPlanner, WorkoutPlannerMenu _menu,
        ExerciseService _exerciseService)
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

        List<string> exercisesToChooseFrom = retriveExercisesFromDB();

        Dictionary<int, string> exercisesTypes = new Dictionary<int, string>
        {
            { 1, "Strength" },
            { 2, "Cardio" },
            { 3, "Balance" }
        };
        

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