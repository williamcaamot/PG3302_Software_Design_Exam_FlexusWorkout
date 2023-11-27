namespace FlexusWorkout.Models.Concrete;

public class WorkoutDay : Base.Model
{
    public int? WorkoutDayId { get; set; } //PK
    public virtual Workout Workout { get; set; }
    
    public virtual User user { get; set; }
    public DateTime Date { get; set; }

    public Boolean Notified { get; set; } = false;

    public WorkoutDay()
    {
    }
    public WorkoutDay(Workout workout, DateTime date)
    {
        Workout = workout;
        Date = date;
    }
}