namespace FlexusWorkout.Presenter.Base;
using Model.Base;
using View.Base;

public abstract class Presenter
{
    protected Presenter(View view, Model? model = default)
    {
        View = view;
        Model = model;
        
        // Run the View loop
        View.Run();
        
        this.View.InputReceived += HandleInput;

    }
    
    protected View View { get; set; }
    protected Model? Model { get; set; }

    public abstract void HandleInput(string? key, string? input);
    
    public abstract bool MainHandler(string? input);
}