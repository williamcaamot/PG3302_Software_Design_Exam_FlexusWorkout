using System.Runtime.InteropServices.JavaScript;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using Mysqlx.Datatypes;

namespace FlexusWorkout.Views.WorkoutPlanner;

public interface IWorkoutPlannerView
{
    List<string> ChooseExercise(DateOnly dateOnly, List<string> exercises, List<string>? retriveExisting);
    List<string> RetriveExistingWorkouts();
    int ChooseTypeOfExercise(Dictionary<int, string> typeOfExercise);
    void UserMessage(string message);

    public class ExtendedWorkoutPlannerView : IWorkoutPlannerView
    {
        public List<string> ChooseExercise(DateOnly dateOnly, List<string> exercises, List<string>? retriveExisting = null)
        {
            if (retriveExisting != null && retriveExisting.Count > 0)
            {
                Console.WriteLine("Do you want to use an existing workout? (yes/no)");
                string inputFromUser = Console.ReadLine()!.Trim();
                if (inputFromUser.Equals("yes", StringComparison.OrdinalIgnoreCase))
                {
                    return RetriveExistingWorkouts();
                }
            }
            Console.WriteLine(
                $"Choose exercises for {dateOnly}, enter corresponding numbers of wanted exercise/exercises: ");

            for (int i = 0; i < exercises.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {exercises[i]}");
            }

            List<string> selctedExercises = new List<string>();
            while (true)
            {
                Console.WriteLine("Enter identifier of wanted exercise on chosen date, type 'ok' when complete");
                string inputFromUser = Console.ReadLine()!.Trim(); //Remove leading and trailing spaces

                if (inputFromUser.Equals("ok", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (int.TryParse(inputFromUser, out int exerciseNumber) && exerciseNumber >= 1 &&
                    exerciseNumber <= exercises.Count)
                {
                    selctedExercises.Add(exercises[exerciseNumber - 1]);
                    Console.WriteLine($"{exercises[exerciseNumber - 1]} added to your workout on {dateOnly}");
                }
                else
                {
                    Console.WriteLine("Invalid entry, please try again");
                }
            }
            return selctedExercises;
        }
        

        public List<string> RetriveExistingWorkouts()
        {
            IList<Models.Concrete.Workout> workoutsSaved = GetWorkoutsSaved();
            Console.WriteLine("Select one of the saved workouts");
            for (int i = 0; i < workoutsSaved.Count; i++)
            {
                Console.WriteLine($"{i + 1} {workoutsSaved[i]}");
            }

            while (true)
            {
                string userInput = Console.ReadLine().Trim();
                if (int.TryParse(userInput, out int number) && number >= 1 && number <= workoutsSaved.Count)
                {
                    string choosenWorkout = workoutsSaved[number - 1].Name;
                    return new List<string> { choosenWorkout };
                }
                else
                {
                    Console.WriteLine("Error: Invalid input, please try again");
                }
            }
        }

        public IList<Models.Concrete.Workout> GetWorkoutsSaved()
        {
            //Implement method to retive saved workouts
            User user = new User();

            return user.Workouts.ToList();
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
