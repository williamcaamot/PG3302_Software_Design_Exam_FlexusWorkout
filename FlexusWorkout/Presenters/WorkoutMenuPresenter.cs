using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters;

public class WorkoutMenuPresenter : MenuPresenter
{
    public WorkoutMenuPresenter(View view) : base(view)
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
                // TODO add redirect to MyWorkout View here
                break;
            case "2":
                // TODO add redirect to CreateWorkout View here
                break;
            case "3":
                //TODO add view to delete
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                break;
        }
    }
}