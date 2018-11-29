using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public enum MaterialType { Bonzai, Soil, Fertilizer, Equipment}
    public enum QuantityType { Lbs, Oz, Units }

    public class Material
    {
        public int MaterialID { get; set; }
        public Guid OwnerID { get; set; }
        public MaterialType MyProperty { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public QuantityType TypeOfQuantity { get; set; }
    }
}
