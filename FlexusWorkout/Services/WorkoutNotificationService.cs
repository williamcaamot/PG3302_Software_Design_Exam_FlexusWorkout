using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Repository;
using SQLitePCL;

namespace FlexusWorkout.Services;

public class WorkoutNotificationService
{
    // figure out what dates to notify
    // Put this in a loop and run it once a day? (if program keeps running

    private WorkoutDayService _workoutDayService;

    public WorkoutNotificationService(WorkoutDayService workoutDayService)
    {
        _workoutDayService = workoutDayService;
    }

    public async Task NotifyUsersAsync() //Create new context for this
    {
        IList<WorkoutDay> workoutDays = _workoutDayService.GetAllWorkoutDays();
        
        //TODO have a loop for this?
        
        foreach (var workoutDay in workoutDays)
        {
            if (workoutDay.Notified == true)
            {
                return;
            }            
            if (workoutDay.Date == DateTime.Today)
            {

                string emailMessage = $@"Hello, {workoutDay.user.FirstName}, remember, you have a workout to finish today!";
                SendEmail(workoutDay.user.Email, emailMessage);
                workoutDay.Notified = true;
                _workoutDayService.UpdateWorkoutDay(workoutDay);
            }
        }
    }
    public void SendEmail(string email, string message)
    {
        // in a real application this would send an email!
    }
}