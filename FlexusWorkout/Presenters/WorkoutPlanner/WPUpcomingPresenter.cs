using ConsoleTableExt;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.WorkoutPlanner;

public class WPUpcomingPresenter : Presenter
{
    private User _user;
    public WPUpcomingPresenter(User user, View view, Service? service = default) : base(view, service)
    {
        _user = user;
        View.Run();
    }
    
    public override void HandleInput(string? key, string? input)
    {
        if (input == null)
        {
            MainHandler("error");
        }
        switch (key)
        {
            case "getWorkoutPlans":
                MainHandler("getWorkoutPlans");
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "getWorkoutPlans":
                List<object> headers = new List<object> { "Workout Name", "Workout Description", "Exercises in workout", "Date" };
                List<List<object>> tableData = new();
                tableData.Add(headers);
                foreach (var workoutDay in _user.WorkoutDays)
                {
                    string exercises = string.Join(", ", workoutDay.Workout.Exercises.Select(e => e.Name));
                    List<object> dataSet = new List<object>
                    {
                        workoutDay.Workout.Name,
                        workoutDay.Workout.Description,
                        exercises,
                        workoutDay.Date,
                    };
                    tableData.Add(dataSet);
                }
                ConsoleTableBuilder.From(tableData).WithFormat(ConsoleTableBuilderFormat.Alternative).ExportAndWriteLine();
                
                
                //todo, add implementation for a better interface. Fix underneath!!!!
                   /* ConsoleTableBuilder.From(tableData)
                        .WithFormat(ConsoleTableBuilderFormat.Alternative)
                        .WithColumnFormatter(, cell => {
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.Write(cell);
                            Console.ResetColor();
                        })
                        .ExportAndWriteLine(); */

                View.Stop();
                break;
        }
        
    }
    
}