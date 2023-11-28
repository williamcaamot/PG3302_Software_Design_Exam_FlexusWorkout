using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.Decorator.Decorators;

public class RepetitionDecreaseDecorator : ExerciseDecorator
{

    public RepetitionDecreaseDecorator(Exercise exercise) : base(exercise)
    {
        if (exercise.Repetitions > 1)
        {
            Repetitions = exercise.Repetitions - 1;
        }
    }
}