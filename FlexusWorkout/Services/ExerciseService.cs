using FlexusWorkout.Model.Concrete;
using FlexusWorkout.View_model;

namespace FlexusWorkout.Model;

public class ExerciseService {
    private readonly FlexusWorkoutDbContext _db;

    //Getting the exercises by the type
    public Exercise GetExerciseByType(string Type) {
        switch (Type) {
            case "strength":
                return new StrengthExercise();
            case "balance":
                return new BalanceExercise();
            case "cardio":
                return new CardioExercise();
            default:
                return null;
        }
    }
}