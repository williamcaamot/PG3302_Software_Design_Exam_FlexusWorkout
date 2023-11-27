namespace FlexusWorkout.Models.Concrete;

public class WorkoutDay : Base.Model
{
    public int? WorkoutDayId { get; set; } //PK
    public virtual Workout Workout { get; set; }
    
    public virtual User user { get; set; }
    public DateTime Date { get; set; }
    
    private Boolean _notified = false;

    public WorkoutDay()
    {
    }
    public WorkoutDay(Workout workout, DateTime date)
    {
        Workout = workout;
        Date = date;
    }
}