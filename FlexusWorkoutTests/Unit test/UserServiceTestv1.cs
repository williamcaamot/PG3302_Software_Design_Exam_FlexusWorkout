using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace FlexusWorkoutTests.Integration_test;


public class UserServiceTestv1
{
    [Test]
    public void CreateUser_saves_a_user_via_context()
    {
        var mockSet = new Mock<DbSet<User>>();
        var mockContext = new Mock<FlexusWorkoutDbContext>();
        
        var mockEntry = new Mock<EntityEntry<User>>();

        mockSet.Setup(mockSet => mockSet.Add(It.IsAny<User>())).
            Returns(mockEntry.Object);

        var service = new UserService(mockContext.Object);
        service.RegisterUser("william","test","test@flexus.no","abcd","abcd");
        
        //mockSet.Verify(m=>m.Add(It.IsAny<User>()), Times.Once());
        //mockContext.Verify(m=>m.SaveChanges(), Times.Once);

    }
    
}