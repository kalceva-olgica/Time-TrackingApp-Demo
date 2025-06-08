using TimeTracking.Domain.Enums;

namespace TimeTracking.Domain.Models
{
   public class Exercise : BaseActivity
    {
        public Exercising TypeOfExercise { get; set; }

        public Exercise() { }

        public Exercise(Exercising typeOfExercise)
        {
            TypeOfExercise = typeOfExercise;
        }

    }
}
