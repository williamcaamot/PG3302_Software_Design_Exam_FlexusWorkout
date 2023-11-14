namespace FlexusWorkout.Models.Concrete;

public class WorkoutDay : Base.Model
{ 
    public int? WorkoutDayId { get; set; } //PK
    public Workout Workout { get; set; }
    public DateOnly Date { get; set; }

    public WorkoutDay()
    {
    }
    
}