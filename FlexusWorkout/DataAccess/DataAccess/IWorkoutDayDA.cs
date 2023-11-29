using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.DataAccess.DataAccess;

public interface IWorkoutDayDA
{
    public IList<WorkoutDay> GetAllWorkoutDays();
    public WorkoutDay UpdateWorkoutDay(WorkoutDay workoutDay);
}