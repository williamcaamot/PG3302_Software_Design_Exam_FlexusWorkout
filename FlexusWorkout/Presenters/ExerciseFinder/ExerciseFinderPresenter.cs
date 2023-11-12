using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;


namespace FlexusWorkout.Presenters.ExerciseFinder;

public class ExerciseFinderPresenter : Base.Presenter
{
    public ExerciseFinderPresenter(View view, Service? service = default) : base(view, service)
    {
    }

    public override void HandleInput(string? key, string? input)
    {
        if (input == null) 
        {
            MainHandler("error");
            return;
        }
        switch (key)
        {
            case "getcategories":
                MainHandler("getcategories");
                break;
            case "input":
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "getcategories":
                var categories = GetCategories();
                for (int i = 0; i < categories.Count; i++)
                {
                    View.DisplayText(i + 1 + " - " + categories[i]);
                }
                break;
        }
    }

    public IList<string> GetCategories()
    {
        ExerciseService exerciseService = new();
        var categories = exerciseService.getExerciseTypes();
        return categories;
    }
}
