using Microsoft.VisualBasic;

namespace FlexusWorkout.View_model.WorkoutPlanner;

public class WorkoutSession
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public WorkoutSession(string name, string description, DateTime date)
    {
        Name = name;
        Description = description;
        Date = date;
    }

    
    public override string ToString()
    {
        return $"{Name}, {Date}, {Description}";
    }
}