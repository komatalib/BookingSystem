using BookingSystem.Data;
using BookingSystem.Models.Domain;
using BookingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
        [BindProperty]
        public BookingViewModel bookingViewModel { get; set; }
        public List<GroupTraining> GroupTraining { get; set; }
        public List<Time> Time { get; set; }
        public List<Date> Date { get; set; }
        public List<TrainingBooking> TrainingBooking { get; set;}
        public List<Schedule> Schedule { get; set; }
        public List<Customers> Customers { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ScheduleID { get; set; }

        public void OnGet(int ScheduleID)
        {
            Customers = dbContext.Customers.ToList();
            GroupTraining = dbContext.GroupTraining.ToList();
            Time = dbContext.Time.ToList();
            Date = dbContext.Date.ToList();
            TrainingBooking = dbContext.TrainingBooking.ToList();
            Schedule = dbContext.Schedule.ToList();

            var schedule = dbContext.Schedule.FirstOrDefault(s => s.ScheduleID == ScheduleID);

            Console.WriteLine($"Received ScheduleID: {schedule}");

            if (schedule != null)
            {
                TrainingCalendarViewModel = new TrainingCalendarViewModel()
                {
                    ScheduleID = schedule.ScheduleID,
                    TimeID = schedule.Time,
                    DateID = schedule.Date,
                    TrainingID = schedule.Training
                };
                if (bookingViewModel == null)
                {
                    bookingViewModel = new BookingViewModel();
                    { 
                    }
                }

                bookingViewModel.ScheduleID = TrainingCalendarViewModel.ScheduleID;

            }
            else
            {
                Console.WriteLine("NEVEIKIA NEVEIKIA NEVEIKIA");
            }
            

            var booking = dbContext.TrainingBooking.FirstOrDefault(b => b.ScheduleID == ScheduleID);
            if (booking != null)
            {
                bookingViewModel = new BookingViewModel()
                {
                    CustomerID = booking.CustomerID,
                    ScheduleID = booking.ScheduleID

                };
            }
            else
            {
                Console.WriteLine("NEVEIKIA BOOKING NEVEIKIA");
            }
        }
        public IActionResult OnPost()
        {
            if (TrainingCalendarViewModel != null)
            {
                var thisSchedule = dbContext.Schedule.FirstOrDefault(w => w.ScheduleID == ScheduleID);
                if (thisSchedule != null)
                {
                    thisSchedule.Training = TrainingCalendarViewModel.TrainingID; 

                    dbContext.SaveChanges();
                }
            }

                return RedirectToPage("./TrainingsList");
        }
        
        public IActionResult OnGetDelete(int ScheduleID)
        {
            var schedule = dbContext.Schedule.Find(ScheduleID);

            if (schedule == null)
            {
                return NotFound();
            }

            dbContext.Schedule.Remove(schedule);
            dbContext.SaveChanges();

            TempData["Message"] = "Schedule deleted successfully!";
            return RedirectToPage("./TrainingsList");
        }
        public IActionResult OnPostAddToTraining()
        {
            var customerID = bookingViewModel.CustomerID;
            var scheduleID = bookingViewModel.ScheduleID;

            
                    var addBooking = new TrainingBooking
                    {                        
                        CustomerID = customerID,
                        ScheduleID = scheduleID
                    };

                    dbContext.TrainingBooking.Add(addBooking);
                    dbContext.SaveChanges();

            var redirectID = scheduleID;

            return RedirectToPage("./EditSchedule", new { ScheduleID = redirectID });
        }

        public IActionResult OnGetDeleteTraining(int BookingID)
        {
            var booking = dbContext.TrainingBooking.Find(BookingID);
            var scheduleID = booking.ScheduleID;

            if (booking == null)
            {
                return NotFound();
            }

            dbContext.TrainingBooking.Remove(booking);
            dbContext.SaveChanges();


            ViewData["Message"] = "Booking deleted successfully!";
            var redirectID = scheduleID;

            return RedirectToPage("./EditSchedule", new { ScheduleID = redirectID });
        }
    }
}
