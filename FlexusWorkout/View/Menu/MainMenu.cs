namespace FlexusWorkout.View.Menu;

public class MainMenu : Menu
{
    public override bool Run()
    {
        Console.Clear();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1 - Access Workout-planner");
        Console.WriteLine("2 - See my workouts");
        Console.WriteLine("3 - Look up an exercise");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "0":
                return false;
            case "1":
                Console.WriteLine("To workout planner");
                return true;
            case "2":
                Console.WriteLine("To my workouts");
                return true;
            case "3":
                Console.WriteLine("To look-up exercise");
                return true;
            default:
                Console.WriteLine("Invalid option, try again.");
                return true;
        }
    }
}
