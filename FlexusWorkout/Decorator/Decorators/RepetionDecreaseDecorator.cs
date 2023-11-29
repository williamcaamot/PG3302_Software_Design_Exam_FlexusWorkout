using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;

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