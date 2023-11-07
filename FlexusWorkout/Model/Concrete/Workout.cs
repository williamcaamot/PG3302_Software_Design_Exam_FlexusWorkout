using FlexusWorkout.Model.Base;

namespace FlexusWorkout.Model.Concrete;

public class Workout
{
    public string Day { get; set; }
    public List<Exercise> Exercises { get; set; }


    public Workout(string setDay)
    {
        Day = setDay;
        Exercises = new List<Exercise>();
    }

    public Workout()
    {
        throw new NotImplementedException();
    }
}