using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models.Domain
{
    public class Plans
    {
        [Key]
        public int PlanID { get; set; }
        public string Plan { get; set; }
    }
}
