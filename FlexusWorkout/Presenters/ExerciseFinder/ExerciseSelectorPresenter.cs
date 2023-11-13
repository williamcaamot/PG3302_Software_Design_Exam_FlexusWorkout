using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.ExerciseFinder;

public class ExerciseSelectorPresenter : Presenter
{
    private readonly ExerciseType _type;
    private FlexusWorkoutDbContext _flexusWorkoutDbContext;

    public ExerciseSelectorPresenter(ExerciseType type, View view, Service? service = default) : base(view, service)
    {
        _flexusWorkoutDbContext = new();
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
            case "0":
                View.Stop();
                break;
        }
            
    }

    private IList<Exercise> GetExercises()
    {
        ExerciseService exerciseService = new(_flexusWorkoutDbContext);
        var exercises = exerciseService.GetExercisesByType(_type.Name);
        return exercises;
    }
}