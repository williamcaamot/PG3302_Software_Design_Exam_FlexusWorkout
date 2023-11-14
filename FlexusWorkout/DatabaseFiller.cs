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

            conn = new MySqlConnection("server=localhost;port=3200;database=db;user=user;password=password;");
            conn.Open();
            string script = File.ReadAllText("Resources/create_tables_and_insert_data.sql");
        }

        public void FillUsers()
        {
            if (_userService.getUserById(1) == null)
            {
                for (int i = 1; i <= 20; i++)
                {
                    // Generate a new user with some dummy data
                    User newUser = new User
                    {
                        FirstName = $"Test{i}",
                        LastName = $"User{i}",
                        Email = $"test{i}@example.com",
                        Password = $"password{i}" // This will be hashed in the Add method
                    };

                    // Add the new user to the database
                    _userService.registerUser(newUser);
                }
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
                    new CardioExercise("Cardio", "Jump Rope", "En kul treningsøkt.", 20, null, null, "Jump Rope", 4, "Gym/Outdoor"),

                
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

        public void fillWorkouts()
        {
            User user = _userService.getUserById(1);
            
            Workout workout = new Workout(
                "NewWorkout",
                "This is a cool workout"
                )
            {
                User = user
            };

            workout = _workoutService.addWorkout(workout);
            
            workout.Exercises.Add(_exerciseService.GetExercise(1));
            workout.Exercises.Add(_exerciseService.GetExercise(2));

            workout = _workoutService.updateWorkout(workout);
        }
    }