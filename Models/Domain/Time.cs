using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Models.Domain
{
    public class Time
    {
        [Key]
        public int TimeID { get; set; }
        public DateTime Times { get; set; }
    }
}
