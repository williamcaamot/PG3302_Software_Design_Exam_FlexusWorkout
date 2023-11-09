using FlexusWorkout.Model.Concrete;
using FlexusWorkout.Presenter;

namespace FlexusWorkout.View.MyWorkouts;

public class WorkoutView : Base.View
{
    public List<Workout> existingWorkouts { get; set; }

    public WorkoutView()
    {
        existingWorkouts = GetWorkouts();
    }
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("--My workouts--");

        foreach (var workout in existingWorkouts)
        {
            Console.WriteLine($"Name: {workout.Name}");
            Console.WriteLine($"Id: {workout.Id}");
            Console.WriteLine($"Exercises: {workout.Exercises}");
            Console.WriteLine($"Description: {workout.Description}");
            Console.WriteLine($"Type: {workout.Type}");
            Console.WriteLine($"Location: {workout.Location}");
        }
    }

    //Here should database retrival be when GetWorkouts() is implemented
    private List<Workout> GetWorkouts()
    {
        var existingWorkoutsFromDb = new List<Workout>()
        {

        };
        return existingWorkoutsFromDb;
    }
}
