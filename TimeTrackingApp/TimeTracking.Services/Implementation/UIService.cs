using TimeTracking.Domain.Models;
using TimeTracking.Helpers;
using TimeTracking.Services.Enums;
using TimeTracking.Services.Interfaces;

namespace TimeTracking.Services.Implementation
{
    public class UIService : IUIService
    {
        public List<MainMenuChoice> MainMenuItems { get; set; }
        private UserService _userService;

        public UIService()
        {
            _userService = new UserService();
        }

        public User RegisterMenu()
        {
            while (true)
            {
                Console.Clear();
                ExtendedConsole.PrintInColor("\nEnter your credentials:", ConsoleColor.Cyan);
                string firstName = ExtendedConsole.GetInput("First name: ");
                string lastName = ExtendedConsole.GetInput("Last name: ");
                string age = ExtendedConsole.GetInput("Age: ");
                bool isValidAge = int.TryParse(age, out int parsedAge);
                if (!isValidAge)
                {
                    ExtendedConsole.PrintError("Please enter valid age number");
                    Thread.Sleep(2000);
                    continue;
                }
                string username = ExtendedConsole.GetInput("Username: ");
                string password = ExtendedConsole.GetInput("Password: ");
                if (!ValidationHelper.ValidInputLength(username, 5) || !ValidationHelper.ValidInputLength(password, 6) ||
                !ValidationHelper.ValidatePassword(password) || !ValidationHelper.ValidFirstAndLastName(firstName, lastName) ||
                !ValidationHelper.AgeValidation(parsedAge, 18, 120))
                {
                    ExtendedConsole.PrintError("Please enter valid inputs!");
                    Thread.Sleep(2000);
                    continue;
                }
                if (_userService.Register(firstName, lastName, parsedAge, username, password))
                {
                    return new User(firstName, lastName, parsedAge, username, password, false);

                }
                else
                {
                    ExtendedConsole.PrintError("User with the same username already exists in our system");
                    Thread.Sleep(2000);
                }
            }
        }
        public User LoginMenu()
        {
            Console.Clear();
            ExtendedConsole.PrintInColor("\nEnter your credentials:", ConsoleColor.Cyan);
            string username = ExtendedConsole.GetInput("Username: ");
            string password = ExtendedConsole.GetInput("Password: ");

            if (!ValidationHelper.ValidateStringInput(username) ||
                !ValidationHelper.ValidateStringInput(password))
            {
                throw new Exception("Please enter valid inputs");
            }

            return new User
            {
                Username = username,
                Password = password
            };

        }
        public int ChooseMenu<T>(List<T> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {items[i]}");
            }

            int choice = ValidationHelper.ValidateNumberInput(Console.ReadLine(), items.Count);
            return choice;
        }

        public int MainMenu(User user)
        {
            while (true)
            {
                Console.Clear();
                ExtendedConsole.PrintTitle($"\n\t{user.FirstName.ToString().ToUpper()} {user.LastName.ToString().ToUpper()} main menu \n\n");
                MainMenuItems = GetMainMenuOptions();
                int userChoice = ChooseMenu(MainMenuItems);
                if (userChoice == -1)
                {
                    ExtendedConsole.PrintError("Invalid choice! Please try again");
                    continue;
                }
                return userChoice;
            }
        }
        private List<MainMenuChoice> GetMainMenuOptions()
        {
            return new List<MainMenuChoice>()
            {
                MainMenuChoice.Track,
                MainMenuChoice.UserStatistics,
                MainMenuChoice.ManagingAccount,
                MainMenuChoice.Logout,
            };
        }
        public void EndMenu()
        {
            Console.Clear();
            ExtendedConsole.PrintTitle("\n\n\n\n\n\n       Thank you for using our application ");
            Console.ReadLine();
        }
    }
}
