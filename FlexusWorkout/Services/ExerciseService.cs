
using FlexusWorkout.Model;
using FlexusWorkout.View_model;

namespace FlexusWorkout.Services;

public class ExerciseService {
    private readonly FlexusWorkoutDbContext _db;
    public ExerciseService(FlexusWorkoutDbContext db)
    {
        _db = db;
    }
    //Getting the exercises by the type
    public Exercise GetExerciseByType(string type) {
        // LINQ Query
        return _db.Exercise.FirstOrDefault(e => e.Type == type);
    }
}