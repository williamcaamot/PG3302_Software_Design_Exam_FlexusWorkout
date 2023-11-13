using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Presenters.Base;
using FlexusWorkout.Services.Base;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Base;

namespace FlexusWorkout.Presenters.Workout;

public class CreateWorkoutPresenter : Presenter
{   
    private User _user;
    private FlexusDbContext _db;
    public CreateWorkoutPresenter(User user, View view, Service? service = default) : base(view, service)
    {
        _db = new FlexusWorkoutDbContext();
        _user = user;
        // Run the View loop
        view.Run();
    }

    public override void HandleInput(string? key, string? input)
    {
        if (input == null) {}
        {
            MainHandler("error");
        }
        switch (key)
        {
            case "name":
                break;
        }
    }

    public override void MainHandler(string? input)
    {
        throw new NotImplementedException();
    }
}