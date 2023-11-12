using FlexusWorkout.Models.Base;
using FlexusWorkout.Presenters;
using FlexusWorkout.Presenters.ExerciseFinder;
using FlexusWorkout.Services;
using FlexusWorkout.Views.ExerciseFinder;
using FlexusWorkout.Views.Menu;

namespace FlexusWorkout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseFiller databaseFiller = new();
            databaseFiller.FillUsers();
            databaseFiller.FillExercises();

            InitialMenu initialMenu = new();
            InitialMenuPresenter initialMenuPresenter = new(initialMenu);
        }
    }
}