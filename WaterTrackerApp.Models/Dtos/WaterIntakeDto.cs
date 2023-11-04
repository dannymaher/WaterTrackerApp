using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterTrackerApp.Models.Dtos
{
    public class WaterIntakeDto
    {
        public int Id { get;set; }
        
        public DateTime IntakeDate { get; set; }

        
        public int ConsumedWater { get; set; }

        public int UserID { get; set; }

        public string UserName { get; set; }
    }
}
