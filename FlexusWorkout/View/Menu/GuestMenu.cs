namespace FlexusWorkout.View.Menu;

public class GuestMenu : Menu
{
    public override bool Run()
    {
        Console.Clear();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1 - Look up an exercise");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "0":
                return false;
            case "1":
                Console.WriteLine("To look-up exercise");
                return true;
            default:
                Console.WriteLine("Invalid option, try again.");
                return true;
        }
    }
}