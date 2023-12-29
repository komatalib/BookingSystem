using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models.Domain
{
    public class Date
    {
        [Key]
        public int DateID { get; set; }
        public DateTime Dates {  get; set; }
    }
}
