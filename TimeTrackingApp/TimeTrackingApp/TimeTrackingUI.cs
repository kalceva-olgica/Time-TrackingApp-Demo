using TimeTracking.Domain.Models;
using TimeTracking.Helpers;
using TimeTracking.Services.Enums;
using TimeTracking.Services.Implementation;
using TimeTracking.Services.Interfaces;

namespace TimeTrackingApp
{
    internal class TimeTrackingUI
    {
        private IUserService _userService;
        private readonly IUIService _uiService;

        public TimeTrackingUI()
        {
            _userService = new UserService();
            _uiService = new UIService();
            InitializeStartingData();

        }

        public void InitApp()
        {
            int loginAttempts = 0;

            while (true)
            {
                if (loginAttempts > 3)
                {
                    Console.Clear();
                    ExtendedConsole.PrintInColor("You reached your attempts for login, Goodbye", ConsoleColor.Green);
                    Thread.Sleep(2000);
                    break;
                }
                Console.Clear();

                if (_userService.CurrentUser == null)
                {
                    try
                    {
                        ExtendedConsole.PrintTitle("\n\tTime Tracking App\n");

                        int choice = _uiService.ChooseMenu(new List<string> { "Login", "Register", "Exit" });


                        if (choice == -1)
                        {
                            ExtendedConsole.PrintError("Invalid choice. Please try again ");
                            continue;
                        }

                        if (choice == 1) 
                        {
                            loginAttempts++;

                            var inputUser = _uiService.LoginMenu();
                            _userService.Login(inputUser.Username, inputUser.Password);

                            var user = _userService.CurrentUser;

                            if (user == null)
                            {
                                ExtendedConsole.PrintError($"You have {3 - loginAttempts} attempts left");
                                Thread.Sleep(1500);
                                continue;
                            }

                            if (user.IsDeactivated)
                            {
                                ExtendedConsole.PrintInColor("Do you want to activate your account? [ yes || no ]");
                                string answer = Console.ReadLine();

                                if (answer?.ToLower() == "yes")
                                {
                                    user.IsDeactivated = false;
                                    ExtendedConsole.PrintSuccess("You have activated your account");
                                }
                                else
                                {
                                    ExtendedConsole.PrintError("Your account is deactivated. Please activate it to login");
                                    Thread.Sleep(2000);
                                    _userService.CurrentUser = null;
                                    continue;
                                }
                            }

                            ExtendedConsole.PrintSuccess($"\nWelcome {user.FirstName} {user.LastName}");
                            Thread.Sleep(3000);
                        }
                        else if (choice == 2)
                        {
                            var newUser = _uiService.RegisterMenu();
                            _userService.Insert(newUser);

                            var db = _userService.GetAll();
                            db.ForEach(user => Console.WriteLine($"{user.FirstName} ({user.LastName} - {user.Username})"));
                            Console.ReadLine();
                            continue;
                        }
                        else if (choice == 3)
                        {
                            _uiService.EndMenu();
                            Thread.Sleep(2000);
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        ExtendedConsole.PrintError(ex.Message);
                        continue;
                    }
                }


                loginAttempts = 0;

                int mainChoiceNum = _uiService.MainMenu(_userService.CurrentUser);

                if (mainChoiceNum == -1)
                {
                    ExtendedConsole.PrintError("Invalid choice, Please Try again");
                    continue;
                }

                var mainChoice = _uiService.MainMenuItems[mainChoiceNum - 1];

                switch (mainChoice)
                {
                    case MainMenuChoice.Track:
                        ExtendedConsole.PrintInColor("TRACK MENU", ConsoleColor.Magenta);
                       

                    case MainMenuChoice.UserStatistics:
                     

                    case MainMenuChoice.ManagingAccount:
                        

                    case MainMenuChoice.Logout:
                        Console.Clear();
                        ExtendedConsole.PrintInColor($"\n\n Goodbye {_userService.CurrentUser.Username}. Hope to see you again!", ConsoleColor.Yellow);
                        Thread.Sleep(1500);
                        _userService.CurrentUser = null;
                        continue;
                }

            }

        }

        private void InitializeStartingData()
        {
            User bob = new User("Bob", "Bobsky", 48, "bob111", "Bob111", false);
            User hailey = new User("Hailey", "Haileysky", 28, "hailey123", "Hailey123", false);
            User mia = new User("Mia", "Miasky", 20, "mia222", "Mia123", false);
            User taylor = new User("Taylor", "Swift", 33, "taylor555", "Taylor555", false);
            User amy = new User("Amy", "Gomez", 47, "amy100", "Amy100", false);
            User robin = new User("Robin", "Robovsky", 44, "robin121", "Robin121", false);
            User sara = new User("Sara", "Sarska", 35, "sara444", "Sara444", false);
            User david = new User("David", "Davidskyy", 29, "david789", "David789", false);
            User emily = new User("Emily", "Emilevsky", 27, "emily111", "Emily111", false);
            User alex = new User("Alex", "Stoev", 20, "alex222", "Alex222", false);
            User jerry = new User("Jerry", "Jerrysky", 36, "jerry888", "Jerry888", false);
            User joe = new User("Joe", "Doe", 35, "joe777", "Joe777", false);
            User jason = new User("Jason", "Jackson", 26, "jason333", "Jason333", false);
            User lisa = new User("Lisa", "Lee", 31, "lisa999", "Lisa999", false);
            User chris = new User("Chris", "Lopez", 45, "chris123", "Chris123", false);
            User robinson = new User("Robinson", "Crouse", 31, "robinson555", "Robinson555", false);
            User maria = new User("Maria", "Gomez", 40, "maria123", "Maria123", false);
            List<User> users = new List<User>() { bob, hailey, mia, taylor, amy, robin, sara, david, emily, alex, jerry, joe, jason, lisa, chris, robinson, maria };
            _userService.Seed(users);

        }

    }
}