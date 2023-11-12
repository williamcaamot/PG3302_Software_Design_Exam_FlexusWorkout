namespace FlexusWorkout.Presenters.Base;
using Services.Base;
using Views.Base;

public abstract class Presenter
{
    protected readonly View View;
    protected readonly Service? Service;
    protected Presenter(View view, Service? service = default)
    // TODO Service in constructor or model
    {
        View = view;
        Service = service;
        
        // HandleInput() subscribes to InputReceived event from view
        view.InputReceived += HandleInput;
        
        // Run the View loop
        view.Run();

    }

    // HandleInput method will listen for events and gets <key, input>
    public abstract void HandleInput(string? key, string? input);

    // A Main method for the presenter where stuff happens
    // based on input from HandleInput()
    public abstract void MainHandler(string? input);
}