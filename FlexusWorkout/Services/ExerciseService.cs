
using FlexusWorkout.View_model;

namespace FlexusWorkout.Model;

public class ExerciseService {
    private readonly FlexusWorkoutDbContext _db;
    public ExerciseService(FlexusWorkoutDbContext db)
    {
        _db = db;
    }
    //Getting the exercises by the type
    public Exercise GetExerciseByType(string Type) {
        // Use Entity Framework Core to query the database
        return _db.Exercise.FirstOrDefault(e => e.Type == Type);
    }
}