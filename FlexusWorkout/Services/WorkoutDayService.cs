using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;

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
        IList<User> users = _db.User.ToList();
        List <WorkoutDay> workoutDays= new();
        foreach (var User in users)
        {
            foreach (WorkoutDay workoutDay in User.WorkoutDays)
            {
                workoutDays.Add(workoutDay);
            }
        }
        return workoutDays;
    }


    public WorkoutDay updateWorkout(WorkoutDay workoutDay)
    {
        return new WorkoutDay();
    }

}