using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.ExerciseFinder;

public class ExerciseSelectorPresenter : Presenter
{
    private readonly ExerciseType _type;
    private readonly MySqlExerciseDA _mySqlExerciseDa;

    public ExerciseSelectorPresenter(ExerciseType type, View view, Service? service = default) : base(view, service)
    {
        MySqlFlexusDbContext db = new();
        _mySqlExerciseDa = new(db);
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
        if (input == "getexercises")
        {
            var exercises = GetExercises();
            for (int i = 0; i < exercises.Count; i++)
            {
                View.DisplayText(i + 1 + " - " + exercises[i].Name);
            }
        } else if (input == "error")
        {
            Console.Clear();
            Console.WriteLine("There was an error receiving input.");
            Thread.Sleep(2000);
        } else
        {
            if (int.TryParse(input, out int choice))
            {
                if (choice == 0) // Exit view
                {
                    View.Stop();
                } else
                {
                    Console.Clear();
                    Console.WriteLine(GetExercises()[choice - 1]);
                    Console.WriteLine("\r\nPress any key to exit.");
                    Console.ReadKey();
                }
            }
        }
    }

    private IList<Exercise> GetExercises()
    {
        try
        {
            ExerciseService exerciseService = new(_mySqlExerciseDa);
            var exercises = exerciseService.GetExercisesByType(_type.Name);
            return exercises;
        }
        catch (Exception e)
        {
            Console.WriteLine("lold"); //TODO FIX THIS TO USE THE VIEW TO PRINT SOMETHING USEFUL TO THE USER?
            return null;
        }
        
    }
}