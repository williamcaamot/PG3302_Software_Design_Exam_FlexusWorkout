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
                List<object> data;
                foreach (var workoutDay in _user.WorkoutDays)
                {
                    //data = {workoutDay.Workout.Name}
                    tableData.Add(new List<object>{workoutDay.Workout.Name,});
                }

                ConsoleTableBuilder.From(tableData).WithFormat(ConsoleTableBuilderFormat.Default).ExportAndWriteLine();
                
                View.Stop();
                break;
        }
    }
}