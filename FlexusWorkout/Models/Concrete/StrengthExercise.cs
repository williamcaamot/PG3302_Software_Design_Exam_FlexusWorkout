using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Models.Concrete; 

public class StrengthExercise : Exercise {
    public StrengthExercise() {
    }
    public StrengthExercise(string type, string? name, string? description, int? repetitions, int? sets, string? equipmentRequired, int? intensityLevel, string? location) : 
        base(type, name, description, null, repetitions, sets, equipmentRequired, intensityLevel, location) {
    }
    
    public override string ToString()
    {
        return $"{Name}" +
               "\r\n---------------" +
               $"\r\n{Description}" +
               "\r\n---------------" +
               $"\r\nType: {Type}" +
               $"\r\nIntensity level: {IntensityLevel}" +
               $"\r\nSuggested location: {Location}" +
               $"\r\nEquipment needed: {EquipmentRequired}" + 
               $"\r\nSets: {Sets}" +
               $"\r\nRepetitions: {Repetitions}";
    }
}