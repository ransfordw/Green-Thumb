using GreenThumb.Data;
using GreenThumb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Services
{
    public class PlantService
    {
        private readonly Guid _userId;
        public PlantService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePlant(PlantCreate model)
        {
            var entity = new Plant()
            {
                OwnerID = _userId,
                TypeOfPlant = model.TypeOfPlant,
                SoilMix = model.SoilMix,
                WateringFrequency = model.WateringFrequency,
                TimeFertilized = model.TimeFertilized,
                TimeWatered = model.TimeWatered,
                NextWatering = CalculateNextWatering(model.WateringFrequency, model.TimeWatered),
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Plants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public DateTimeOffset CalculateNextWatering(WaterRate waterRate, DateTimeOffset timeLastWatered)
        {
            DateTimeOffset time = DateTimeOffset.Now;
            if (timeLastWatered == null)
            {
                time = timeLastWatered;
            }
            
            switch (waterRate)
            {
                case WaterRate.Daily:
                    time.AddDays(1);
                    break;
                case WaterRate.Weekly:
                    time.AddDays(7);
                    break;
                case WaterRate.Biweekly:
                    time.AddDays(14);
                    break;
                case WaterRate.Monthly:
                    time.AddMonths(1);
                    break;
            }
            return time;
        }
    }
}
