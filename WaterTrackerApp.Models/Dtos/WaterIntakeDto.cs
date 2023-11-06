using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterTrackerApp.Models.Dtos
{
    // A class which is populated for transfering water intake information over a network and includes any data which we need in the view which isn't mapped in the db
    public class WaterIntakeDto
    {
        public int Id { get;set; }

        [Required]
        public DateTime IntakeDate { get; set; }


        [Required]
        [Range(1, Int32.MaxValue)]
        public int ConsumedWater { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }
    }
}
