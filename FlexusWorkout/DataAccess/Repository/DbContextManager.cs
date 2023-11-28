namespace FlexusWorkout.DataAccess.Repository;

public class DbContextManager
{
    private static MySqlFlexusDbContext _mySqlFlexusDbContext;
    public static MySqlFlexusDbContext Instance
    {
        get
        {
            if (_mySqlFlexusDbContext == null)
            {
                _mySqlFlexusDbContext = new MySqlFlexusDbContext();

            }
            return _mySqlFlexusDbContext;
        }
    }


    public static void Dispose()
    {
        _mySqlFlexusDbContext.Dispose();
    }
}