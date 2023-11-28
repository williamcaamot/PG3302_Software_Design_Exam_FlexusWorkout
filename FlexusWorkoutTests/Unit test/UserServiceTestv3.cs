using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace FlexusWorkoutTests.Unit_test;

public class UserServiceTestv3
{
    [Test]
    public void userService()
    {
        var mockSet = new Mock<DbSet<User>>();
        var userData = new List<User>(); // In-memory data store

        // Mock DbSet.Add to add to in-memory store
        mockSet.Setup(m => m.Add(It.IsAny<User>())).Callback<User>((entity) => {
            userData.Add(entity);
        }).Returns((User entity) => new EntityEntry<User>(entity)); // Adjust the return value as needed

        var mockContext = new Mock<IFlexusDbContext>();
        mockContext.Setup(m => m.User).Returns(mockSet.Object);

        // Mock DbContext.SaveChanges to do nothing or return a dummy value
        mockContext.Setup(m => m.SaveChanges()).Returns(1); // Or .Verifiable() if you want to verify it's called

        // Now you can use mockContext.Object in your tests

    }
    

}