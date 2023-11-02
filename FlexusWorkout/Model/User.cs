using System.ComponentModel.DataAnnotations;

namespace FlexusWorkout.View_model.User;

public class User
{
    [Key]
    public int? UserId { get; set; } //EFCore needs getters and setters for id
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    
    public bool Authenticated = false;

    //TODO implement workoutprogram
    //TODO implement workoutplan
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