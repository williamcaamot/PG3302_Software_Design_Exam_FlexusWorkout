using FlexusWorkout.Model.Base;

namespace FlexusWorkout.Model.Concrete; 

public class StrengthExercise : Exercise {
    public StrengthExercise(string type, string? name, string? description, int? durationInMinutes, int? repetitions, int? sets, string? equipmentRequired, int? intensityLevel, string? location) : 
        base(type, name, description, 0, repetitions, sets, equipmentRequired, 0, null) {
    }

    public StrengthExercise() {
    }
}