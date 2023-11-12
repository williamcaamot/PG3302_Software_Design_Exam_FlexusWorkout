using System.ComponentModel.DataAnnotations.Schema;
using FlexusWorkout.Models.Base;

namespace FlexusWorkout.Models.Concrete;

public class User : Base.Model
{
    //EFCore needs getters and setters for id
    public int? UserId { get; set; } //PK
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    
    public IList<Workout> Workouts { get; set; }
    
    [NotMapped] //This dooes not need to be mapped, only for programming usage
    public bool Authenticated = false;

    //TODO implement workoutprogram FK ish
    public User(string firstName, string lastName, string email, string password)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Password = password;
    }
    public User(string email, string password)
    {
        this.Email = email;
        this.Password = password;
    }
    public User() 
    {
    }
    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}