using System.ComponentModel.DataAnnotations.Schema;

namespace FlexusWorkout.Models.Concrete;

public class User : Base.Model
{
    //EFCore needs getters and setters for id
    public int? UserId { get; set; } //PK
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public virtual IList<Workout> Workouts { get; set; } = new List<Workout>();

    public virtual IList<WorkoutDay> WorkoutDays { get; set; } = new List<WorkoutDay>();

    [NotMapped] //This does not need to be mapped, only for programming usage
    public bool Authenticated = false;

    public User(string firstName, string lastName, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }
    public User() 
    {
    }
    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}