using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FlexusWorkout.DataAccess.DataAccess;

public class MySqlWorkoutDayDA : IWorkoutDayDA
{
    private readonly object _updateLock = new object();
    private IFlexusDbContext _db;
    public MySqlWorkoutDayDA(IFlexusDbContext db)
    {
        _db = db;
    }
    
    public IList<WorkoutDay> GetAllWorkoutDays()
    {
        List <WorkoutDay> workoutDays= new();
        workoutDays = _db.WorkoutDay.ToList();
        return workoutDays;
    }

    public WorkoutDay UpdateWorkoutDay(WorkoutDay workoutDay)
    {
        lock (_updateLock)
        {
            EntityEntry<WorkoutDay> updatedWorkoutDay = _db.WorkoutDay.Update(workoutDay);
            _db.SaveChanges();
            return updatedWorkoutDay.Entity;
        }
    }
}