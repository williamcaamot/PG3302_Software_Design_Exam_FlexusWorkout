using System.Net.Http.Headers;
using FlexusWorkout;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkoutTests;

public class ExerciseServiceTest
{
    private ExerciseService Service;
    [OneTimeSetUp]
    public void SetUpBeforeEachTest()
    {
        Service = new ExerciseService();
    }
    [Test]
    public void AddExerciseOfTypeStrength_ShouldReturnSameExercise()
    {
        StrengthExercise strengthExercise = new StrengthExercise("Strength",
            "Knebøy",
            "Knebøy",
            null,
            8,
            2,
            "Barbell",
            10,
            "Gym"
        );

        ExerciseService exerciseService = new();
        exerciseService.AddExercise(strengthExercise);

        IList<Exercise> strengthExercises = exerciseService.GetExercisesByType("Strength");

        Assert.That(strengthExercises[0].ExerciseId, Is.GreaterThan(0));
        Assert.That(strengthExercises[0].Name, Is.EqualTo(strengthExercise.Name));
        Assert.That(strengthExercises[0].Description, Is.EqualTo(strengthExercise.Description));
        Assert.That(strengthExercises[0].Repetitions, Is.EqualTo(strengthExercise.Repetitions));
        Assert.That(strengthExercises[0].Sets, Is.EqualTo(strengthExercise.Sets));
        Assert.That(strengthExercises[0].EquipmentRequired, Is.EqualTo(strengthExercise.EquipmentRequired));
        Assert.That(strengthExercises[0].IntensityLevel, Is.EqualTo(strengthExercise.IntensityLevel));
        Assert.That(strengthExercises[0].Location, Is.EqualTo(strengthExercise.Location));
    }
    
    [Test]
    public void AddExerciseOfTypeBalance_ShouldReturnSameExercise()
    {
        BalanceExercise balanceExercise = new BalanceExercise("Balance",
            "Balancøvelse",
            "BalancøvelseBeskrivelse",
            5,
            null,
            null,
            null,
            1,
            "Trenignssenter for yoga øvelser"
        );
        
        ExerciseService exerciseService = new();
        exerciseService.AddExercise(balanceExercise);

        IList<Exercise> strengthExercises = exerciseService.GetExercisesByType("Balance");

        Assert.That(strengthExercises[0].ExerciseId, Is.GreaterThan(0));
        Assert.That(strengthExercises[0].Name, Is.EqualTo(balanceExercise.Name));
        Assert.That(strengthExercises[0].Description, Is.EqualTo(balanceExercise.Description));
        Assert.That(strengthExercises[0].Repetitions, Is.EqualTo(balanceExercise.Repetitions));
        Assert.That(strengthExercises[0].Sets, Is.EqualTo(balanceExercise.Sets));
        Assert.That(strengthExercises[0].EquipmentRequired, Is.EqualTo(balanceExercise.EquipmentRequired));
        Assert.That(strengthExercises[0].IntensityLevel, Is.EqualTo(balanceExercise.IntensityLevel));
        Assert.That(strengthExercises[0].Location, Is.EqualTo(balanceExercise.Location));
    }
    
    
    [Test]
    public void AddExerciseOfTypeCardio_ShouldReturnSameExercise()
    {
        CardioExercise cardioExercise = new CardioExercise("Cardio",
            "Løping",
            "En kul treningsøkt.",
            20,
            null,
            null,
            "Løpesko",
            4,
            "Utendørs"
        );
        
        ExerciseService exerciseService = new();
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

        ExerciseService exerciseService = new();
        DatabaseFiller databaseFiller = new();
        databaseFiller.FillExercises();
        
        
        IList<ExerciseType> exercisesTypes = exerciseService.getExerciseTypes();
        Console.WriteLine(exercisesTypes);
        Assert.That(exercisesTypes[0].Name, Is.AnyOf("Cardio","Balance","Strength"));
        Assert.That(exercisesTypes[1].Name, Is.AnyOf("Cardio","Balance","Strength"));
        Assert.That(exercisesTypes[2].Name, Is.AnyOf("Cardio","Balance","Strength"));
    }

    [Test]
    public void GetExerciseById_ShouldReturnExercise()
    {
        ExerciseService exerciseService = new();
        DatabaseFiller databaseFiller = new();
        databaseFiller.FillExercises();
        
        
        Exercise exercise = Service.GetExercise(1);
        
        Assert.That(exercise.Description, Is.EqualTo("A pose that replicates the steady stance of a tree."));
        
        
        
    }

    
}