using TimeTracking.Domain.Enums;

namespace TimeTracking.Domain.Models
{
   public class Read : BaseActivity
    {
        public KindOfBook KindOfBook { get; set; }
        public int NumberOfPages { get; set; }

        public Read() { }
        // empty constructor if deserialization is needed
       
        public Read(KindOfBook kindOfBook, int numberOfPages)
        {
            KindOfBook = kindOfBook;
            NumberOfPages = numberOfPages;
        }

    }
}
