using FlexusWorkout.Presenters;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FlexusWorkout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DatabaseFiller databaseFiller = new();
            //databaseFiller.FillUsers();
            //databaseFiller.FillExercises();

            InitialMenu initialMenu = new();
            InitialMenuPresenter initialMenuPresenter = new(initialMenu);
        }
    }
}