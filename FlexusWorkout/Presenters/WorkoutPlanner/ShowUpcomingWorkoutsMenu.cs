namespace FlexusWorkout.Presenters.WorkoutPlanner;
using ConsoleTableExt;

public class ShowUpcomingWorkoutsMenu
{
    public static void DisplayMenu(List<Models.Concrete.Workout> workouts)
    {
        var tableData = new List<List<object>>
            { 
                new List<object>   {"Should", "be", "dates", "off", "upcoming", "workouts", "here" }, 
                
        };
        foreach (var workout in workouts)
        {
            tableData.Add(new List<object>{workout.Name});
        }

        ConsoleTableBuilder.From(tableData).WithFormat(ConsoleTableBuilderFormat.Default).ExportAndWriteLine();
            
    }

    
}
