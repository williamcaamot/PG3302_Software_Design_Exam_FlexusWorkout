using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Views.Workout;

public class CreateWorkout : View
{
    protected override void Display()
    {
        Console.Clear();
        Console.WriteLine("Creating new workout...");
        
        Console.WriteLine("Enter a name for workout: ");
        var name = Console.ReadLine();
        OnInputReceived("name", name);

        Console.WriteLine("Enter a description for workout: ");
        var description = Console.ReadLine();
        OnInputReceived("description", description);
        DisplayCategories();
        
    }

    protected void DisplayCategories()
    {
        Console.Clear();
        Console.WriteLine("Adding exercise to workout...");
        OnInputReceived("getcategories", "");
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect a category: "); 
        var input = Console.ReadLine();
        OnInputReceived("categoryInput", input);
    }
    public void DisplayExercises(string type)
    {
        Console.Clear();
        Console.WriteLine("Adding exercise to workout...");
        OnInputReceived("getexercises", type);
        Console.WriteLine("0 - Exit");
        Console.Write("\r\nSelect an exercise: "); 
        var input = Console.ReadLine();
        OnInputReceived("exerciseInput", input);
    }
    
    
}