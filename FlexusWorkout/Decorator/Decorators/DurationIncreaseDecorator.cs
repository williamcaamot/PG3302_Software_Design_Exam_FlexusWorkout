using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Decorators;

public class DurationIncreaseDecorator : ExerciseDecorator
{
    public DurationIncreaseDecorator(Exercise exercise) : base(exercise)
    {
        DurationInMinutes = exercise.DurationInMinutes + 1;
    }
}