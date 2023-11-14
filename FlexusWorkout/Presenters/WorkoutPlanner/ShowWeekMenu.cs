namespace FlexusWorkout.Presenters.WorkoutPlanner;
using ConsoleTableExt;

public class ShowWeekMenu //Option 1 in WPPResenterMenu
{
    public void DisplayMenu()
    {
        var tableData = new List<List<object>>
            { 
                new List<object>   {"Monday", "Thuesday", "Wedensday", "Thursday", "Friday", "Saturday", "Sunday" }, 
                new List<object>   { "Test", "Test", "Test", "Test", "Test", "Test", "Test" },
        };

        ConsoleTableBuilder.From(tableData).WithFormat(ConsoleTableBuilderFormat.Default).ExportAndWriteLine();
            
    }

    
}
