using FlexusWorkout.Decorator;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.Decorators
{
    public class CustomizableExerciseFactory
    {
        // Method to create a customizable exercise based on input parameters
        public Exercise CreateCustomizableExercise(string type, string name, string description, int? durationInMinutes, int? repetitions, int? sets, string? equipmentRequired, int? intensityLevel, string? location)
        {
            Exercise exercise;
            
            // Using a switch statement to handle different exercise types
            //Converts the type parameter to lowercase for case-insensitive comparison
            switch (type.ToLower())
            {
                case "strength":
                    // Creating a new instance of StrengthExercise and assigning it to the exercise variable
                    // Providing necessary parameters for the StrengthExercise constructor
                    exercise = new StrengthExercise(type, name, description, durationInMinutes, repetitions, sets,
                        equipmentRequired, intensityLevel, location);
                    break;
                case "balance":
                    exercise = new BalanceExercise(type, name, description, durationInMinutes, repetitions, sets,
                        equipmentRequired, intensityLevel, location);
                    break;
                case "cardio":
                    exercise = new CardioExercise(type, name, description, durationInMinutes, repetitions, sets,
                        equipmentRequired, intensityLevel, location);
                    break;
                default:
                    throw new ArgumentException("Invalid exercise type");
            }
            // Wrapping the created exercise with the CustomizableExerciseDecorator
            return new CustomizableExerciseDecorator(exercise);
        }
    }
}