using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Models.Domain
{
    public class GroupTraining
    {
        [Key]
        public int TrainingID { get; set; }

        public string Training {  get; set; }
    }
}
