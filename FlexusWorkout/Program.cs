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
            DatabaseFiller databaseFiller = new();
            databaseFiller.FillUsers();
            

            //InitialMenu initialMenu = new();
            //InitialMenuPresenter initialMenuPresenter = new(initialMenu);

        }
    }
}