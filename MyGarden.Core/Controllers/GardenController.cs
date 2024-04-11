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
    public class GardenController
    {
        private readonly MyGardenDb myGardenDb;
        public GardenController ()
        {
            myGardenDb = new MyGardenDb ();
        }
        public void NewZone (NewZoneViewModel newZoneViewModel)
        {
            GardeningZone gardeningZone = new GardeningZone()
            {
                Id = new Guid(),
                ClimateZone = newZoneViewModel.ClimateZone,
                HardinessZone = newZoneViewModel.HardinessZone,
                SoilType = newZoneViewModel.SoilType,
                UserId = newZoneViewModel.Id
            };
            myGardenDb.GardeningZones.Add(gardeningZone);
            myGardenDb.SaveChanges();
        }
        public List<GardeningZone> AllZones(Guid userId)
        {
            return myGardenDb.GardeningZones.Where(g=>g.UserId==userId).ToList();
        }
        public GardeningZone FindGarden (int index, Guid id)
        {
            List<GardeningZone> gardens = AllZones(id);
            GardeningZone gardeningZone = gardens[index];
            return gardeningZone;
        }
        public void DeleteGarden(Guid id)
        {
            GardeningZone garden = myGardenDb.GardeningZones.Find(id);
            if (garden!= null) myGardenDb.GardeningZones.Remove(garden);
            myGardenDb.SaveChanges();
        }
        public void UpdateZone(UpdateZoneViewModel updateZoneViewModel)
        {
            GardeningZone garden = myGardenDb.GardeningZones.Find(updateZoneViewModel.id);
            garden.ClimateZone = updateZoneViewModel.ClimateZone;
            garden.SoilType = updateZoneViewModel.SoilType;
            garden.HardinessZone = updateZoneViewModel.HardinessZone;
            myGardenDb.GardeningZones.Update(garden);
            myGardenDb.SaveChanges();
        }
    }
}
