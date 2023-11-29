using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Decorator.Decorators.Base;

public class ExerciseDecorator : Exercise
{
    public ExerciseDecorator(Exercise exercise)
    {
        Type = exercise.Type;
        Name = exercise.Name;
        Description = exercise.Description;
        DurationInMinutes = exercise.DurationInMinutes;
        Repetitions = exercise.Repetitions;
        Sets = exercise.Sets;
        EquipmentRequired = exercise.EquipmentRequired;
        IntensityLevel = exercise.IntensityLevel;
        Location = exercise.Location;
    }

}