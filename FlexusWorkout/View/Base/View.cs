namespace FlexusWorkout.View.Base;

public abstract class View
{   
    // Event for handling input
    public event Action<string, string> InputReceived;
    private bool _running;

    public void Run()
    // Starts the loop
    {
        _running = true;
        while (_running)
        {
            Display();
        }
    }
    
    // Method for stopping loop
    public void Stop()
    {
        _running = false;
    }
    
    // This abstract method is where the view displays text to the console
    protected abstract void Display();


    protected void OnInputReceived(string key, string input)
    {
        // Raise event when this method is called
        InputReceived?.Invoke(key, input);
    }

}