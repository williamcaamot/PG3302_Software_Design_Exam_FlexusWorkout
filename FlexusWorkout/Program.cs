using FlexusWorkout.Presenters;
using FlexusWorkout.Services.Repository;
using FlexusWorkout.Views.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;

namespace FlexusWorkout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DatabaseFiller databaseFiller = new();
            databaseFiller.runMySqlScript();
            databaseFiller.FillUsers();
            databaseFiller.FillExercises();
            databaseFiller.FillWorkouts();
            databaseFiller.FillWorkoutDays();
            
            

            InitialMenu initialMenu = new();
            InitialMenuPresenter initialMenuPresenter = new(initialMenu);
        }
    }
}