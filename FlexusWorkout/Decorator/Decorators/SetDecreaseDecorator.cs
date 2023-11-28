using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Decorators;

public class SetDecreaseDecorator : ExerciseDecorator
{
    public SetDecreaseDecorator(Exercise exercise) : base(exercise)
    {
        if (exercise.Sets > 1)
        {
            Sets = exercise.Sets - 1;
        }
    }
}