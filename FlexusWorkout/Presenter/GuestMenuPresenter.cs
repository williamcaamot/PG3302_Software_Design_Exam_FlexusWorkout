namespace FlexusWorkout.Presenter;
using Base;

public class GuestMenuPresenter : MenuPresenter
{
    public GuestMenuPresenter(View.Base.View view) : base(view)
    {
    }


    public override void HandleInput(string? key, string? input)
    {
        switch (key)
        {
            case "input":
                MainHandler(input);
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        switch (input)
        {
            case "0":
                View.Stop();
                break;
            case "1":
                // TODO add redirect to ExerciseFinder View here
                Console.WriteLine("To look-up exercise");
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                break;
        }
    }
}