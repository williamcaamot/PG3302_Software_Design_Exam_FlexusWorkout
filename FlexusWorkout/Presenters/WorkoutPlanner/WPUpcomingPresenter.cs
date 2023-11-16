using ConsoleTableExt;
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
                List<List<object>> tableData = new();
                foreach (var workoutDay in _user.WorkoutDays)
                {
                    List<object> dataSet = new List<object>
                    {

                        workoutDay.Workout.Name,
                    };
                tableData.Add(dataSet);
                }
                ConsoleTableBuilder.From(tableData).WithFormat(ConsoleTableBuilderFormat.Alternative).ExportAndWriteLine(TableAligntment.Center);
                View.Stop();
                break;
        }
        
    }
    
}