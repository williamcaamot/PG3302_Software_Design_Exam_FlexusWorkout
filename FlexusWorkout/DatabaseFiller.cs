using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using MySql.Data.MySqlClient;

namespace FlexusWorkout;
    public class DatabaseFiller
    {
        private UserService _userService;
        private ExerciseService _exerciseService;
        private WorkoutService _workoutService;
        private MySqlConnection conn;

        public DatabaseFiller()
        {
            FlexusDbContext flexusWorkoutDbContext = DbContextManager.Instance;
            _userService = new UserService(flexusWorkoutDbContext);
            _exerciseService = new ExerciseService(flexusWorkoutDbContext);
            _workoutService = new(flexusWorkoutDbContext);

            
        }

        public void runMySqlScript()
        {

            try
            {
                _exerciseService.GetExercise(1);
            }
            catch (Exception e)
            {
                    Console.Clear();
                    Console.WriteLine("------------------------------------------------------------");
                    Console.WriteLine("---- INITIAL SETUP - WAIT WHILE DATABASE IS INITIALIZED ----");
                    Console.WriteLine("------------------------------------------------------------");
                    string script = File.ReadAllText("Resources/create_tables_and_insert_data.sql");
                    using (var conn = new MySqlConnection(
                               "server=localhost;port=3200;database=db;user=root;password=password;ConnectionTimeout=1500;DefaultCommandTimeout=1500"))
                    {
                        conn.Open();
                        var commands = script.Split(new[] { ";\r\n", ";\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var cmd in commands)
                        {
                            Thread.Sleep(500);
                            if (cmd != null)
                            {
                                using (var command = new MySqlCommand(cmd, conn))
                                {
                                    command.CommandTimeout = 300; // Increase timeout to 300 seconds
                                    try
                                    {
                                        command.ExecuteNonQuery(); //Can run any query
                                    }
                                    catch (MySqlException ex)
                                    {
                                        Console.WriteLine("Error encountered executing the following SQL:");
                                        Console.WriteLine(cmd);
                                        Console.WriteLine("Error details:");
                                        Console.WriteLine(ex.Message);
                                        break; // Stop execution on error
                                    }
                                }
                            }
                        }
                    
                    }
            }
        }
        public void FillUsers()
        {
            if (_userService.getUserById(1) == null)
            {
                _userService.registerUser("Markus", "Hagen", "markus@flexus.no", "abcd", "abcd");
                _userService.registerUser("Jovana", "Spasenic", "jovana@flexus.no", "abcd", "abcd");
                _userService.registerUser("Johan", "Svendsen", "johan@flexus.no", "abcd", "abcd");
                _userService.registerUser("William", "Aamot", "william@flexus.no", "abcd", "abcd");
               
            }
            else
            {
                return;
            }
        }
        
        public void FillExercises()
        {
            if (_exerciseService.GetExercise(1) == null)
            {
                var balanceExercises = new List<Exercise>
                {
                    new BalanceExercise("Balance", "Tree Pose", "A pose that replicates the steady stance of a tree.", 5, null, null, null, 1, "Yoga studio"),
                    new BalanceExercise("Balance", "Eagle Pose", "A pose that focuses on balance and stretching of the shoulders.", 5, null, null, null, 2, "Yoga studio"),
                    new BalanceExercise("Balance", "Warrior III", "A challenging pose that combines balance and strength.", 5, null, null, null, 3, "Yoga studio"),
                    new StrengthExercise("Strength", "Bench Press", "An exercise targeting the chest, shoulders, and triceps.", null, 10, 3, "Bench, Barbell", 4, "Gym"),
                    new StrengthExercise("Strength", "Deadlift", "A compound movement that works the back, glutes, and legs.", null, 8, 3, "Barbell", 5, "Gym"),
                    new StrengthExercise("Strength", "Squats", "A lower body exercise focusing on the thighs, hips, and buttocks.", null, 12, 3, "Barbell", 4, "Gym"),
                    new CardioExercise("Cardio", "Running", "A cardiovascular exercise increasing heart rate and burning calories.", 30, null, null, "Running Shoes", 4, "Outdoor/Track"),
                    new CardioExercise("Cardio", "Cycling", "An intense cycling workout that improves endurance and strength.", 45, null, null, "Bicycle", 3, "Cycling Studio"),
                    new CardioExercise("Cardio", "Jump Rope", "Jumping ropes.", 20, null, null, "Jump Rope", 4, "Gym/Outdoor"),
                };
                foreach (var exercise in balanceExercises)
                {
                    _exerciseService.AddExercise(exercise);
                }
            }
            else
            {
                return;
            }
            
        }

        public void FillWorkouts()
        {
            User johan = _userService.GetUserByEmail("johan@flexus.no");
            User jovana = _userService.GetUserByEmail("jovana@flexus.no");
            User markus = _userService.GetUserByEmail("markus@flexus.no");
            User william = _userService.GetUserByEmail("william@flexus.no");
            
            
            Workout jovanaWorkout = new Workout(
                "Jovanas Balance workout",
                "The perfect balance workout for getting good at stretching and balance!"
                )
            {
                User = jovana
            };
            jovanaWorkout = _workoutService.addWorkout(jovanaWorkout);
            jovanaWorkout = _workoutService.addExercise(jovanaWorkout, _exerciseService.getRandomExercise("balance"));
            jovanaWorkout = _workoutService.addExercise(jovanaWorkout, _exerciseService.getRandomExercise("balance"));
            
            

        }

        public void FillWorkoutDays()
        {
            User user = _userService.getUserById(1);

            WorkoutDay workoutDay1 = new();
            workoutDay1.Date = DateOnly.Parse("2023-12-12");
            workoutDay1.Workout = user.Workouts[1];

            _userService.addWorkoutDay(user, workoutDay1);
            
            WorkoutDay workoutDay2 = new();
            workoutDay2.Date = DateOnly.Parse("2023-12-14");
            workoutDay2.Workout = user.Workouts[2];

            _userService.addWorkoutDay(user, workoutDay2);
            
            WorkoutDay workoutDay3 = new();
            workoutDay3.Date = DateOnly.Parse("2023-12-17");
            workoutDay3.Workout = user.Workouts[3];

            _userService.addWorkoutDay(user, workoutDay3);
        }
    }