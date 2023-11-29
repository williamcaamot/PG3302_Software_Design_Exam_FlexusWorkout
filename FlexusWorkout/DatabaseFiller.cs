using FlexusWorkout.DataAccess;
using FlexusWorkout.DataAccess.DataAccess;
using FlexusWorkout.DataAccess.Repository;
using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;

namespace FlexusWorkout;
    public class DatabaseFiller
    {
        private UserService _userService;
        private ExerciseService _exerciseService;
        private MySqlConnection _mySqlConnectionconn;
        private readonly IFlexusDbContext _mySqlFlexusDbContext;
        private readonly MySqlUserDA _mySqlUserDa;

        public DatabaseFiller(IFlexusDbContext flexusDbContext)
        {
            
            _mySqlFlexusDbContext = flexusDbContext;
            _mySqlUserDa = new MySqlUserDA(_mySqlFlexusDbContext);
            _userService = new UserService(_mySqlUserDa);
            _exerciseService = new ExerciseService(flexusDbContext);
        }

        public void Fill()
        {
            try
            {
                _userService.GetUserById(1);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("---- Setting up....Please wait ----");
                Console.WriteLine("------------------------------------");
                runMySqlScript();
                Console.WriteLine("Finished running database setup script");
                FillUsers();
                Console.WriteLine("Finished filling demo users");
                FillExercises();
                Console.WriteLine("Finished filling demo exercises");
                FillWorkouts();
                Console.WriteLine("Finished filling demo workouts");
                FillWorkoutDays();
                Console.WriteLine("Finished filling demo workoutdays");
                Console.WriteLine("Starting program...");
                Thread.Sleep(500);
            }
        }

        public void runMySqlScript()
        {
            string script = File.ReadAllText("Resources/create_tables_and_insert_data.sql");
            using (var _mySqlConnectionconn = new MySqlConnection(
                       "server=localhost;port=3200;database=db;user=root;password=password;ConnectionTimeout=1500;DefaultCommandTimeout=1500")) //Default command timeout increased because of error while running scripts
            {
                _mySqlConnectionconn.Open();
                var commands = script.Split(new[] { ";\r\n", ";\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var cmd in commands)
                {
                    Thread.Sleep(500);
                    if (cmd != null)
                    {
                        using (var command = new MySqlCommand(cmd, _mySqlConnectionconn))
                        {
                            try
                            {
                                command.ExecuteNonQuery(); //Can run any query
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("There was an error while executing SQL commands, see error message:");
                                Console.WriteLine(e.Message);
                                return;
                            }
                        }
                    }
                }
            }
        }
        public void FillUsers()
        {
                _userService.RegisterUser("Ronnie", "Huge", "ronnie@flexus.no", "abcd", "abcd");
                _userService.RegisterUser("John", "Runner", "john@flexus.no", "abcd", "abcd");
                _userService.RegisterUser("Sam", "Sulek", "sam@flexus.no", "abcd", "abcd");
                _userService.RegisterUser("Arnold", "BigGuns", "arnold@flexus.no", "abcd", "abcd");
        }
        
        public void FillExercises()
        {
                var balanceExercises = new List<Exercise>
                {
                    new BalanceExercise("Balance", "Tree Pose", "A pose that replicates the steady stance of a tree.", 5, 1, "Yoga studio"),
                    new BalanceExercise("Balance", "Eagle Pose", "A pose that focuses on balance and stretching of the shoulders.", 5, 2, "Yoga studio"),
                    new BalanceExercise("Balance", "Warrior III", "A challenging pose that combines balance and strength.", 5, 3, "Yoga studio"),
                    new StrengthExercise("Strength", "Bench Press", "An exercise targeting the chest, shoulders, and triceps.", 10, 3, "Bench, Barbell", 4, "Gym"),
                    new StrengthExercise("Strength", "Deadlift", "A compound movement that works the back, glutes, and legs.", 8, 3, "Barbell", 5, "Gym"),
                    new StrengthExercise("Strength", "Squats", "A lower body exercise focusing on the thighs, hips, and buttocks.", 12, 3, "Barbell", 4, "Gym"),
                    new CardioExercise("Cardio", "Running", "A cardiovascular exercise increasing heart rate and burning calories.", 30, "Running Shoes", 4, "Outdoor/Track"),
                    new CardioExercise("Cardio", "Cycling", "An intense cycling workout that improves endurance and strength.", 45,"Bicycle", 3, "Cycling Studio"),
                    new CardioExercise("Cardio", "Jump Rope", "Jumping ropes.", 20,"Jump Rope", 4, "Gym/Outdoor"),
                };
                foreach (var exercise in balanceExercises)
                {
                    exercise.Standard = true;
                    _exerciseService.AddExercise(exercise);
                }
        }

        public void FillWorkouts()
        {
            User ronnie = _userService.GetUserByEmail("ronnie@flexus.no");
            User john = _userService.GetUserByEmail("john@flexus.no");
            User sam = _userService.GetUserByEmail("sam@flexus.no");
            User arnold = _userService.GetUserByEmail("arnold@flexus.no");
            
            Workout ronnieWorkout = new Workout(
                "Ronnies Balance workout",
                "The perfect balance workout for getting good at stretching and balance!"
                );
            
            ronnie.Workouts.Add(ronnieWorkout);
            ronnieWorkout.Exercises.Add(_exerciseService.GetRandomExercise("balance"));
            ronnieWorkout.Exercises.Add(_exerciseService.GetRandomExercise("balance"));
            _userService.Update(john);

            Workout johnWorkout = new Workout(
                "Johns Strength Power Madhouse", "Do this to get strong fast!"
            );
            
            john.Workouts.Add(johnWorkout);
            johnWorkout.Exercises.Add(_exerciseService.GetRandomExercise("strength"));
            johnWorkout.Exercises.Add(_exerciseService.GetRandomExercise("strength"));
            _userService.Update(ronnie);

            Workout samWorkout = new Workout(
                "Psycho intervalz", "Don't do this unless you hate yourself");
            
            sam.Workouts.Add(samWorkout);
            samWorkout.Exercises.Add(_exerciseService.GetRandomExercise("cardio"));
            samWorkout.Exercises.Add(_exerciseService.GetRandomExercise("cardio"));
            _userService.Update(sam);

            
            Workout arnoldWorkout = new Workout("Leg day hell day", "You won't be able to walk for 5 days after this");
            arnold.Workouts.Add(arnoldWorkout);
            arnoldWorkout.Exercises.Add(_exerciseService.GetRandomExercise("strength"));
            arnoldWorkout.Exercises.Add(_exerciseService.GetRandomExercise("strength"));
            
            _userService.Update(arnold);
        }

        public void FillWorkoutDays()
        {
                User ronnie = _userService.GetUserByEmail("ronnie@flexus.no");
                User john = _userService.GetUserByEmail("john@flexus.no");
                User sam = _userService.GetUserByEmail("sam@flexus.no");
                User arnold = _userService.GetUserByEmail("arnold@flexus.no");
            

                sam.WorkoutDays.Add(new(sam.Workouts.Last(), DateTime.Parse("2023-11-27")));
                sam.WorkoutDays.Add(new(sam.Workouts.Last(), DateTime.Parse("2023-12-05")));
                _userService.Update(sam);
            
                ronnie.WorkoutDays.Add(new(sam.Workouts.Last(), DateTime.Parse("2023-12-12")));
                ronnie.WorkoutDays.Add(new(sam.Workouts.Last(), DateTime.Parse("2023-12-05")));
                _userService.Update(ronnie);
            
                john.WorkoutDays.Add(new(sam.Workouts.Last(), DateTime.Parse("2023-12-12")));
                john.WorkoutDays.Add(new(sam.Workouts.Last(), DateTime.Parse("2023-12-05")));
                _userService.Update(john);
            
                arnold.WorkoutDays.Add(new(sam.Workouts.Last(), DateTime.Parse("2023-12-12")));
                arnold.WorkoutDays.Add(new(sam.Workouts.Last(), DateTime.Parse("2023-12-05")));
                _userService.Update(arnold);
            }
        
    }