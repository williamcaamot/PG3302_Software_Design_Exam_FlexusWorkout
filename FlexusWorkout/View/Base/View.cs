namespace FlexusWorkout.View.Base;
using Presenter.Base;

public abstract class View
{   
    // Event for handling input
    public event Action<string, string> InputReceived;

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

    protected void OnInputReceived(string key, string input)
    {
        // Raise event when this method is called
        InputReceived?.Invoke(key, input);
    }

}