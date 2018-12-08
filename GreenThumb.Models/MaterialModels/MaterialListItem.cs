using GreenThumb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Models.MaterialModels
{
    public class MaterialListItem
    {
        public int MaterialID { get; set; }
        public MaterialType TypeOfMaterial { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public QuantityType TypeOfQuantity { get; set; }
    }
}
