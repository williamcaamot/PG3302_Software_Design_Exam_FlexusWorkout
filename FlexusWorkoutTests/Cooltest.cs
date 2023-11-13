using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;

namespace FlexusWorkoutTests;

public class Cooltest
{
    [Test]
    public void williamtest()
    {
        FlexusWorkoutDbContext flexusWorkoutDbContext = new();
        UserService userService = new(flexusWorkoutDbContext);
        User user = userService.getUserById(30);

        Console.WriteLine("test");
        
        
    }
}