using System.ComponentModel.DataAnnotations;

namespace FlexusWorkout.View_model.User;

public class User
{
    [Key]private int id;
    private string firstName { get; set; }
    private string lastName { get; set; }
    private string username { get; set; }
    //TODO implement workoutprogram
    //TODO implement workoutplan
    public User(string firstName, string lastName, string username)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.username = username;
    }
    public User() 
    {
    }
    public string getFullName()
    {
        return $"{firstName} {lastName}";
    }
    
}