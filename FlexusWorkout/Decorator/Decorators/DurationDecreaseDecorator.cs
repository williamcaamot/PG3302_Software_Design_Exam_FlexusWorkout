using FlexusWorkout.Decorator.Decorators.Base;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Decorators;

public class DurationDecreaseDecorator : ExerciseDecorator
{
    public DurationDecreaseDecorator(Exercise exercise) : base(exercise)
    {
        if (exercise.DurationInMinutes > 1)
        {
            DurationInMinutes = exercise.DurationInMinutes - 1;
        }
    }
    
}