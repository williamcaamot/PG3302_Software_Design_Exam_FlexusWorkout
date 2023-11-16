using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;


//handles modification (making harder or easier) using decorators
public class ExerciseModifierFactory
{
    public Exercise MakeHarder(Exercise exercise)
        {
            
            if (exercise is StrengthExercise)
            {
                
                // Increase sets and repetitions for StrengthExercise
                Exercise e = new RepetitionIncreaseDecorator(exercise);
                e = new SetIncreaseDecorator(e);
                return e;
            }
            else if (exercise is BalanceExercise)
            {
                // Increasing duration in minutes for balance exercises
                Exercise e = new DurationIncreaseDecorator(exercise);
                return e;
            }
            else if (exercise is CardioExercise)
            {
                // Increasing intensity level cardio exercises
                Exercise e = new IntensityIncreaseDecorator(exercise);
                Exercise ef = new BalanceExercise();
                return ef;
            }

            return exercise;
        }

        public Exercise MakeEasier(Exercise exercise)
        {
            if (exercise is StrengthExercise)
            {
                // Decrease sets and repetitions for StrengthExercise
                if (exercise.Sets > 1 && exercise.Repetitions > 1)
                {
                    Exercise setsDecreasedExercise = new SetDecreaseDecorator(exercise);
                    Exercise repsDecreasedExercise = new RepetitionDecreaseDecorator(setsDecreasedExercise);
                    return repsDecreasedExercise;
                }
            }
            else if (exercise is BalanceExercise)
            {
                Exercise durationDecreasedExercise = new DurationDecreaseDecorator(exercise);
                return durationDecreasedExercise;
            }
            // Decrease intensity for CardioExercise
            else if (exercise is CardioExercise)
            {
                if (exercise.IntensityLevel > 1)
                {
                    Exercise intensityDecreaseExercise = new IntensityDecreaseDecorator(exercise);
                    return intensityDecreaseExercise;
                }
                //If the intensityLevel is less than one, then it cant be decreased
                else 
                {
                    Console.WriteLine("Cannot make this exercise easier");
                }
            }
            return exercise;
        }
}