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
        Stop();
    }

    public void DisplayCategories()
    {
        Console.Clear();
        Console.WriteLine("Adding exercise to workout...");
        OnInputReceived("getcategories", "");
        Console.WriteLine("0 - Back");
        Console.Write("\r\nSelect a category: "); 
        var input = Console.ReadLine();
        OnInputReceived("categoryInput", input);
    }
    
    public void DisplayExercises(string type)
    {
        Console.Clear();
        Console.WriteLine("Adding exercise to workout...");
        OnInputReceived("getexercises", type);
        Console.WriteLine("0 - Back");
        Console.Write("\r\nSelect an exercise: "); 
        var input = Console.ReadLine();
        OnInputReceived("exerciseInput", input);
    }

    public void DisplayDecoratingChoices()
    {
        Console.Clear();
        Console.WriteLine("Do you want to customize this exercise?\r\n");
        OnInputReceived("showDecoratorInfo", "");
        Console.WriteLine("\r\n1 - Make it harder");
        Console.WriteLine("2 - Make it easier");
        Console.WriteLine("3 - Keep the exercise as it is now");
        var input = Console.ReadLine();
        OnInputReceived("decoratingChoice", input);
    }

    public void DisplayAddMore()
    {
        Console.Clear();
        Console.WriteLine("Do you want to add another exercise to your workout?");
        Console.WriteLine("1 - Yes");
        Console.WriteLine("2 - No");
        var input = Console.ReadLine();
        OnInputReceived("addMore", input);
    }
}