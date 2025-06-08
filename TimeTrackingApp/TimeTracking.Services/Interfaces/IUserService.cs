using TimeTracking.Domain.Models;

namespace TimeTracking.Services.Interfaces
{
   public interface IUserService : IServiceBase<User>
    {
        User CurrentUser { get; set; }
        bool Register(string firstName, string lastName, int age, string username, string password);
        // bool - if the user does not exist, create one, if exists return false
        void Login(string username, string password);
        bool ChangePassword(string addOldPassword, string allNewPassword);
        bool ChangeFirstName(string oldFirstName, string newFirstName);
        bool ChangeLastName(string oldLastName, string newLastName);
        void DeactivateYourAccount();
    }
}
