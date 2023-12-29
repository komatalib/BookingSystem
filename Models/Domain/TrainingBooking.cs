using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models.Domain
{
    public class TrainingBooking
    {
        [Key]
        public int BookingID { get; set; }
        public int ScheduleID { get; set; }
        public int CustomerID { get; set; }

    }
}
