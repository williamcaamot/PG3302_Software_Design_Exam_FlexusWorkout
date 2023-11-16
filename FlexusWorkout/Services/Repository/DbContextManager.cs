namespace FlexusWorkout.Services.Repository;

public class DbContextManager
{
    private static FlexusWorkoutDbContext _instance;
    public static FlexusWorkoutDbContext Instance
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


    public static void Dispose()
    {
        _instance.Dispose();
    }
}