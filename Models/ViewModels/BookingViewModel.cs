using BookingSystem.Models.Domain;

namespace BookingSystem.Models.ViewModels
{
    public class BookingViewModel
    {
        public int BookingID { get; set; }
        public int ScheduleID { get; set; }
        public Schedule Schedule { get; set; }
        public int CustomerID { get; set; }
        public Customers Customers { get; set; }
    }
}
