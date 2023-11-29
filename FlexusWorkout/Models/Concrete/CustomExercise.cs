using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Models.Concrete;

public class CustomExercise : Exercise
{
    public CustomExercise()
    {
    }
    
    public CustomExercise(string type, string? name, string? description, int? durationInMinutes, string? equipmentRequired, int? intensityLevel, string? location) : 
        base(type, name, description, durationInMinutes, null, null, equipmentRequired, intensityLevel, location) {
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
               $"\r\nSuggested location: {Location}" +
               $"\r\nEquipment needed: {EquipmentRequired}";
    }
    
    
}