using FlexusWorkout.Models.Concrete;
using FlexusWorkout.MODIFINGGGGG.modifierAndDecorators;

namespace FlexusWorkoutTests.UnitTest
{
    public class DecoratorUnitTesting
    {
        [Test]
        public void DurationInMinutesDecorator_ShouldIncreaseDuration()
        {
            // Arrange
            var baseExercise = new StrengthExercise("Strength", "Test Exercise", "Description", 30, 10, 3, "Dumbbells",
                3, "Gym");
            var decorator = new DurationIncreaseDecorator(baseExercise);

            // Act
            decorator.IncreaseDuration();

            // Assert
            Assert.AreEqual(31, baseExercise.DurationInMinutes); // Check if the duration increased by 1 minute
        }
    }
}