namespace FlexusWorkout.View.Menu;
using Presenter;

public abstract class Menu : IView
{
    public Menu(Presenter presenter)
    {
        Presenter = presenter;
        var running = true;
        while (running)
        {
            running = Run();
        }
    }

    public Presenter Presenter { get; set; }

    protected abstract bool Run();
}