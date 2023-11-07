namespace FlexusWorkout.View.Base;
using Presenter.Base;

public abstract class View
{

    public void Run()
    // Starts the loop
    {
        var running = true;
        while (running)
        {
            running = Display();
        }
    }
    
    // This abstract method is where the view displays text to the console
    protected abstract bool Display();

    //protected abstract void OnInputReceived(string input);

}