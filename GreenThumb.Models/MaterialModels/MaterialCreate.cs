using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenThumb.Data;

namespace GreenThumb.Models.MaterialModels
{
    public class MaterialCreate
    {
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public QuantityType TypeOfQuantity { get; set; }
        public MaterialType TypeOfMaterial { get; set; }
    }
}
