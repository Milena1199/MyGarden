using MyGarden.Data.Data;
using System;
using System.Collections.Generic;
using MyGarden.Core.Models;
using MyGarden.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MyGarden.Core.Controllers
{
    public class PlantController
    {
        private readonly MyGardenDb myGardenDb;

        public PlantController ()
        {
            myGardenDb = new MyGardenDb ();
        }
        
        public List<Plant> FindAllPlants()
        {
            return myGardenDb.Plants.ToList ();
        }

        public void AddPlant(AddPlantViewModel addPlantViewModel)
        {
            Plant plant = new Plant()
            {
                Id = new Guid(),
                Name = addPlantViewModel.Name,
                HowToPlant = addPlantViewModel.HowToPlant,
                SeasonsOfInterest = addPlantViewModel.SeasonOfInteret,
                Characteristics = addPlantViewModel.Characteristics,
                ClimateZone = addPlantViewModel.ClimateZone,
                HardinessZone = addPlantViewModel.HardinessZone,
                SoilType = addPlantViewModel.SoilType,
                Maintenance = addPlantViewModel.Мaintenance,
                LenghtOfLife = addPlantViewModel.LenghtOfLife,
                MoreInfo = addPlantViewModel.MoreInfo,
                Price = addPlantViewModel.Price
            };
        }
        public List<string>ShowImagesForPlant(Guid plantId)
        {
            List<string> images = new List<string>();
            Plant plant = myGardenDb.Plants.Find(plantId);
            List<Image> imagesforPlant = myGardenDb.Images.Where(i => i.PlantId == plantId).ToList();
            if (imagesforPlant.Count == 0) images.Add("noImageFound");
            else
            {
                foreach (Image image in imagesforPlant)
                {
                    images.Add(image.Url);
                }
            }
            return images;
        }
        public Guid FindPlant(int index)
        {
            List<Plant> plats = FindAllPlants();
            Plant plant = plats[index];
            return plant.Id;
        }
        public void DeleteImage(Guid plantid, int index)
        {
            List<Image> images = myGardenDb.Images.Where(i => i.PlantId == plantid).ToList();
            Image image = images[index];
            myGardenDb.Images.Remove(image);
            myGardenDb.SaveChanges();
        }
        public void AddImage(AddImageForPlantViewModel addImageForPlantViewModel)
        {
            Image image = new Image()
            {
                Id = new Guid(),
                Url = addImageForPlantViewModel.Url,
                PlantId = addImageForPlantViewModel.PlantId
            };
            myGardenDb.Images.Add(image);
            myGardenDb.SaveChanges();
        }

    }
}
