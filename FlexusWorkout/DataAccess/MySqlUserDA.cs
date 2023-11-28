using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;

namespace FlexusWorkout.DataAccess;

public class MySqlUserDA : IUserDA
{
    private IFlexusDbContext _db;
    public MySqlUserDA(IFlexusDbContext db)
    {
        _db = db;
    }


    public User Add(User user)
    {
        throw new NotImplementedException();
    }
}