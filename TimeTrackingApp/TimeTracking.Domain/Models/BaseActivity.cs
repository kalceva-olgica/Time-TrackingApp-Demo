namespace TimeTracking.Domain.Models
{
    public abstract class BaseActivity
    {
        public double SpentTimeOnActivity { get; set; }
        public string ExtraInformationForActivity { get; set; }
    }
}
