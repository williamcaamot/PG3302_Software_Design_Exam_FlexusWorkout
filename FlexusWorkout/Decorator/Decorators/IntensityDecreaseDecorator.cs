using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Decorators;

public class IntensityDecreaseDecorator : ExerciseDecorator
{

    public IntensityDecreaseDecorator(Exercise exercise) : base(exercise)
    {
        if (exercise.IntensityLevel > 1)
        {
            IntensityLevel = exercise.IntensityLevel - 1;
        }
    }
}