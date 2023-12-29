using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models.Domain
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public int Date { get; set; }
        public int Time { get; set; }
        public int Training {  get; set; }
    }
}
