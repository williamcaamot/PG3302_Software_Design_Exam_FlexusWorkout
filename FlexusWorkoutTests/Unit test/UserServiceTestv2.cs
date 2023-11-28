using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FlexusWorkoutTests.Unit_test;

public class UserServiceTestv2
{
    [Test]
    public void CreateUser_saves_a_user_via_context()
    {
        var data = new List<User>
        {
            new User { FirstName= "Markus" },
            new User { FirstName = "Johan" },
            new User
            {
                FirstName = "william",
            },
        }.AsQueryable();
        
        
        var mockSet = new Mock<DbSet<User>>();
        mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
        mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());
        
        
        var mockContext = new Mock<IFlexusDbContext>();
        
        mockContext.Setup(m => m.User).Returns(mockSet.Object);

        var service = new UserService(mockContext.Object);
        service.registerUser("william","test","test@flexus.no","abcd","abcd");
        
        mockSet.Verify(m=>m.Add(It.IsAny<User>()), Times.Once());
        mockContext.Verify(m=>m.SaveChanges(), Times.Once);

    }
}