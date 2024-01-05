using BookingSystem.Data;
using BookingSystem.Models.Domain;
using BookingSystem.Models.ViewModels;
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
        [BindProperty]
        public TrainingCalendarViewModel AddToSchedule { get; set; }
        public List<Time> Time { get; set; }
        public List<Date> Date { get; set; }
        [BindProperty]
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
        public void OnPost()
        {
            if (AddToSchedule.TrainingID==null)
            {
                var addSchedule = new Schedule
                {
                    Date = AddToSchedule.DateID,
                    Time = AddToSchedule.TimeID,
                    Training = AddToSchedule.TrainingID
                };
            }
            
        }
    }
}
