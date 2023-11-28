using FlexusWorkout.Models.Base;
using Org.BouncyCastle.Asn1.X509;

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