using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.Plant
{
    public class PlantCreate
    {
        public PlantType TypeOfPlant { get; set; }
        public SoilType SoilMix { get; set; }
        public WaterRate WateringFrequency { get; set; }
        public DateTimeOffset TimeWatered { get; set; }
        public DateTimeOffset TimeFertilized { get; set; }
        public DateTimeOffset NextWatering { get; set; }
    }
}
