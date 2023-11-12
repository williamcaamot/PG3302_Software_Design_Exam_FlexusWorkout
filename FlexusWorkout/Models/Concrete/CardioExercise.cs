using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Models.Concrete; 

public class CardioExercise : Exercise {
    public CardioExercise(string type, string? name, string? description, int? durationInMinutes, int? repetitions, int? sets, string? equipmentRequired, int? intensityLevel, string? location) : 
        base(type, name, description, durationInMinutes, repetitions, sets, equipmentRequired, intensityLevel, location) {
    }

    public CardioExercise() {
    }
}