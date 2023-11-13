using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;


namespace FlexusWorkout.Presenters.ExerciseFinder;

public class ExerciseFinderPresenter : Base.Presenter
{
    private readonly ExerciseService _exerciseService;
    public ExerciseFinderPresenter(View view, ExerciseService service) : base(view, service)
    {
        _exerciseService = service;
        // Run the View loop
        view.Run();
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
                    View.DisplayText(i + 1 + " - " + categories[i].Name);
                }
                break;
        }
    }

    public IList<ExerciseType> GetCategories()
    {
        var categories = _exerciseService.getExerciseTypes();
        return categories;
    }
}
