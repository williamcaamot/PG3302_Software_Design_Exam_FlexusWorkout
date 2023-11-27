using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Repository;

namespace FlexusWorkout.Services;

public class WorkoutNotificationService
{
    // get all workoutdays - create a service for this
    // figure out what dates to notify
    //create a dbcontext here (NOT THE SAME AS THE REST OF APPLICATION
    // Put this in a loop and run it once a day? (if program keeps running


    private WorkoutDayService _workoutDayService;

    public WorkoutNotificationService(WorkoutDayService workoutDayService)
    {
        _workoutDayService = workoutDayService;
    }

    public async Task notifyUsersAsync() //Create new context for this
    {
        IList<WorkoutDay> workoutDays = _workoutDayService.getAllWorkoutDays();

    }

}