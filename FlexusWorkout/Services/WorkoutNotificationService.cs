using FlexusWorkout.Models.Concrete;
using SQLitePCL;

namespace FlexusWorkout.Services;

public class WorkoutNotificationService
{
    
    private WorkoutDayService _workoutDayService;

    public WorkoutNotificationService(WorkoutDayService workoutDayService)
    {
        _workoutDayService = workoutDayService;
    }

    public async Task NotifyUsersAsync()
    {
        while (true)
        {
            IList<WorkoutDay> workoutDays = _workoutDayService.GetAllWorkoutDays();
            foreach (var workoutDay in workoutDays)
            {
                if (workoutDay.Notified)
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
            Thread.Sleep(36000);
        }
        
    }
    public void SendEmail(string email, string message)
    {
        // in a real application this would send an email!
    }
}