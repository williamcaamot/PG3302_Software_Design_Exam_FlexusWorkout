using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using SQLitePCL;

namespace FlexusWorkoutTests.Unit_test;

public class UserServiceTestv3
{
    [Test]
    public void userService()
    {
        var mockSet = new Mock<DbSet<User>>();
        var userData = new List<User>();

        var mockEntry = new Mock<EntityEntry<User>>();

        mockSet.Setup(m => m.Add(It.IsAny<User>())).Callback<User>((user) =>
        {
            userData.Add(user);
            mockEntry.Setup(e => e.Entity).Returns(user);
        }).Returns(mockEntry.Object);
        
        
        var mockContext = new Mock<IFlexusDbContext>();
        mockContext.Setup(m => m.User).Returns(mockSet.Object);
        
        
        
        var service = new UserService(mockContext.Object);
        User user = new User("william", "aamot", "william@aamot.no", "abcd");
        var addedUser = service.Add(user);

        Console.WriteLine(addedUser);
    }
    

}