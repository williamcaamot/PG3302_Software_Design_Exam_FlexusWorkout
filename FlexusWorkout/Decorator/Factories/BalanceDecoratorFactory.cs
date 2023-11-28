using FlexusWorkout.Decorator.Decorators;
using FlexusWorkout.Decorator.Factories.Base;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.Decorator.Factories;

public class BalanceDecoratorFactory : ExerciseDecoratorFactory
{
    private Exercise _exercise;
    public BalanceDecoratorFactory(Exercise exercise)
    {
        _exercise = exercise;
    }
    
    public override Exercise MakeHarder()
    {
        Exercise decoratedExercise = new DurationIncreaseDecorator(_exercise);
        return decoratedExercise;
    }

    public override Exercise MakeEasier()
    {
        Exercise decoratedExercise = new DurationDecreaseDecorator(_exercise);
        return decoratedExercise;
    }
}