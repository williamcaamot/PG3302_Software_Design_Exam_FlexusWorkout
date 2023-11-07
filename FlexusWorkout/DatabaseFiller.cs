using FlexusWorkout.Model.Base;
using FlexusWorkout.Model.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkout;

    public class DatabaseFiller
    {
        private UserService _userService;
        private ExerciseService _exerciseService;

        public DatabaseFiller()
        {
            _userService = new UserService();
            _exerciseService = new ExerciseService();
        }

        public void FillUsers()
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
                _userService.Add(newUser);
            }
        }
        
        public void FillExercises()
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
        
        
    }
