using BookingSystem.Data;
using BookingSystem.Models.Domain;
using BookingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingSystem.Pages.AdminPanel
{
    public class IndexModel : PageModel
    {
        private readonly BSDbContext dbContext;

        public IndexModel(BSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddCustomerViewModel AddCustomer { get; set; }
        [BindProperty]
        public List<Plans> Plans { get; set; }
        public void OnGet()
        {
            Plans = dbContext.Plans.ToList();
        }

        public void OnPost()
        {
            var addCustomerModel = new Customers
            {
                FirstName = AddCustomer.FirstName,
                LastName = AddCustomer.LastName,
                EmailAdress = AddCustomer.EmailAdress,
                Phone = AddCustomer.Phone,
                Plan = AddCustomer.Plan
            };

            dbContext.Customers.Add(addCustomerModel);
            dbContext.SaveChanges();

            ViewData["Message"] = "Customer Created Successfully!";
        }
    }
}
