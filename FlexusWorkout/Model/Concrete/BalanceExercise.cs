using FlexusWorkout.View_model;
namespace FlexusWorkout.Model.Concrete; 

public class BalanceExercise : Exercise {
    public BalanceExercise(string type, string? name, string? description, int? durationInMinutes, int? repetitions, int? sets, string? equipmentRequired, int? intensityLevel, string? location) : 
        base(type, name, description, durationInMinutes, 0, 0, equipmentRequired, intensityLevel, null) {
    }

    public BalanceExercise() {
    }
}