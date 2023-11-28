using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.Decorator.Decorators;

public class RepetitionIncreaseDecorator : ExerciseDecorator
{
    public RepetitionIncreaseDecorator(Exercise exercise) : base(exercise)
    {
        Repetitions = exercise.Repetitions + 1;
    }
}