namespace FlexusWorkout.Models.Base;

//Abstract Base Class for all exercise types
//used to create instances of specific exercise types (StrengthExercise, BalanceExercise and CardioExercise)
public abstract class Exercise
{
    //Common properties for all the exercise types (Strength, Balance, Cardio)
    public int ExerciseId { get; set; } //PK
    public string Type { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? DurationInMinutes { get; set; }
    public int? Repetitions { get; set; }
    public int? Sets { get; set; }
    public string? EquipmentRequired { get; set; } 
    public int? IntensityLevel { get; set; }
    public string? Location { get; set; }

    public bool Standard { get; set; } = false;

    public Exercise() 
    { }
    
    protected Exercise(string type, string? name, string? description, int? durationInMinutes, int? repetitions, int? sets, string? equipmentRequired, int? intensityLevel, string? location) {
        Type = type;
        Name = name;
        Description = description;
        DurationInMinutes = durationInMinutes;
        Repetitions = repetitions;
        Sets = sets;
        EquipmentRequired = equipmentRequired;
        IntensityLevel = intensityLevel;
        Location = location;
    }
}