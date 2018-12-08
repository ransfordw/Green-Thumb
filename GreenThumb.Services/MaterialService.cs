using GreenThumb.Data;
using GreenThumb.Models.MaterialModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenThumb.Services
{
    public class MaterialService
    {
        private readonly Guid _userId;
        public MaterialService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMaterial(MaterialCreate model)
        {
            var entity = new Material()
            {
                OwnerID = _userId,
                Quantity = model.Quantity,
                Description = model.Description,
                TypeOfQuantity = model.TypeOfQuantity,
                TypeOfMaterial = model.TypeOfMaterial,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Materials.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MaterialListItem> GetMaterials()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                      ctx
                        .Materials
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                          e =>
                          new MaterialListItem
                          {
                              MaterialID = e.MaterialID,
                              Description = e.Description,
                              Quantity = e.Quantity,
                              TypeOfMaterial = e.TypeOfMaterial,
                              TypeOfQuantity = e.TypeOfQuantity,
                          });
                return query.ToArray();
            }
        }

        public MaterialDetails GetPlantById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Materials
                        .Single(e => e.MaterialID == id && e.OwnerID == _userId);
                return
                    new MaterialDetails
                    {
                        MaterialID = entity.MaterialID,
                        MaterialType = entity.TypeOfMaterial,
                        Description = entity.Description,
                        Quantity = entity.Quantity,
                        TypeOfQuantity = entity.TypeOfQuantity,
                    };
            }
        }

        public bool UpdateMaterial(MaterialEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Materials
                        .Single(e => e.OwnerID == _userId &&
                e.MaterialID == model.MaterialID);
                entity.MaterialID = model.MaterialID;
                entity.Quantity = model.Quantity;
                entity.TypeOfMaterial = model.TypeOfMaterial;
                entity.TypeOfQuantity = model.TypeOfQuantity;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlant(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                       ctx
                            .Materials
                            .Single(e => e.MaterialID == id && e.OwnerID == _userId);
                ctx.Materials.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
