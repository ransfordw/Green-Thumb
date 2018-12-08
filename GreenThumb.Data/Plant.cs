using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public enum PlantType { Cactus, Succulent, Orchid, Tree, Flower}
    public enum SoilType { Potting, Cactus, Bonzai }
    public enum WaterRate { Daily, Weekly, Biweekly, Monthly}

    public class Plant
    {
        [Key]
        public int PlantID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        public PlantType TypeOfPlant { get; set; }
        public SoilType SoilMix { get; set; }
        public WaterRate WateringFrequency { get; set; }
        public DateTimeOffset TimeWatered { get; set; }
        public DateTimeOffset TimeFertilized { get; set; }
        public DateTimeOffset NextWatering { get; set; }
    }
}
