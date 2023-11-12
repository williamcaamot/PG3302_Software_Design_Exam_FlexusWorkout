using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.Base;

public abstract class MenuPresenter : Presenter
{
    // Regular menus doesn't need a model, so this class makes sure
    // menus won't have to pass one.
    public MenuPresenter(View view) : base(view, null)
    {
        
    }
    
}