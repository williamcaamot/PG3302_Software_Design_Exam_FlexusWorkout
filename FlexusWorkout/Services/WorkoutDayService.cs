using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Base;

namespace FlexusWorkout.Services;

public class WorkoutDayService : IService
{
    private MySqlWorkoutDayDA _mySqlWorkoutDayDa;
    public WorkoutDayService(MySqlWorkoutDayDA mySqlWorkoutDayDa)
    {
        _mySqlWorkoutDayDa = mySqlWorkoutDayDa;
    }
    
    public IList<WorkoutDay> GetAllWorkoutDays()
    {
        return _mySqlWorkoutDayDa.GetAllWorkoutDays();
    }
    public WorkoutDay UpdateWorkoutDay(WorkoutDay workoutDay)
    {
        return _mySqlWorkoutDayDa.UpdateWorkoutDay(workoutDay);

    }
        

}