using FlexusWorkout.Decorator.Decorators;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkoutTests.UnitTest
{
    public class DecoratorUnitTesting
    {
        [Test]
        public void DurationInMinutesDecorator_ShouldIncreaseDuration()
        {
            // Arrange
            var baseExercise = new StrengthExercise("Strength", "Test Exercise", "Description", 30, 10, "3", 2,
                "Pro");
            var decorator = new DurationIncreaseDecorator(baseExercise);

            // Act
            decorator.IncreaseDuration();

            // Assert
            Assert.AreEqual(31, baseExercise.DurationInMinutes); // Check if the duration increased by 1 minute
        }
    }
}