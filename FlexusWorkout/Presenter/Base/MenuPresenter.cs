namespace FlexusWorkout.Presenter.Base;

public abstract class MenuPresenter : Presenter
{
    // Regular menus doesn't need a model, so this class makes sure
    // menus won't have to pass one.
    public MenuPresenter(View.Base.View view) : base(view, null)
    {
        
    }
    
}