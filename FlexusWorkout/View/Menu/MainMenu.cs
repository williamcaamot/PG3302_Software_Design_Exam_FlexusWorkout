namespace FlexusWorkout.View.Menu;

public class MainMenu : Base.View
{

    protected override bool Display()
    {
        Console.Clear();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1 - Access Workout-planner");
        Console.WriteLine("2 - See my workouts");
        Console.WriteLine("3 - Find an exercise");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: ");

        //return Presenter.InputHandler(Console.ReadLine());
        return false;
    }
}
