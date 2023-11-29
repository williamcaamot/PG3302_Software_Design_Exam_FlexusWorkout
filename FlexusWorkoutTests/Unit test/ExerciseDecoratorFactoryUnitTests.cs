using FlexusWorkout.Decorator.Factories;
using FlexusWorkout.Decorator.Factories.Base;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkoutTests;

public class ExerciseDecoratorFactoryUnitTests //TODO Can also create tests for checking that you cannot get negative ints by using the makeeasier method
{
    private Exercise _balanceExercise;
    private Exercise _strengthExercise;
    private Exercise _cardioExercise;
    private DecoratorFactory _decoratorFactory;
    private ExerciseDecoratorFactory _exerciseDecoratorFactory;
    
    [SetUp]
    public void createExercisesBeforeEachtest()
    {
        
        _strengthExercise = new StrengthExercise("Strength", "Crazy Lat pulldowns", "Get wings so big you can fly", 12,
            5, "Cable pulldown with bar attachment", 5, "Gym");
        _balanceExercise = new BalanceExercise("Balance", "Stretchy Stretcher", "An exercise that challenges your stretching abilites", 15, 8,
            "Yoga studio");
        _cardioExercise = new CardioExercise("Cardio", "Easy 5k run", "A good 5k run, not too heavy", 35,
            "Running shoes", 5, "Outdoors");
        
    }

    [Test]
    public void MakeHarder_StrengthExercise()
    {
        _decoratorFactory = new DecoratorFactory(_strengthExercise);
        _exerciseDecoratorFactory = _decoratorFactory.CreateFactory();
        Exercise newStrengthExercise = _exerciseDecoratorFactory.MakeHarder();
        Assert.That(newStrengthExercise.Sets, Is.GreaterThan(_strengthExercise.Sets));
        Assert.That(newStrengthExercise.Repetitions, Is.GreaterThan(_strengthExercise.Repetitions));
    }
    [Test]
    public void MakeHarder_BalanceExercise()
    {
        _decoratorFactory = new DecoratorFactory(_balanceExercise);
        _exerciseDecoratorFactory = _decoratorFactory.CreateFactory();
        Exercise newBalanceExercise = _exerciseDecoratorFactory.MakeHarder();
        Assert.That(newBalanceExercise.DurationInMinutes, Is.GreaterThan(_balanceExercise.DurationInMinutes));
    }
    [Test]
    public void MakeHarder_CardioExercise()
    {
        _decoratorFactory = new DecoratorFactory(_cardioExercise);
        _exerciseDecoratorFactory = _decoratorFactory.CreateFactory();
        Exercise newCardioExercise = _exerciseDecoratorFactory.MakeHarder();
        Assert.That(newCardioExercise.IntensityLevel, Is.GreaterThan(_cardioExercise.IntensityLevel));
    }
    [Test]
    public void MakeEasier_StrengthExercise()
    {
        _decoratorFactory = new DecoratorFactory(_strengthExercise);
        _exerciseDecoratorFactory = _decoratorFactory.CreateFactory();
        Exercise newStrengthExercise = _exerciseDecoratorFactory.MakeEasier();
        Assert.That(newStrengthExercise.Sets, Is.LessThan(_strengthExercise.Sets));
        Assert.That(newStrengthExercise.Repetitions, Is.LessThan(_strengthExercise.Repetitions));
    }
    [Test]
    public void MakeEasier_BalanceExercise()
    {
        _decoratorFactory = new DecoratorFactory(_balanceExercise);
        _exerciseDecoratorFactory = _decoratorFactory.CreateFactory();
        Exercise newBalanceExercise = _exerciseDecoratorFactory.MakeEasier();
        Assert.That(newBalanceExercise.DurationInMinutes, Is.LessThan(_balanceExercise.DurationInMinutes));
    }
    [Test]
    public void MakeEasier_CardioExercise()
    {
        _decoratorFactory = new DecoratorFactory(_cardioExercise);
        _exerciseDecoratorFactory = _decoratorFactory.CreateFactory();
        Exercise newCardioExercise = _exerciseDecoratorFactory.MakeEasier();
        Assert.That(newCardioExercise.IntensityLevel, Is.LessThan(_cardioExercise.IntensityLevel));
    }
    
    
}