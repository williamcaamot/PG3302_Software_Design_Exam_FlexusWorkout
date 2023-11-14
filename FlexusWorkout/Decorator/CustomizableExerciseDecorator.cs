using FlexusWorkout.Decorator;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
namespace FlexusWorkout.Decorators
{
    //Concrete decorator that adds specific customization logic for making exercises harder or easier
    public class CustomizableExerciseDecorator : ExerciseDecorator
    {
        public CustomizableExerciseDecorator(Exercise component) : base(component) { }

        public void MakeHarder()
        {
            // You can implement specific logic for making exercises harder
            // For example, you can increase reps, sets, duration, or intensity level
            if (_component is StrengthExercise strengthExercise)
            {
                // Increase sets and repetitions for StrengthExercise
                strengthExercise.Sets++;
                strengthExercise.Repetitions++;
            }
            else if (_component is BalanceExercise balanceExercise)
            {
                // Add logic for Balance exercise
                balanceExercise.DurationInMinutes += 10;
            }
            else if (_component is CardioExercise cardioExercise)
            {
                cardioExercise.IntensityLevel += 1;
            }
        }

        public void MakeEasier()
        {
            // You can implement specific logic for making exercises easier
            // For example, you can decrease reps, sets, duration, or intensity level
            if (_component is StrengthExercise strengthExercise)
            {
                // Decrease sets and repetitions for StrengthExercise
                if (strengthExercise.Sets > 1)
                {
                    strengthExercise.Sets--;
                }
                if (strengthExercise.Repetitions > 1)
                {
                    strengthExercise.Repetitions--;
                }
            }
            else if (_component is BalanceExercise balanceExercise)
            {
                // Add logic for Balance exercise
            }
            else if (_component is CardioExercise cardioExercise)
            {
                // Decrease intensity and duration for CardioExercise
                if (cardioExercise.IntensityLevel > 1)
                {
                    cardioExercise.IntensityLevel--;
                }
                //If the intensityLevel is less than one, then it cant be decreased
                else 
                {
                    Console.WriteLine("Cannot make this exercise easier");
                }
                
                if (cardioExercise.DurationInMinutes > 1)
                {
                    cardioExercise.DurationInMinutes--;
                }
                //If the DurationInMinutes is less than one minute, then it cant be decreased
                else
                {
                    Console.WriteLine("Cannot make this exercise easier");
                }
                
            }
        }
    }
}