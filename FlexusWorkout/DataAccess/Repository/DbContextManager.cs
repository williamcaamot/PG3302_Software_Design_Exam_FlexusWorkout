namespace FlexusWorkout.DataAccess.Repository;

public sealed class DbContextManager
{
    private static MySqlFlexusDbContext _mySqlFlexusDbContext;
    private static readonly object _lock = new object();
    public static MySqlFlexusDbContext Instance
    {
        get
        {
            lock (_lock)
            {
                if (_mySqlFlexusDbContext == null)
                {
                    _mySqlFlexusDbContext = new MySqlFlexusDbContext();

                }
                return _mySqlFlexusDbContext;
            }
            
        }
    }
    
    public static void Dispose()
    {
        lock (_lock)
        {
            _mySqlFlexusDbContext.Dispose();    
        }
    }
}