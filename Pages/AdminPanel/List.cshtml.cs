using BookingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingSystem.Pages.AdminPanel
{
    public class ListModel : PageModel
    {
        private readonly BSDbContext dbContext;
        public List<Models.Domain.Customers> Customers { get; set; }

        public ListModel(BSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            Customers = dbContext.Customers.ToList();
        }
    }
}
