using FlexusWorkout.Decorator;
using FlexusWorkout.Decorator.Factories;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkoutTests;
/*
public class ExerciseModifierFactoryUnitTests //TODO Can also create tests for checking that you cannot get negative ints by using the makeeasier method
{
    private Exercise _balanceExercise;
    private Exercise _strengthExercise;
    private Exercise _cardioExercise;
    
    
    
    [SetUp]
    public void createExercisesBeforeEachtest()
    {
        
        _strengthExercise = new StrengthExercise("Strength", "Crazy Lat pulldowns", "Get wings so big you can fly", 12,
            5, "Cable pulldown with bar attachment", 5, "Gym");
        _balanceExercise = new BalanceExercise("Balance", "Stretchy Stretcher", "An exercise that challenges your stretching abilites", 15, 8,
            "Yoga studio");
        _cardioExercise = new CardioExercise("Cardio", "Easy 5k run", "A good 5k run, not too heavy", 35,
            "Running shoes", 5, "Outdoors");
        
        _exerciseModifierFactory = new();
        
    }

    [Test]
    public void MakeHarder_StrengthExercise()
    {
        Exercise newStrengthExercise = _exerciseModifierFactory.MakeHarder(_strengthExercise);
        Assert.That(newStrengthExercise.Sets, Is.GreaterThan(_strengthExercise.Sets));
        Assert.That(newStrengthExercise.Repetitions, Is.GreaterThan(_strengthExercise.Repetitions));
        Assert.That(newStrengthExercise.IntensityLevel, Is.GreaterThan(_strengthExercise.IntensityLevel));
    }
    [Test]
    public void MakeHarder_BalanceExercise()
    {
        Exercise newBalanceExercise = _exerciseModifierFactory.MakeHarder(_balanceExercise);
        Assert.That(newBalanceExercise.DurationInMinutes, Is.GreaterThan(_balanceExercise.DurationInMinutes));
        Assert.That(newBalanceExercise.IntensityLevel, Is.GreaterThan(_balanceExercise.IntensityLevel));
    }
    [Test]
    public void MakeHarder_CardioExercise()
    {
        Exercise newCardioExercise = _exerciseModifierFactory.MakeHarder(_cardioExercise);
        Assert.That(newCardioExercise.DurationInMinutes, Is.GreaterThan(_cardioExercise.DurationInMinutes));
        Assert.That(newCardioExercise.IntensityLevel, Is.GreaterThan(_cardioExercise.IntensityLevel));
    }
    
    
    [Test]
    public void MakeEasier_StrengthExercise()
    {
        Exercise newStrengthExercise = _exerciseModifierFactory.MakeEasier(_strengthExercise);
        Assert.That(newStrengthExercise.Sets, Is.LessThan(_strengthExercise.Sets));
        Assert.That(newStrengthExercise.Repetitions, Is.LessThan(_strengthExercise.Repetitions));
        Assert.That(newStrengthExercise.IntensityLevel, Is.LessThan(_strengthExercise.IntensityLevel));
    }
    [Test]
    public void MakeEasier_BalanceExercise()
    {
        Exercise newBalanceExercise = _exerciseModifierFactory.MakeEasier(_balanceExercise);
        Assert.That(newBalanceExercise.DurationInMinutes, Is.LessThan(_balanceExercise.DurationInMinutes));
        Assert.That(newBalanceExercise.IntensityLevel, Is.LessThan(_balanceExercise.IntensityLevel));
    }
    [Test]
    public void MakeEasier_CardioExercise()
    {
        Exercise newCardioExercise = _exerciseModifierFactory.MakeEasier(_cardioExercise);
        Assert.That(newCardioExercise.DurationInMinutes, Is.LessThan(_cardioExercise.DurationInMinutes));
        Assert.That(newCardioExercise.IntensityLevel, Is.LessThan(_cardioExercise.IntensityLevel));
    }
    
    
}*/