using FlexusWorkout.Model.Concrete;
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
    public void AddExerciseOfTypeBalance_ShouldReturnSameExercise()
    {
        BalanceExercise balanceExercise = new();
        
    }
}