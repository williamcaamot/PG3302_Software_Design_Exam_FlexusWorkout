namespace FlexusWorkout.View.Menu;

public class GuestMenu : Base.View
{
    
    protected override bool Display()
    {
        Console.Clear();
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1 - Look up an exercise");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an option: ");

        //return Presenter.InputHandler(Console.ReadLine());
        return false;
    }
}