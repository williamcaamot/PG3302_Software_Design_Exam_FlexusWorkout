using Microsoft.VisualBasic;

namespace FlexusWorkout.View_model.WorkoutPlanner;

public class WorkoutSession
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateAndTime Date { get; set; }

    public WorkoutSession(string name, string description, DateAndTime date)
    {
        Name = name;
        Description = description;
        Date = date;
    }
}