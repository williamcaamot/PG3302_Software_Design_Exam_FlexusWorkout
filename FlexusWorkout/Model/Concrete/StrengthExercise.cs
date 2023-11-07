namespace FlexusWorkout.Model.Concrete; 
using Base;

public class StrengthExercise : Exercise {
    public StrengthExercise(string type, string? name, string? description, int? durationInMinutes, int? repetitions, int? sets, string? equipmentRequired, int? intensityLevel, string? location) : 
        base(type, name, description, durationInMinutes, repetitions, sets, equipmentRequired, intensityLevel, location) {
    }

    public StrengthExercise() {
    }
}