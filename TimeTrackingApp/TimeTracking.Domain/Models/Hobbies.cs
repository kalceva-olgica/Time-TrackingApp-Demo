using TimeTracking.Domain.Enums;

namespace TimeTracking.Domain.Models
{
    public class Hobbies : BaseActivity
    {
        public OtherHobbies Hobby { get; set; }

        public Hobbies() { }

        public Hobbies(OtherHobbies hobby)
        {
            Hobby = hobby;
        }

    }
}
