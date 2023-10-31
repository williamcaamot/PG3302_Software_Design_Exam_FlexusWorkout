namespace FlexusWorkout.View.Menu;

public abstract class Menu
{
    public Menu()
    {
        var running = true;
        while (running)
        {
            running = Run();
        }
    }
    public abstract bool Run();
}