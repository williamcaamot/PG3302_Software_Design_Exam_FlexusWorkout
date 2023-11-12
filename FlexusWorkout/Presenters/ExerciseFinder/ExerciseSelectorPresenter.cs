using FlexusWorkout.Models.Base;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.ExerciseFinder;

public class ExerciseSelectorPresenter : Presenter
{
    private readonly string _type;

    public ExerciseSelectorPresenter(string type, View view, Service? service = default) : base(view, service)
    {
        _type = type;
        // Run the View loop
        view.Run();
    }

    public override void HandleInput(string? key, string? input)
    {
        if (input == null)
        {
            MainHandler("error");
        }

        switch (key)
        {
           case "getexercises":
               MainHandler("getexercises");
               break;
           case "input":
               MainHandler(input);
               break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "getexercises":
                var exercises = GetExercises();
                for (int i = 0; i < exercises.Count; i++)
                {
                    View.DisplayText(i + 1 + " - " + exercises[i].Name);
                }
                break;
        }
            
    }

    private IList<Exercise> GetExercises()
    {
        ExerciseService exerciseService = new();
        var exercises = exerciseService.GetExercisesByType(_type);
        return exercises;
    }
}