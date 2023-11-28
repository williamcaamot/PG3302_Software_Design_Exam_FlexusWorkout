using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FlexusWorkoutTests.Integration_test;


public class UserServiceTest
{
    [Test]
    public void CreateUser_saves_a_user_via_context()
    {
        var mockSet = new Mock<DbSet<User>>();
        var mockContext = new Mock<FlexusWorkoutDbContext>();
        mockContext.Setup(m => m.User).Returns(mockSet.Object);

        var service = new UserService(mockContext.Object);
        service.RegisterUser("william","test","test@flexus.no","abcd","abcd");
        
        mockSet.Verify(m=>m.Add(It.IsAny<User>()), Times.Once());
        mockContext.Verify(m=>m.SaveChanges(), Times.Once);

    }
    
}