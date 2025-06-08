using TimeTracking.Domain.Enums;

namespace TimeTracking.Domain.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsDeactivated { get; set; } = false; // for deactivating account
        public List<Exercise> Exercising { get; set; } = new List<Exercise>();
        public List<Read> Reading { get; set; } = new List<Read>();
        public List<PlaceToWork> Working { get; set; } = new List<PlaceToWork>();
        public List<Hobbies> SomeHobbies { get; set; } = new List<Hobbies>();
        public User() { }

        public User(string firstName, string lastName, int age, string username, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Username = username;
            Password = password;

        }
        public User(string firstName, string lastName, int age, string username, string password, bool isDeactivated)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Username = username;
            Password = password;
            IsDeactivated = isDeactivated;
        }
        public override string GetInfo()
        {
            return $"User informations: {FirstName} {LastName} - {Age} years old with username {Username}.";
        }


    }
}
