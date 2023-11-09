using FlexusWorkout.View.Menu.Model;

namespace FlexusWorkout.Services;

public class WorkoutService
{
    private FlexusWorkoutDbContext _db;

    public WorkoutService() //TODO should be injected not created
    {
        _db = new FlexusWorkoutDbContext();

    }
    
    


}