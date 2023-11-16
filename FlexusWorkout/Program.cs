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
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(@"           ______   _        ______  __   __  _    _    _____                ");
            Console.WriteLine(@"          |  ____| | |      |  ____| \ \ / / | |  | |  / ____|               ");
            Console.WriteLine(@"          | |__    | |      | |__     \ V /  | |  | | | (___                 ");
            Console.WriteLine(@"          |  __|   | |      |  __|     > <   | |  | |  \___ \                ");
            Console.WriteLine(@"          | |      | |____  | |____   / . \  | |__| |  ____) |               ");
            Console.WriteLine(@"          |_|      |______|_|______|_/_/ \_\_ \____/__|_____/    _   _______ ");
            Console.WriteLine(@"          \ \        / /  / __ \  |  __ \  | |/ /  / __ \  | |  | | |__   __|");
            Console.WriteLine(@"           \ \  /\  / /  | |  | | | |__) | | ' /  | |  | | | |  | |    | |   ");
            Console.WriteLine(@"            \ \/  \/ /   | |  | | |  _  /  |  <   | |  | | | |  | |    | |   ");
            Console.WriteLine(@"             \  /\  /    | |__| | | | \ \  | . \  | |__| | | |__| |    | |   ");
            Console.WriteLine(@"              \/  \/      \____/  |_|  \_\ |_|\_\  \____/   \____/     |_|   ");
            Thread.Sleep(2000);
            DatabaseFiller databaseFiller = new();
            databaseFiller.runMySqlScript();
            databaseFiller.FillUsers(); //Keep fill data methods in here and not convert to SQL script, that makes these methods works regardless of what database type / context we use.
            databaseFiller.FillExercises();
            databaseFiller.FillWorkouts();
            //databaseFiller.FillWorkoutDays();
            
            

            InitialMenu initialMenu = new();
            InitialMenuPresenter initialMenuPresenter = new(initialMenu);
        }
    }
}