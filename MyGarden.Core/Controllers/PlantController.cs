using MyGarden.Data.Data;
using System;
using System.Collections.Generic;
using MyGarden.Core.Models;
using MyGarden.Data.Data;
using MyGarden.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MyGarden.Core.Controllers
{
    public class PlantController
    {
        private readonly MyGardenDb myGardenDb;

        public PlantController ()
        {
            myGardenDb = new MyGardenDb ();
        }
        public List<Category> AllPlantTypes ()
        {
            return myGardenDb.PlantTypes.ToList ();
        }
    }
}
