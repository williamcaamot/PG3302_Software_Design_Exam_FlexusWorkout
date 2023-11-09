using System.Runtime.InteropServices.JavaScript;
using FlexusWorkout.Model.Base;
using Mysqlx.Datatypes;

namespace FlexusWorkout.View.WorkoutPlanner;

public interface IWorkoutPlannerView
{
    List<string> ChooseExercise(string day, List<string> exercises);
    int ChooseTypeOfExercise(Dictionary<int, string> typeOfExercise);
    void UserMessage(string message);

    public class ExtendedWorkoutPlannerView : IWorkoutPlannerView
    {
        public List<string> ChooseExercise(string day, List<string> exercises)
        {
            Console.WriteLine(
                $"Choose exercises for {day}, enter corresponding numbers of wanted exercise/exercises: ");

            for (int i = 0; i < exercises.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {exercises[i]}");
            }

            List<string> selctedExercises = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter identifier of wanted exercise on chosen day, type 'ok' when complete");
                string inputFromUser = Console.ReadLine()!.Trim(); //Remove leading and trailing spaces

                if (inputFromUser.Equals("ok", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (int.TryParse(inputFromUser, out int exerciseNumber) && exerciseNumber >= 1 &&
                    exerciseNumber <= exercises.Count)
                {
                    selctedExercises.Add(exercises[exerciseNumber - 1]);
                    Console.WriteLine($"{exercises[exerciseNumber - 1]} added to your workout on {day}");
                }
                else
                {
                    Console.WriteLine("Invalid entry, please try again");
                }
            }
            return selctedExercises;
        }



        public int ChooseTypeOfExercise(Dictionary<int, string> typeOfExercise)
        {
            foreach (var eType in typeOfExercise)
            {
                Console.WriteLine($"{eType.Key}, {eType.Key}");
            }

            Console.WriteLine("Select the type of workout you want: ");
            while (true)
            {
                string? inputFromUser = Console.ReadLine();
                if (int.TryParse(inputFromUser, out int Choosen) && typeOfExercise.ContainsKey(Choosen))
                {
                    return Choosen;
                }
                else
                {
                    Console.WriteLine("Invalid entry, please try again");
                }
            }
        }

        public void UserMessage(string messageToUser)
        {
            Console.WriteLine(messageToUser);
        }
    }
    
    
}
