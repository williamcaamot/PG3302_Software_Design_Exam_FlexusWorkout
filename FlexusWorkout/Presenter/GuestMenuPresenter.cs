namespace FlexusWorkout.Presenter;

public class GuestMenuPresenter : Presenter
{
    public override bool InputHandler(string? input)
    {
        switch (input)
        {
            case "0":
                return false;
            case "1":
                // TODO add redirect to ExerciseFinder View here
                Console.WriteLine("To look-up exercise");
                return true;
            default:
                Console.WriteLine("Invalid option, try again.");
                return true;
        }
    }
}