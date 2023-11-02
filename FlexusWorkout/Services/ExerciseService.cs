
using FlexusWorkout.Model;
using FlexusWorkout.Model.Concrete;
using FlexusWorkout.View_model;

namespace FlexusWorkout.Services;

public class ExerciseService {
    private readonly FlexusWorkoutDbContext _db;
    public ExerciseService() //TODO NEED TO EDIT THIS TO USE DEPENDENCY INJECTION
    {
        _db = new();
    }
    
    
    
    
    //Getting the exercises by the type
    public Exercise GetExerciseByType(string type) {
        // LINQ Query
        //return _db.Exercise.FirstOrDefault(e => e.Type == type);
        return new StrengthExercise();
    }
}