namespace FlexusWorkout.Model.Concrete; 
using Base;

public class BalanceExercise : Exercise {
    
   

    public BalanceExercise() {
    }

    public BalanceExercise(string type, string? name, string? description, int? durationInMinutes, int? repetitions, int? sets, string? equipmentRequired, int? intensityLevel, string? location) : 
        base(type, name, description, durationInMinutes, repetitions, sets, equipmentRequired, intensityLevel, location) {
    }
}