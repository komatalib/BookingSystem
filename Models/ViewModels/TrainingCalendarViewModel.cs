using BookingSystem.Models.Domain;

namespace BookingSystem.Models.ViewModels
{
    public class TrainingCalendarViewModel
    {
        public int ScheduleID { get; set; }
        public int TimeID { get; set; }
        public Time Time { get; set; }
        public int DateID { get; set; }
        public Date Date { get; set; }
        public int TrainingID { get; set; }
        public GroupTraining GroupTraining { get; set; }

    }
}
