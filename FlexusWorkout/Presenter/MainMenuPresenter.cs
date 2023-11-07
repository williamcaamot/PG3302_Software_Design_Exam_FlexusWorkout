namespace FlexusWorkout.Presenter;
using View.Menu;
using Base;

public class MainMenuPresenter : MenuPresenter
{
    public MainMenuPresenter(View.Base.View view) : base(view)
    {
    }

    public override void HandleInput(string? key, string? input)
    {
        throw new NotImplementedException();
    }

    public override bool MainHandler(string? input)
    {
        switch (input)
        {
            case "0":
                return false;
            case "1":
                // TODO add redirect to WorkoutPlanner View here
                Console.WriteLine("To workout planner");
                return true;
            case "2":
                //WorkoutMenuPresenter workoutMenuPresenter = new();
                return true;
            case "3":
                // TODO add redirect to ExerciseFinder View here
                Console.WriteLine("To look-up exercise");
                return true;
            default:
                Console.WriteLine("Invalid option, try again.");
                return true;
        }
    }
}