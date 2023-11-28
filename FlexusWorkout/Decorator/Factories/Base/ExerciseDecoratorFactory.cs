using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Factories.Base;

public abstract class ExerciseDecoratorFactory
{
    public abstract Exercise MakeHarder();
    
    public abstract Exercise MakeEasier();
}