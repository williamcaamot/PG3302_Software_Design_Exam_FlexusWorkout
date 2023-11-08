namespace FlexusWorkout.Presenter.Base;
using Model.Base;
using View.Base;

public abstract class Presenter
{
    protected readonly View View;
    protected readonly Model Model;
    protected Presenter(View view, Model? model = default)
    {
        View = view;
        Model = model;
        
        view.InputReceived += HandleInput;
        
        // Run the View loop
        view.Run();

    }

    public abstract void HandleInput(string? key, string? input);
    
    public abstract void MainHandler(string? input);
}