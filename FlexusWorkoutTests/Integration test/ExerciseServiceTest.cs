using FlexusWorkout;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkoutTests.Integration_test;

public class ExerciseServiceTest
{
    private ExerciseService _service;
    private MySqlFlexusDbContext _mySqlFlexusDbContext;
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _service = new ExerciseService(new MySqlFlexusDbContext());
        _mySqlFlexusDbContext = new();

    }
    
    [Test]
    public void AddExerciseOfTypeBalance_ShouldReturnSameExercise()
    {
        //Arrange
        BalanceExercise balanceExercise = new BalanceExercise("Balance",
            "Balance Exercise!!",
            "Cool balance exercise!",
            5,
            
            1,
            "A YOGA GYM"
        );
        balanceExercise.Standard = true;
        ExerciseService exerciseService = new ExerciseService(_mySqlFlexusDbContext);
        int amountOfExercisesPreTest = 0;
        
        //Act
        amountOfExercisesPreTest = exerciseService.GetExercisesByType("Balance").Count;
        var addedExercise = exerciseService.AddExercise(balanceExercise);
        IList<Exercise> balanceExercises = exerciseService.GetExercisesByType("Balance");
        
        
        //Assert
        Assert.That(balanceExercises.Last().ExerciseId, Is.GreaterThan(0));
        Assert.That(balanceExercises.Last().Name, Is.EqualTo(balanceExercise.Name));
        Assert.That(balanceExercises.Last().Description, Is.EqualTo(balanceExercise.Description));
        Assert.That(balanceExercises.Last().Repetitions, Is.EqualTo(balanceExercise.Repetitions));
        Assert.That(balanceExercises.Last().Sets, Is.EqualTo(balanceExercise.Sets));
        Assert.That(balanceExercises.Last().EquipmentRequired, Is.EqualTo(balanceExercise.EquipmentRequired));
        Assert.That(balanceExercises.Last().IntensityLevel, Is.EqualTo(balanceExercise.IntensityLevel));
        Assert.That(balanceExercises.Last().Location, Is.EqualTo(balanceExercise.Location));
        
        //Cleanup
        exerciseService.DeleteExercise(addedExercise);
        
        //Extra assertion to make sure the exercise added in the test is in fact deleted
        Assert.That(exerciseService.GetExercisesByType("Balance").Count, Is.EqualTo(amountOfExercisesPreTest));
    }
    
    
    [Test]
    public void AddExerciseOfTypeCardio_ShouldReturnSameExercise()
    {
        CardioExercise cardioExercise = new CardioExercise("Cardio",
            "Løping",
            "En kul treningsøkt.",
            20,
            "Løpesko",
            4,
            "Utendørs"
        );
        
        ExerciseService exerciseService = new(_mySqlFlexusDbContext);
        exerciseService.AddExercise(cardioExercise);

        IList<Exercise> strengthExercises = exerciseService.GetExercisesByType("Cardio");

        Assert.That(strengthExercises[0].ExerciseId, Is.GreaterThan(0));
        Assert.That(strengthExercises[0].Name, Is.EqualTo(cardioExercise.Name));
        Assert.That(strengthExercises[0].Description, Is.EqualTo(cardioExercise.Description));
        Assert.That(strengthExercises[0].Repetitions, Is.EqualTo(cardioExercise.Repetitions));
        Assert.That(strengthExercises[0].Sets, Is.EqualTo(cardioExercise.Sets));
        Assert.That(strengthExercises[0].EquipmentRequired, Is.EqualTo(cardioExercise.EquipmentRequired));
        Assert.That(strengthExercises[0].IntensityLevel, Is.EqualTo(cardioExercise.IntensityLevel));
        Assert.That(strengthExercises[0].Location, Is.EqualTo(cardioExercise.Location));
    }

    [Test]
    public void GetExerciseTypes_ShouldReturnStringOfExercises()
    {
        ExerciseService exerciseService = new(_mySqlFlexusDbContext);
        
        IList<ExerciseType> exercisesTypes = exerciseService.GetExerciseTypes();
        Console.WriteLine(exercisesTypes);
        Assert.That(exercisesTypes[0].Name, Is.AnyOf("Cardio","Balance","Strength"));
        Assert.That(exercisesTypes[1].Name, Is.AnyOf("Cardio","Balance","Strength"));
        Assert.That(exercisesTypes[2].Name, Is.AnyOf("Cardio","Balance","Strength"));
    }

    [Test]
    public void GetExerciseById_ShouldReturnExercise()
    {
        //Arrange
        Exercise exercise;
        
        //Act
        exercise = _service.GetExercise(1);
        
        //Assert
        Assert.That(exercise.Description.Length, Is.GreaterThan(5));
        Assert.That(exercise.Name.Length, Is.GreaterThan(5));
    }

}