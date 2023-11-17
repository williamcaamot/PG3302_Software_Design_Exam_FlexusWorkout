using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.Decorator;


//handles modification (making harder or easier) using decorators
public class ExerciseModifierFactory
{
    public Exercise MakeHarder(Exercise exercise)
        {
            
            if (exercise is StrengthExercise)
            {
                // Increase sets and repetitions for StrengthExercise
                
                //Exercise e = new RepetitionIncreaseDecorator(exercise);
                //e = new SetIncreaseDecorator(e);
                Exercise e = exercise; 
                return new StrengthExercise(
                    e.Type, 
                    e.Name,  //BUG DECORATORS MUST RETURN A NEW OBJECT OR ACTUALLY CHANGE THE OBJECT
                    e.Description,
                    e.Repetitions + 2,
                    e.Sets + 1,
                    e.EquipmentRequired, 
                    e.IntensityLevel + 1,
                    e.Location);
            }
            else if (exercise is BalanceExercise)
            {
                // Increasing duration in minutes for balance exercises
                //Exercise e = new DurationIncreaseDecorator(exercise); //BUG FIX THIS IS IMPORTANT; DECORATORS MUST RETURN SOMETHING
                Exercise e = exercise; 
                return new BalanceExercise(
                    e.Type, 
                    e.Name, 
                    e.Description,
                    e.DurationInMinutes + 3, 
                    e.IntensityLevel + 1,
                    e.Location);
            }
            else if (exercise is CardioExercise)
            {
                // Increasing intensity level cardio exercises
                //Exercise e = new IntensityIncreaseDecorator(exercise);//BUG FIX THIS IS IMPORTANT; DECORATORS MUST RETURN SOMETHING
                Exercise e = exercise; 
                return new CardioExercise(
                    e.Type, 
                    e.Name, 
                    e.Description,
                    e.DurationInMinutes + 5, 
                    e.EquipmentRequired, 
                    e.IntensityLevel + 4,
                    e.Location);
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
                    //Exercise setsDecreasedExercise = new SetDecreaseDecorator(exercise);
                    //Exercise repsDecreasedExercise = new RepetitionDecreaseDecorator(setsDecreasedExercise);
                    //return repsDecreasedExercise;
                    Exercise e = exercise;
                    return new StrengthExercise(
                        e.Type,
                        e.Name, //BUG DECORATORS MUST RETURN A NEW OBJECT OR ACTUALLY CHANGE THE OBJECT
                        e.Description,
                        e.Repetitions - 2,
                        e.Sets - 1,
                        e.EquipmentRequired,
                        e.IntensityLevel - 2,
                        e.Location);

                }
            }
            else if (exercise is BalanceExercise)
                {
                    //Exercise durationDecreasedExercise = new DurationDecreaseDecorator(exercise);
                    //return durationDecreasedExercise;
                    Exercise e = exercise; 
                    return new BalanceExercise(
                        e.Type, 
                        e.Name, 
                        e.Description,
                        e.DurationInMinutes - 3, 
                        e.IntensityLevel - 1,
                        e.Location);
            }
            // Decrease intensity for CardioExercise
            else if (exercise is CardioExercise)
            {
                if (exercise.IntensityLevel > 1)
                {
                    //Exercise intensityDecreaseExercise = new IntensityDecreaseDecorator(exercise);
                    //return intensityDecreaseExercise;
                    Exercise e = exercise; 
                    return new CardioExercise(
                        e.Type, 
                        e.Name, 
                        e.Description,
                        e.DurationInMinutes - 3, 
                        e.EquipmentRequired, 
                        e.IntensityLevel - 1,
                        e.Location);
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