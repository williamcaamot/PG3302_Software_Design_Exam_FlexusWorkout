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

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "0":
                View.Stop();
                break;
            case "1":
                // TODO add redirect to WorkoutPlanner View here
                Console.WriteLine("To workout planner");
                break;
            case "2":
                //WorkoutMenuPresenter workoutMenuPresenter = new();
            case "3":
                // TODO add redirect to ExerciseFinder View here
                Console.WriteLine("To look-up exercise");
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                break;
        }
    }
}