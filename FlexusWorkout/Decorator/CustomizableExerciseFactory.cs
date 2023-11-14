using FlexusWorkout.Decorators;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Services.Repository;
using System;
using System.Collections.Generic;
using FlexusWorkout.Services;

namespace FlexusWorkout.Decorators
{
    public class CustomizableExerciseFactory
    {
        private readonly ExerciseService _exerciseService;

        public CustomizableExerciseFactory(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public CustomizableExerciseDecorator CreateCustomizableExercise(int exerciseId)
        {
            // Fetch the exercise from the database using the ExerciseService
            Exercise exercise = _exerciseService.GetExercise(exerciseId);

            if (exercise == null)
            {
                throw new ArgumentException("Invalid exercise ID");
            }

            // Wrap the exercise with the CustomizableExerciseDecorator
            return new CustomizableExerciseDecorator(exercise);
        }
    }
}
