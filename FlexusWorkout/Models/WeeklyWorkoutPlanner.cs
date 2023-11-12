using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Models;
public class WeeklyWorkoutPlanner
{

    public int IdOfPlan { get; set; }
    public int UserId { get; set; }
    public List<Exercise> Exercises { get; set; }
    public DayOfWeek unknownDay { get; set; }
    
    public WeeklyWorkoutPlanner()
    {
        Exercises = new List<Exercise>();
    }

    public WeeklyWorkoutPlanner(string day, List<Exercise> exercises)
    {
        unknownDay = Enum.Parse<DayOfWeek>(day);
        Exercises = exercises;
    }
}