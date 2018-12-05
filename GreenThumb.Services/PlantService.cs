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

        }
    }
}
