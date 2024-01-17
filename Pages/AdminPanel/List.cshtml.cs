using BookingSystem.Data;
using BookingSystem.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingSystem.Pages.AdminPanel
{
    public class ListModel : PageModel
    {
        private readonly BSDbContext dbContext;
        public List<Customers> Customers { get; set; }
        [BindProperty]
        public List<Plans> Plans { get; set; }
        public int CustomerID { get; set; }

        public ListModel(BSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Plans = dbContext.Plans.ToList();
            Customers = dbContext.Customers.ToList();
        }
        public IActionResult OnGetDelete(int CustomerID)
        {
            var customer = dbContext.Customers.Find(CustomerID);

            if (customer == null)
            {
                return NotFound();
            }

            dbContext.Customers.Remove(customer);
            dbContext.SaveChanges();


            ViewData["Message"] = "Customer deleted successfully!";
            return RedirectToPage("/AdminPanel/List");
        }
    }
}
