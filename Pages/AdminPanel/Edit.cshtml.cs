using BookingSystem.Data;
using BookingSystem.Models.Domain;
using BookingSystem.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Pages.AdminPanel
{
    public class EditModel : PageModel
    {
        private readonly BSDbContext dbContext;

        [BindProperty(SupportsGet = true)]
        public int CustomerID { get; set; }
        [BindProperty]
        public EditCustomerViewModel EditCustomerViewModel { get; set; }
        [BindProperty]
        public List<Plans> Plans { get; set; }
        public EditModel(BSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
            Plans = dbContext.Plans.ToList();

            var customer = dbContext.Customers.Find(CustomerID);

            if (customer != null)
            {
                EditCustomerViewModel = new EditCustomerViewModel()
                {
                    LastName = customer.LastName,
                    Phone = customer.Phone,
                    FirstName = customer.FirstName,
                    EmailAdress = customer.EmailAdress,
                    PlanID = customer.PlanID
                };
            }
        }
        public IActionResult OnPost()
        {
            if (EditCustomerViewModel != null)
            {
                

                var currentCustomer = dbContext.Customers.FirstOrDefault(w => w.CustomerID == CustomerID);
                if (currentCustomer != null)
                {
                    currentCustomer.LastName = EditCustomerViewModel.LastName;
                    currentCustomer.Phone = EditCustomerViewModel.Phone;
                    currentCustomer.FirstName = EditCustomerViewModel.FirstName;
                    currentCustomer.EmailAdress = EditCustomerViewModel.EmailAdress;
                    currentCustomer.PlanID = EditCustomerViewModel.PlanID;

                    dbContext.SaveChanges();
                }

                
            }
            return RedirectToPage("/AdminPanel/List");
        }

    }
}
