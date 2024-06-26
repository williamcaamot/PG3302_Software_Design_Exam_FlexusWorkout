﻿using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Services;

namespace FlexusWorkout.Models.Concrete;

public class ExerciseType
{
    public string Name { get; }
    public List<Exercise> Exercises { get; set; }

    public int Count
    {
        get => Exercises.Count;
    }

    public ExerciseType(string name)
    {
        Name = name;
        Exercises = new List<Exercise>();
        
        // populate Exercises list
        Populate();

    }


    public void AddExercise(Exercise exercise)
    {
        Exercises.Add(exercise);
    }

    public void Populate()
    // Populates Exercises list with exercises belonging to this
    // specific exercise type. I.E Running exercise in Cardio exercise type
    {
        MySqlFlexusDbContext mySqlFlexusDbContext = new();
        MySqlExerciseDA mySqlExerciseDa = new MySqlExerciseDA(mySqlFlexusDbContext);
        ExerciseService exerciseService = new(mySqlExerciseDa);
        var exercises = exerciseService.GetExercisesByType(Name);

        for (int i = 0; i < exercises.Count; i++)
        {
            AddExercise(exercises[i]);
        }
    }
}