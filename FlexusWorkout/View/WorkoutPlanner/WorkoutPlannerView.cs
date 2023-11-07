using FlexusWorkout.Model.Base;
using FlexusWorkout.View.Menu.Model;

namespace FlexusWorkout.View.WorkoutPlanner;

public interface WorkoutPlannerView
{
    public List<Exercise> ChooseExercises(string Day)
    {
        List<Exercise> ExercisesChoosen = new List<Exercise>();

        Console.WriteLine($"Select your exercises for {Day} (Type 'ok' when you are ready):");
        bool selectionComplete = false;

        using (var context = new FlexusWorkoutDbContext())
        {
            while (!selectionComplete)
            {
                Console.WriteLine("Choose exercise: ");
                string NameOfExercise = Console.ReadLine();

                if (NameOfExercise.ToLower() == "ok")
                {
                    selectionComplete = true;
                }
                else
                {
                    return null;
                }
            }
        }

        return null;
    }
    
}
