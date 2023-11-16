using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Models.Concrete; 

public class BalanceExercise : Exercise {

    public BalanceExercise() {
    }

    public BalanceExercise(string type, string? name, string? description, int? durationInMinutes, int? intensityLevel, string? location) : 
        base(type, name, description, durationInMinutes, null, null, null, intensityLevel, location) {
    }
    

    public override string ToString()
    {
        return $"{Name}" +
               "\r\n---------------" +
               $"\r\n{Description}" +
               "\r\n---------------" +
               $"\r\nType: {Type}" +
               $"\r\nIntensity level: {IntensityLevel}" +
               $"\r\nDuration (minutes): {DurationInMinutes}" +
               $"\r\nSuggested location: {Location}";
    }
}