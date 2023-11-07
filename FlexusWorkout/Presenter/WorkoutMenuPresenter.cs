namespace FlexusWorkout.Presenter;
using Base;

public class WorkoutMenuPresenter : MenuPresenter
{
    public WorkoutMenuPresenter(View.Base.View view) : base(view)
    {
    }

    public override bool InputHandler(string? input)
    {
        switch (input)
        {
            case "0":
                return false;
            case "1":
                // TODO add redirect to MyWorkout View here
                return true;
            case "2":
                // TODO add redirect to CreateWorkout View here
                return true;
            case "3":
                //TODO add view to delete
                return true;
            default:
                Console.WriteLine("Invalid option, try again.");
                return true;
        }
    }
}