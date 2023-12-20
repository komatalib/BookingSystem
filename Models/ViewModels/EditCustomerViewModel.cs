namespace BookingSystem.Models.ViewModels
{
    public class EditCustomerViewModel
    {
        public Guid CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public string Phone { get; set; }
        public int Plan { get; set; }
    }
}
