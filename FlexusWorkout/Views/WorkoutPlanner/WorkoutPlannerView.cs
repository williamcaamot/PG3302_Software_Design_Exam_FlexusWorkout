using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.WorkoutPlanner;

public class WorkoutPlannerView : View
{
    public DateOnly GetInputDate()
    {
        while (true)
        {
            Console.WriteLine("Select a date for you workout (YYYY-MM-DD)");
            string? inputUser = Console.ReadLine();

            if (DateOnly.TryParse(inputUser, out DateOnly choosenDate))
            {
                return choosenDate;
            }
            else
            {
                Console.WriteLine("Error: Please try again, invalid date format ");
            }
        }
    }
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("Select a date for you workout (YYYY-MM-DD)");
        string? date = Console.ReadLine();
        OnInputReceived("date", date);


        Console.Clear();
        Console.WriteLine("Your previous workouts:");
        OnInputReceived("getWorkouts", "");
        Console.WriteLine("\r\nSelect an existing workout ");
        string? workout = Console.ReadLine();
        OnInputReceived("workout", workout);
        

    }
}