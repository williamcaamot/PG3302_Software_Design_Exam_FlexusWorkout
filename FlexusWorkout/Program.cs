using FlexusWorkout.Model.Concrete;
using FlexusWorkout.Presenter;
using FlexusWorkout.Services;
using FlexusWorkout.View.Menu;

namespace FlexusWorkout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //User user = new("Test", "User", "bor@gmail.com", "password");
            //UserService userService = new();
            //User addeduser = userService.Add(user);

            InitialMenu initialMenu = new();
            InitialMenuPresenter initialMenuPresenter = new(initialMenu);

        }
    }
}