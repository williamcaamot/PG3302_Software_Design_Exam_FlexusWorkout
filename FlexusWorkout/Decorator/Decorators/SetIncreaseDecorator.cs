using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Decorators;

public class SetIncreaseDecorator : ExerciseDecorator
{

    public SetIncreaseDecorator(Exercise exercise) : base(exercise)
    {
        Sets = exercise.Sets + 1;
    }
}