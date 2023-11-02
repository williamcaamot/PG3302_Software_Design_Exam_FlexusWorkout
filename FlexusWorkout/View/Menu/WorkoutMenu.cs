namespace FlexusWorkout.View.MyWorkouts;

public class WorkoutMenu : Menu.Menu
{
    // TODO Make MyWorkouts View

    protected override bool Run()
    {
        Console.Clear();
        Console.WriteLine("--Workout Menu--");
        Console.WriteLine("1 - Show existing workouts");
        Console.WriteLine("2 - Add new workout");
        Console.WriteLine("3 - Delete existing workout");
        Console.WriteLine("0 - Exit");

        switch (Console.ReadLine())
        {
            case "0":
                return false;
            case "1":
                // TODO add redirect to MyWorkout View here
                return true;
            case "2":
                // TODO add redirect to CreateWorkout View here
                return true;
            case "3":
                //TODO add view to delete
                return true;
            default:
                Console.WriteLine("Invalid option, try again.");
                return true;
        }
    }
}