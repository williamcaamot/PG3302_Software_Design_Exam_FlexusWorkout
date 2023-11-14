namespace FlexusWorkoutTests;

public class WorkoutPlannerTest
{
    
    public class GetInputFromConsole
    {
        public virtual string? GetInput()
        {
            return Console.ReadLine();
        }
    }
    
    
    [Test]
    public void ShouldBeADate()
    {
        Console.WriteLine("Select a date for you workout (YYYY-MM-DD)");

        string exampleDate = "3030-12-01";

        bool areTheDateParsed = DateOnly.TryParse(exampleDate, out DateOnly choosenDate);

        Assert.IsTrue(areTheDateParsed);
    }
    public class TestDateRetrival : GetInputFromConsole
    {
        
    }

    [Test]
    public void ShouldGiveMeADate()
    {
        
        Console.WriteLine("Select a date for you workout (YYYY-MM-DD)");
        string? input = Console.ReadLine();

        if (DateOnly.TryParse(input, out DateOnly choosenDate))
        {
            Console.WriteLine($"The date you passed '{choosenDate.ToString()}' is valid");
        }
        else
        {
            Console.WriteLine("Invalid entry, enter by 'YYYY-MM-DD'");
        }
    }
}