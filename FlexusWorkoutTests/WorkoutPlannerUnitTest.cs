using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkoutTests;

public class WorkoutPlannerUnitTest
{
    //Following AAA
    [Test]
    public void TestFillDatasetWorkoutPlanner()
    {
        // Arrange
        var mockTheExercises = new List<Exercise>
        {
            new StrengthExercise { Name = "Beachy looking pump", Description = "An assolute beast exercises for you bum" },
            new BalanceExercise { Name = "Howling dog to moon", Description = "An exercises for your pose" },
        };

        var workoutDay = new WorkoutDay
        {
            Workout = new Workout
            {
                Name = "Blasting bubble butt",
                Description = "Exercises for you bum!",
                Exercises = mockTheExercises
            },
            Date = DateTime.Now
            
        };

        // Act
        List<object> dataSet = new List<object>
        {
            workoutDay.Workout.Name,
            workoutDay.Workout.Description,
            string.Join(", ", workoutDay.Workout.Exercises.Select(exercise => exercise.Name)),
            workoutDay.Date
        };
        
        // Assert
        Assert.That(dataSet[0], Is.EqualTo("Blasting bubble butt"));
        Assert.That(dataSet[1], Is.EqualTo("Exercises for you bum!"));
        Assert.That(dataSet[2], Is.EqualTo(string.Join(", ", mockTheExercises.Select(exercise => exercise.Name))));
        Assert.That(dataSet[3], Is.EqualTo(workoutDay.Date));
    }
}