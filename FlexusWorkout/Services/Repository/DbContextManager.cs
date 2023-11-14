namespace FlexusWorkout.Services.Repository;

public class DbContextManager
{
    private static FlexusDbContext _instance;
    public static FlexusDbContext Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new FlexusWorkoutDbContext();
            }
            return _instance;
        }
    }
}