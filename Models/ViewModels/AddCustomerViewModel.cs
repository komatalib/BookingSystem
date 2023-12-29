using BookingSystem.Models.Domain;

namespace BookingSystem.Models.ViewModels
{
    public class AddCustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public string Phone { get; set; }
        public int PlanID { get; set; }
        public Plans Plans { get; set; }
    }
}
