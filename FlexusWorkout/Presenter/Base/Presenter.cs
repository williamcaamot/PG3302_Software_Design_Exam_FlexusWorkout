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
    }

    protected View View { get; set; }
    protected Model? Model { get; set; }
    
    public abstract bool InputHandler(string? input);
}