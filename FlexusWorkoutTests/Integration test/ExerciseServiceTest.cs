using FlexusWorkout;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkoutTests.Integration_test;

public class ExerciseServiceTest
{
     private ExerciseService Service;
    private MySqlFlexusDbContext _mySqlFlexusDbContext;
    [OneTimeSetUp]
    public void SetUpBeforeEachTest()
    {
        Service = new ExerciseService(new MySqlFlexusDbContext());
        _mySqlFlexusDbContext = new();

    }
    [Test]
    public void AddExerciseOfTypeStrength_ShouldReturnSameExercise()
    {
    }
    
    [Test]
    public void AddExerciseOfTypeBalance_ShouldReturnSameExercise()
    {
        //Arrange
        BalanceExercise balanceExercise = new BalanceExercise("Balance",
            "Balancøvelse",
            "BalancøvelseBeskrivelse",
            5,
            
            1,
            "Trenignssenter for yoga øvelser"
        );
        ExerciseService exerciseService = new(_mySqlFlexusDbContext);
        
        //Act
        exerciseService.AddExercise(balanceExercise);
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
        exerciseService.deleteExercise(balanceExercises[0]);
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
        DatabaseFiller databaseFiller = new(_mySqlFlexusDbContext);
        databaseFiller.FillExercises();
        
        
        IList<ExerciseType> exercisesTypes = exerciseService.GetExerciseTypes();
        Console.WriteLine(exercisesTypes);
        Assert.That(exercisesTypes[0].Name, Is.AnyOf("Cardio","Balance","Strength"));
        Assert.That(exercisesTypes[1].Name, Is.AnyOf("Cardio","Balance","Strength"));
        Assert.That(exercisesTypes[2].Name, Is.AnyOf("Cardio","Balance","Strength"));
    }

    [Test]
    public void GetExerciseById_ShouldReturnExercise()
    {
       
        Exercise exercise = Service.GetExercise(1);
        
        Assert.That(exercise.Description, Is.EqualTo("A pose that replicates the steady stance of a tree."));
        
        
        
    }

}