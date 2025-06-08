using TimeTracking.Domain.Enums;

namespace TimeTracking.Domain.Models
{
   public class PlaceToWork : BaseActivity
    {
        public WorkingPlace WorkPlace { get; set; }
        public PlaceToWork() { }
        
    }
}
