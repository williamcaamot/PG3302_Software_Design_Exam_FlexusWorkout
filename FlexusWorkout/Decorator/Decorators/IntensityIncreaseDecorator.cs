using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Decorators;

public class IntensityIncreaseDecorator : ExerciseDecorator
{
    public IntensityIncreaseDecorator(Exercise exercise) : base(exercise)
    {
        IntensityLevel = exercise.IntensityLevel + 1;
    }
}