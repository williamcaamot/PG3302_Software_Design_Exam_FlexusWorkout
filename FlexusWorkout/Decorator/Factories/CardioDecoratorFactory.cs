using FlexusWorkout.Decorator.Decorators;
using FlexusWorkout.Decorator.Factories.Base;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.Decorator.Factories;

public class CardioDecoratorFactory : ExerciseDecoratorFactory
{
    private Exercise _exercise;
    public CardioDecoratorFactory(Exercise exercise)
    {
        _exercise = exercise;
    }

    public override Exercise MakeHarder()
    {
        Exercise decoratedExercise = new IntensityIncreaseDecorator(_exercise);
        return decoratedExercise;
    }

    public override Exercise MakeEasier()
    {
        Exercise decoratedExercise = new IntensityDecreaseDecorator(_exercise);
        return decoratedExercise; 
    }
}