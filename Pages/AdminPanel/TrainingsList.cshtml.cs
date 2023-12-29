using BookingSystem.Data;
using BookingSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Pages.AdminPanel
{
    public class TrainingsListModel : PageModel
    {
        private readonly BSDbContext dbContext;
        public TrainingsListModel(BSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Time> Time { get; set; }
        public List<Date> Date { get; set; }
        public List<Schedule> Schedule { get; set; }
        public List<TrainingBooking> TrainingBooking { get; set; }
        public List<GroupTraining> GroupTraining { get; set; }

        public void OnGet()
        {
            Time = dbContext.Time.ToList();
            Date = dbContext.Date.ToList();
            Schedule = dbContext.Schedule.ToList();
            TrainingBooking = dbContext.TrainingBooking.ToList();
            GroupTraining = dbContext.GroupTraining.ToList();
        }
    }
}
