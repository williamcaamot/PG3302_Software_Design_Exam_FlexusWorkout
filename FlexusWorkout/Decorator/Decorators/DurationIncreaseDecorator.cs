using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.Decorator.Decorators;

public class DurationIncreaseDecorator : ExerciseDecorator
{
    public DurationIncreaseDecorator(Exercise exercise) : base(exercise)
    {
        DurationInMinutes = exercise.DurationInMinutes + 1;
    }
}