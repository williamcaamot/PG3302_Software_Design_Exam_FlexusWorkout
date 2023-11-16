using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using ZstdSharp.Unsafe;

namespace FlexusWorkoutTests;

public class UserUnitTests
{


    [Test]
    public void CreateUser_AssertProperties()
    {
        // Arrange
        string firstname = "Flexus";
        string lastname = "BigBoy";
        string email = "flexusi@bigboy.com";
        string password = "SuperAdvancedPassword123";

        
        //Act
        User user = new User(firstname, lastname, email, password);
        
        //Assert
        Assert.That(user.FirstName, Is.EqualTo(firstname));
        Assert.That(user.LastName, Is.EqualTo(lastname));
        Assert.That(user.Email, Is.EqualTo(email));
        Assert.That(user.Password, Is.EqualTo(password));

    }
}