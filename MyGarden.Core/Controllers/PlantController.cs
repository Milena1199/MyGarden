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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                Id = Guid.NewGuid(),
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
            List<PlantImage> imagesforPlant = myGardenDb.PlantImages.Where(i => i.PlantId == plantId).ToList();
            if (imagesforPlant.Count == 0) images.Add("noImageFound");
            else
            {
                foreach (PlantImage image in imagesforPlant)
                {
                    if(image.IsVisible==true) images.Add(image.Url);
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
            List<PlantImage> images = myGardenDb.PlantImages.Where(i => i.PlantId == plantid).ToList();
            PlantImage image = images[index];
            image.IsVisible = false;
        }
        public void AddImage(AddImageForPlantViewModel addImageForPlantViewModel)
        {
            PlantImage image = new PlantImage()
            {
                Id = Guid.NewGuid(),
                Url = addImageForPlantViewModel.Url,
                IsVisible = true,
                PlantId = addImageForPlantViewModel.PlantId
            };
            myGardenDb.PlantImages.Add(image);
            myGardenDb.SaveChanges();
        }
        public List<string> AllCategoriesNames()
        {
            List<string> names = new List<string>();
            foreach (Category category in myGardenDb.Categories)
            {
                names.Add(category.Name);
            }
            return names;
        }
        public void AddCategory(AddCategoryViewModel addCategoryViewModel)
        {
            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = addCategoryViewModel.Name,
                Description = addCategoryViewModel.Description,
            };
            myGardenDb.Categories.Add(category);
            myGardenDb.SaveChanges();
        }
        public void DeleteCategory(int index)
        {
            List<Category> categories = myGardenDb.Categories.ToList();
            Category category = categories[index];
            DeleteCategory_Plant(category.Id);
            myGardenDb.Categories.Remove(category);
            myGardenDb.SaveChanges();
        }
        public void DeleteCategory_Plant(Guid categoryId)
        {
            foreach (Plant_Category plant_Category  in myGardenDb.Plants_Categories)
            {
                if(plant_Category.CategoryId== categoryId)
                {
                    myGardenDb.Plants_Categories.Remove(plant_Category);
                }
            }
            myGardenDb.SaveChanges();
        }
        public void UpdateCategory(UpdateCatrgoryViewModel updateCatrgoryViewModel)
        {
            List<Category> categories = myGardenDb.Categories.ToList();
            Category category = categories[updateCatrgoryViewModel.Index];
            category.Name = updateCatrgoryViewModel.Name;
            category.Description = updateCatrgoryViewModel.Description;
            myGardenDb.Update(category);
            myGardenDb.SaveChanges();
        }
        public string GetCategoryDescription(int index)
        {
            List<Category> categories = myGardenDb.Categories.ToList();
            Category category = categories[index];
            return category.Description;
        }
        public void AddStyle(AddStyleViewModel addStyleViewModel)
        {
            GardenStyle style = new GardenStyle()
            {
                Id = Guid.NewGuid(),
                Name = addStyleViewModel.Name,
                Description = addStyleViewModel.Description,
                Image = addStyleViewModel.ImagePath
            };
            myGardenDb.GardenStyles.Add(style);
            myGardenDb.SaveChanges();
        }
        public List<string> ShowStyleNames ()
        {
            List<string>names = new List<string>();
            foreach(GardenStyle style in myGardenDb.GardenStyles)
            {
                names.Add(style.Name);
            }
            return names;
        }
        public string GetStyleDescription(int index)
        {
            List<GardenStyle> styles = myGardenDb.GardenStyles.ToList();
            GardenStyle style = styles[index];
            return style.Description;
        }
        public string GetImagePathForStyle(int index)
        {
            List<GardenStyle> styles = myGardenDb.GardenStyles.ToList();
            GardenStyle style = styles[index];
            return style.Image;
        }
        public void DeleteStyle(int index)
        {
            List<GardenStyle> styles = myGardenDb.GardenStyles.ToList();
            GardenStyle style = styles[index];
            DeleteStyle_Plant(style.Id);
            myGardenDb.GardenStyles.Remove(style);
            myGardenDb.SaveChanges();
        }
        public void DeleteStyle_Plant(Guid styleId)
        {
            foreach (PlantAndStyle plantAndStyle in myGardenDb.PlantsAndStyles)
            {
                if (plantAndStyle.StyleId == styleId)
                {
                    myGardenDb.PlantsAndStyles.Remove(plantAndStyle);
                }
            }
            myGardenDb.SaveChanges();
        }
        public void UpdateStyle(UpdateStyleViewModel updatestyleViewModel)
        {
            List<GardenStyle> styles = myGardenDb.GardenStyles.ToList();
            GardenStyle gardenStyle = styles[updatestyleViewModel.Index];
            gardenStyle.Name = updatestyleViewModel.Name;
            gardenStyle.Description = updatestyleViewModel.Description;
            gardenStyle.Image = updatestyleViewModel.ImagePath;
            myGardenDb.Update(gardenStyle);
            myGardenDb.SaveChanges();
        }

        public void AddDisease(AddDiseaseViewModel addDiseaseViewModel)
        {
            Disease disease = new Disease()
            {
                Id = Guid.NewGuid(),
                Name = addDiseaseViewModel.Name,
                Description = addDiseaseViewModel.Description,
                Image = addDiseaseViewModel.Image,
                Cure = addDiseaseViewModel.Cure,
                CureImage = addDiseaseViewModel.CureImage
            };
            myGardenDb.Diseases.Add(disease);
            myGardenDb.SaveChanges();
        }

    }
}
