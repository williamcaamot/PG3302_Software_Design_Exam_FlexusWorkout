﻿using FlexusWorkout.Models.Base;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;

namespace FlexusWorkout.Models.Concrete;

public class ExerciseType
{
    public string Name { get; }
    private List<Exercise> Exercises { get; set; }

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
    {
        FlexusWorkoutDbContext flexusWorkoutDbContext = new();
        ExerciseService exerciseService = new(flexusWorkoutDbContext);
        var exercises = exerciseService.GetExercisesByType(Name);

        for (int i = 0; i < exercises.Count; i++)
        {
            AddExercise(exercises[i]);
        }
    }
}