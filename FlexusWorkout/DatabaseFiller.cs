using FlexusWorkout.Model.Concrete;
using FlexusWorkout.Services;

namespace FlexusWorkout;

    public class DatabaseFiller
    {
        private UserService _userService;

        public DatabaseFiller()
        {
            _userService = new UserService();
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
    }
