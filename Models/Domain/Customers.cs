using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models.Domain
{
    
    public class Customers
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdress { get; set; }
        public string Phone { get; set; }
        public int Plan {  get; set; }
    }
}
