namespace FlexusWorkout.Presenter;
using View.Menu;

public class MainMenuPresenter : Presenter
{
    public override bool InputHandler(string? input)
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
                WorkoutMenuPresenter workoutMenuPresenter = new();
                WorkoutMenu workoutMenu = new(workoutMenuPresenter);
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