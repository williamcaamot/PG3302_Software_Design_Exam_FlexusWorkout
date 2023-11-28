using FlexusWorkout.Presenters;
using FlexusWorkout.Services;
using FlexusWorkout.Views.Menu;
using System.Threading.Tasks;
using FlexusWorkout.DataAccess.Repository;

namespace FlexusWorkout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DatabaseFiller databaseFiller = new(DbContextManager.Instance);
                databaseFiller
                    .Fill(); //Keep fill data methods in here and not convert to SQL script, that makes these methods work regardless of what database type / context we use.    
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error connecting to the database " +
                                  "\r\nHave you run 'docker compose up -d'?");
                Console.WriteLine();
                Console.WriteLine("Error message:");
                Console.WriteLine(e.Message);
                return;
            }

            PrintStartUpMessage();
            
            MySqlFlexusDbContext mySqlFlexusDbContext = new MySqlFlexusDbContext();
            WorkoutDayService workoutDayService = new(mySqlFlexusDbContext);
            WorkoutNotificationService workoutNotificationService = new WorkoutNotificationService(workoutDayService);
            Task.Run(() => workoutNotificationService.NotifyUsersAsync());
            
            InitialMenu initialMenu = new();
            InitialMenuPresenter initialMenuPresenter = new(initialMenu);
            
            
        }


        
        private static void PrintStartUpMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
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
            Console.ResetColor();
        }
    }
}