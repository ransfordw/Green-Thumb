using GreenThumb.Data;
using GreenThumb.Models.Plant;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<PlantListItem> GetPlants()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                       .Plants
                       .Where(e => e.OwnerID == _userId)
                       .Select(
                        e =>
                        new PlantListItem
                        {
                            PlantID = e.PlantID,
                            TypeOfPlant = e.TypeOfPlant,
                            SoilMix = e.SoilMix,
                            WateringFrequency = e.WateringFrequency,
                            TimeWatered = e.TimeWatered,
                            TimeFertilized = e.TimeFertilized,
                            NextWatering = CalculateNextWatering(e.WateringFrequency, e.TimeWatered),
                        });
                return query.ToArray();
            }
        }

        public PlantDetails GetPlantById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx
                         .Plants
                         .Single(e => e.PlantID == id && e.OwnerID == _userId);
                return
                    new PlantDetails
                    {
                        PlantID = entity.PlantID,
                        TypeOfPlant = entity.TypeOfPlant,
                        SoilMix = entity.SoilMix,
                        WateringFrequency = entity.WateringFrequency,
                        TimeWatered = entity.TimeWatered,
                        TimeFertilized = entity.TimeFertilized,
                        NextWatering = entity.NextWatering,
                    };
            }
        }

        public bool UpdatePlant(PlantEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Plants
                    .Single(e => e.OwnerID == _userId && e.PlantID == model.PlantID);
                entity.PlantID = model.PlantID;
                entity.TypeOfPlant = model.TypeOfPlant;
                entity.SoilMix = model.SoilMix;
                entity.WateringFrequency = model.WateringFrequency;
                entity.TimeWatered = model.TimeWatered;
                entity.TimeFertilized = model.TimeFertilized;
                entity.NextWatering = CalculateNextWatering(model.WateringFrequency, model.TimeWatered);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlant(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .Plants
                            .Single(e => e.PlantID == id && e.OwnerID == _userId);
                ctx.Plants.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        private DateTimeOffset CalculateNextWatering(WaterRate waterRate, DateTimeOffset timeLastWatered)
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
