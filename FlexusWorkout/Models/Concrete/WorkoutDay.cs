namespace FlexusWorkout.Models.Concrete;

public class WorkoutDay : Base.Model
{
    public int? WorkoutDayId { get; set; } //PK
    public virtual Workout Workout { get; set; }
    public DateTime Date { get; set; }
    
    private User user { get; set; }

    public WorkoutDay()
    {
    }
    public WorkoutDay(Workout workout, DateTime date)
    {
        Workout = workout;
        Date = date;
    }
}