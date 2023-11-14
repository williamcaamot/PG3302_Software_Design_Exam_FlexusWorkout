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
    

   public WorkoutPlannerPresenter(User user, View view, Service? service = default ) : base(view, service)
   {
       _db = new FlexusWorkoutDbContext();
       _user = user;
       view.Run();
   } 
   
   public override void HandleInput(string? key, string? input)
   {
       if (input == null){}
       {
           MainHandler("Error");
       }
       switch (key)
       {
           case "input":
               MainHandler(input);
               break;
       }
       
   }

   public override void MainHandler(string? input)
   {
       switch (input)
       {
           case "0": 
               View.Stop();
               break;
           case "1":
               IWorkoutPlannerView.ExtendedWorkoutPlannerView extendedWorkoutPlannerView =
                   new IWorkoutPlannerView.ExtendedWorkoutPlannerView();
               //extendedWorkoutPlannerView
               //
           break;
       }
           
   }
    

    public void CreatePlan()
    {
        List<string> daysInWeek = new List<string>
            { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        // might delte l8ter ? :))))/////List<string> exercisesToChooseFrom = retriveExercisesFromDB();
       /* IList<Exercise> getAll = _exerciseService
        List<string> exerciseNames = getAll.Select(e => e.Name).ToList();

        foreach (var exercises in getAll)
        {
            Console.WriteLine($"Id: {exercises.ExerciseId}, Name: {exercises.Name}, Type: {exercises.Type}");
        }  */
        

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