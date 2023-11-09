using System.Reflection.Metadata;
using FlexusWorkout.Services.Base;

namespace FlexusWorkout.Presenter.ExerciseFinder;

public class ExerciseFinderPresenter : Base.Presenter
{
    public ExerciseFinderPresenter(View.Base.View view, Service? service = default) : base(view, service)
    {
    }

    public override void HandleInput(string? key, string? input)
    {
        switch (key)
        {
            case "getcategories":
                
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        throw new NotImplementedException();
    }
}