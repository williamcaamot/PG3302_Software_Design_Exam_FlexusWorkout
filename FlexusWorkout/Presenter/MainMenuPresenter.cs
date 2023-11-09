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
        switch (key)
        {
            case "input":
                if (input == null)
                {
                    MainHandler("error");
                } else
                {
                    MainHandler(input);
                }
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "0":
                // Exit view
                View.Stop();
                break;
            case "1":
                // TODO add redirect to WorkoutPlanner View here
                break;
            case "2":
                //WorkoutMenuPresenter workoutMenuPresenter = new();
            case "3":
                // TODO add redirect to ExerciseFinder View here
                break;
            case "error":
                Console.Clear();
                Console.WriteLine("There was an error receiving input.");
                Thread.Sleep(2000);
                break;
            default:
                Console.Clear();
                Console.WriteLine("Invalid option, try again.");
                Thread.Sleep(2000);
                break;
        }
    }
}