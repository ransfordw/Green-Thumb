using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.PlantModels
{
    public class PlantCreate
    {
        public PlantType TypeOfPlant { get; set; }
        public SoilType SoilMix { get; set; }
        public WaterRate WateringFrequency { get; set; }

        [DataType(DataType.Date)]
        public DateTimeOffset TimeWatered { get; set; }
        [DataType(DataType.Date)]
        public DateTimeOffset TimeFertilized { get; set; }
    }
}
