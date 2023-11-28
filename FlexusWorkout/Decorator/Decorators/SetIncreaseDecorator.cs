using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.Decorator.Decorators;

public class SetIncreaseDecorator : ExerciseDecorator
{

    public SetIncreaseDecorator(Exercise exercise) : base(exercise)
    {
        Sets = exercise.Sets + 1;
    }
}