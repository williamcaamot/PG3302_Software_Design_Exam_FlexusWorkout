using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FlexusWorkout.Services;

public class WorkoutDayService : Service
{
    private FlexusDbContext _db;
    public WorkoutDayService(FlexusDbContext db)
    {
        _db = db;
    }

    public IList<WorkoutDay> getAllWorkoutDays()
    {
        List <WorkoutDay> workoutDays= new();
        workoutDays = _db.WorkoutDay.ToList();
        return workoutDays;
    }


    public WorkoutDay updateWorkoutDay(WorkoutDay workoutDay)
    {
        EntityEntry<WorkoutDay> updatedWorkoutDay = _db.WorkoutDay.Update(workoutDay);
        return updatedWorkoutDay.Entity;
    }

}