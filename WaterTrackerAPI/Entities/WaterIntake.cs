using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaterTrackerAPI.Entities
{
    public class WaterIntake
    {
        //A model which maps to the DB WaterIntake table
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime IntakeDate {  get; set; }

        [Required]
        [MinLength(0)]
        [MaxLength(Int32.MaxValue)]
        public int ConsumedWater {  get; set; }
        
        public int UserID {  get; set; }

        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
    }
}
