using FlexusWorkout.Presenters;
using FlexusWorkout.Services;
using FlexusWorkout.Views.Menu;
using System.Threading.Tasks;
using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;

namespace FlexusWorkout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Initial setup of database
            try
            {
                DatabaseFiller databaseFiller = new(DbContextManager.Instance);
                databaseFiller.Fill();    
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
            
            //Starting background service notification
            MySqlFlexusDbContext mySqlFlexusDbContext = new MySqlFlexusDbContext();
            MySqlWorkoutDayDA mySqlWorkoutDayDa = new MySqlWorkoutDayDA(mySqlFlexusDbContext);
            WorkoutDayService workoutDayService = new(mySqlWorkoutDayDa);
            WorkoutNotificationService workoutNotificationService = new WorkoutNotificationService(workoutDayService);
            Task.Run(() => workoutNotificationService.NotifyUsersAsync());
            
            //Starting main program
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