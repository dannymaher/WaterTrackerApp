using System.ComponentModel.DataAnnotations;

namespace WaterTrackerAPI.Entities
{
    public class User
    {
        //A model which maps to the DB User table
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
