using BookingSystem.Data;
using BookingSystem.Models.Domain;
using BookingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Pages.AdminPanel
{
    public class EditScheduleModel : PageModel
    {
        private readonly BSDbContext dbContext;

        public EditScheduleModel(BSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [BindProperty]
        public TrainingCalendarViewModel TrainingCalendarViewModel { get; set; }
        public List<GroupTraining> GroupTraining { get; set; }
        public List<Time> Time { get; set; }
        public List<Date> Date { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ScheduleID { get; set; }

        public void OnGet()
        {
            GroupTraining = dbContext.GroupTraining.ToList();
            Time = dbContext.Time.ToList();
            Date = dbContext.Date.ToList();

            var schedule = dbContext.Schedule.Find(ScheduleID);

            if (schedule != null)
            {
                TrainingCalendarViewModel = new TrainingCalendarViewModel()
                {
                    ScheduleID = schedule.ScheduleID,
                    TimeID = schedule.Time,
                    DateID = schedule.Date,
                    TrainingID = schedule.Training
                };
            }
        }
    }
}
