using FlexusWorkout.Models.Base;
using FlexusWorkout.Models.Concrete;
using FlexusWorkout.Services;
using FlexusWorkout.Services.Repository;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;

namespace FlexusWorkout;
    public class DatabaseFiller
    {
        private UserService _userService;
        private ExerciseService _exerciseService;
        private MySqlConnection _mySqlConnectionconn;

        public DatabaseFiller(IFlexusDbContext flexusDbContext)
        {
            _userService = new UserService(flexusDbContext);
            _exerciseService = new ExerciseService(flexusDbContext);
        }

        public void Fill()
        {
            try
            {
                _userService.getUserById(1);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("---- Setting up... Please wait ----");
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
                _userService.registerUser("Markus", "Hagen", "markus@flexus.no", "abcd", "abcd");
                _userService.registerUser("Jovana", "Spasenic", "jovana@flexus.no", "abcd", "abcd");
                _userService.registerUser("Johan", "Svendsen", "johan@flexus.no", "abcd", "abcd");
                _userService.registerUser("William", "Aamot", "william@flexus.no", "abcd", "abcd");
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
            User johan = _userService.GetUserByEmail("johan@flexus.no");
            User jovana = _userService.GetUserByEmail("jovana@flexus.no");
            User markus = _userService.GetUserByEmail("markus@flexus.no");
            User william = _userService.GetUserByEmail("william@flexus.no");
            
            Workout jovanaWorkout = new Workout(
                "Jovanas Balance workout",
                "The perfect balance workout for getting good at stretching and balance!"
                );
            
            jovana.Workouts.Add(jovanaWorkout);
            jovanaWorkout.Exercises.Add(_exerciseService.getRandomExercise("balance"));
            jovanaWorkout.Exercises.Add(_exerciseService.getRandomExercise("balance"));
            _userService.update(jovana);


            Workout johanWorkout = new Workout(
                "Johans Strength Power Madhouse", "Do this to get strong fast!"
            );
            
            johan.Workouts.Add(johanWorkout);
            johanWorkout.Exercises.Add(_exerciseService.getRandomExercise("strength"));
            johanWorkout.Exercises.Add(_exerciseService.getRandomExercise("strength"));
            _userService.update(johan);

            Workout markusCardioWorkout = new Workout(
                "Psycho intervalz", "Don't do this unless you hate yourself");
            
            markus.Workouts.Add(markusCardioWorkout);
            markusCardioWorkout.Exercises.Add(_exerciseService.getRandomExercise("cardio"));
            markusCardioWorkout.Exercises.Add(_exerciseService.getRandomExercise("cardio"));
            _userService.update(markus);

            
            Workout williamStrengthWorkout =
                new Workout("Leg day hell day", "You won't be able to walk for 5 days after this");
            william.Workouts.Add(williamStrengthWorkout);
            williamStrengthWorkout.Exercises.Add(_exerciseService.getRandomExercise("strength"));
            williamStrengthWorkout.Exercises.Add(_exerciseService.getRandomExercise("strength"));
            
            _userService.update(william);
        }

        public void FillWorkoutDays()
        {
                User johan = _userService.GetUserByEmail("johan@flexus.no");
                User jovana = _userService.GetUserByEmail("jovana@flexus.no");
                User markus = _userService.GetUserByEmail("markus@flexus.no");
                User william = _userService.GetUserByEmail("william@flexus.no");
            

                markus.WorkoutDays.Add(new(markus.Workouts.Last(), DateTime.Parse("2023-11-27")));
                markus.WorkoutDays.Add(new(markus.Workouts.Last(), DateTime.Parse("2023-12-05")));
                _userService.update(markus);
            
                johan.WorkoutDays.Add(new(markus.Workouts.Last(), DateTime.Parse("2023-12-12")));
                johan.WorkoutDays.Add(new(markus.Workouts.Last(), DateTime.Parse("2023-12-05")));
                _userService.update(johan);
            
                jovana.WorkoutDays.Add(new(markus.Workouts.Last(), DateTime.Parse("2023-12-12")));
                jovana.WorkoutDays.Add(new(markus.Workouts.Last(), DateTime.Parse("2023-12-05")));
                _userService.update(jovana);
            
                william.WorkoutDays.Add(new(markus.Workouts.Last(), DateTime.Parse("2023-12-12")));
                william.WorkoutDays.Add(new(markus.Workouts.Last(), DateTime.Parse("2023-12-05")));
                _userService.update(william);
            }
        
    }