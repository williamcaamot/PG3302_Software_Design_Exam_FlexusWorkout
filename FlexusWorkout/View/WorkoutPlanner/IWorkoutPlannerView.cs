using FlexusWorkout.Model.Base;
using FlexusWorkout.View.Menu.Model;

namespace FlexusWorkout.View.WorkoutPlanner;

public interface IWorkoutPlannerView
{
    public List<string> SelectExercise(string getExercisesByType, List<string> GetExercisesByType);

    public List<string> SelectedExercises(string day, List<string> GetExercisesByType)
    {
        Console.WriteLine($"Choose exercises for {day} by entering the number of exercise you want!");

        for (int j = 0; j < GetExercisesByType.Count; j++)
        {
            Console.WriteLine($"{j + 1}. {GetExercisesByType[j]}");
        }

        var choosenExercises = new List<string>();

        while (true)
        {
            Console.WriteLine("Enter the number of wanted exercise, press 'ok' when done.");
            var userInput = Console.ReadLine().Trim(); //Trim to remove leading av trailing spaces

            if (userInput.Equals("ok"))
            {
                break;
            }
            
            if (int.TryParse(userInput, out int number) && number >= 1 && number <= GetExercisesByType.Count)
            {
                choosenExercises.Add(GetExercisesByType[number - 1]);
            }
            else
            {
                Console.WriteLine("Invalid number, please try again or exit with 'ok'");
            }
        }

        return choosenExercises;
    }
}
