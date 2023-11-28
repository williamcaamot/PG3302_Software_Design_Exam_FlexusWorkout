namespace FlexusWorkout.DataAccess.Repository;

public class DbContextManager
{
    private static FlexusWorkoutDbContext _flexusWorkoutDbContext;
    public static FlexusWorkoutDbContext Instance
    {
        get
        {
            if (_flexusWorkoutDbContext == null)
            {
                _flexusWorkoutDbContext = new FlexusWorkoutDbContext();

            }
            return _flexusWorkoutDbContext;
        }
    }


    public static void Dispose()
    {
        _flexusWorkoutDbContext.Dispose();
    }
}