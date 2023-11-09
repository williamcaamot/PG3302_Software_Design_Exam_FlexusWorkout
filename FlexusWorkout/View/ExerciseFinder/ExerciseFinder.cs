namespace FlexusWorkout.View.ExerciseFinder;

public class ExerciseFinder : Base.View
{
    // TODO Make ExerciseFinder View
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("-- Exercise Finder --");
        Console.WriteLine("Find an exercise. Select a category:");
        OnInputReceived("getcategories", "");
    }
}