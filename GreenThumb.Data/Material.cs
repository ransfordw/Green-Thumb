﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumb.Data
{
    public enum MaterialType { Bonzai, Soil, Fertilizer, Equipment}
    public enum QuantityType { Lbs, Oz, Units }

    public class Material
    {
        [Key]
        public int MaterialID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        public MaterialType TypeOfMaterial { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public QuantityType TypeOfQuantity { get; set; }
    }
}
