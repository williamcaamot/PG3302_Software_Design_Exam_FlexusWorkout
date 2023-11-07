namespace FlexusWorkout.Model.Concrete; 
using Base;

public class CardioExercise : Exercise {
    public CardioExercise(string type, string? name, string? description, int? durationInMinutes, int? repetitions, int? sets, string? equipmentRequired, int? intensityLevel, string? location) : 
        base(type, name, description, durationInMinutes, 0, 0, null, intensityLevel, location) {
    }

    public CardioExercise() {
    }
}