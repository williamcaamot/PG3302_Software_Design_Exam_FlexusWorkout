using FlexusWorkout.Decorator.Decorators;
using FlexusWorkout.Decorator.Factories.Base;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Factories;

public class StrengthDecoratorFactory : ExerciseDecoratorFactory
{
    private Exercise _exercise;
    public StrengthDecoratorFactory(Exercise exercise)
    {
        _exercise = exercise;
    }

    public override Exercise MakeHarder()
    {
        Exercise partiallyDecoratedExercise = new RepetitionIncreaseDecorator(_exercise);
        Exercise decoratedExercise = new SetIncreaseDecorator(partiallyDecoratedExercise);
        return decoratedExercise;

    }

    public override Exercise MakeEasier()
    {
        Exercise partiallyDecoratedExercise = new RepetitionDecreaseDecorator(_exercise);
        Exercise decoratedExercise = new SetDecreaseDecorator(partiallyDecoratedExercise);
        return decoratedExercise;
    }
}