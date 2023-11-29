using FlexusWorkout.Decorator.Factories.Base;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Factories;

public class DecoratorFactory
{
    private Exercise _exercise;
    public DecoratorFactory(Exercise exercise)
    {
        _exercise = exercise;
    }

    public ExerciseDecoratorFactory? CreateFactory()
    {
        switch (_exercise.Type)
        {
            case "Cardio":
                return new CardioDecoratorFactory(_exercise);
            case "Balance":
                return new BalanceDecoratorFactory(_exercise);
            case "Strength":
                return new StrengthDecoratorFactory(_exercise);
            default:
                throw new ArgumentException("Invalid factory type");
        }
     }
}