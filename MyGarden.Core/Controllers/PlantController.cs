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
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace MyGarden.Core.Controllers
{
    public class PlantController
    {
        private readonly MyGardenDb myGardenDb;

        public PlantController ()
        {
            myGardenDb = new MyGardenDb ();
        }


        //Create
        public void AddPlant(AddPlantViewModel addPlantViewModel)//validation
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
            myGardenDb.Plants.Add(plant);
            myGardenDb.SaveChanges();
        }

        public void AddInPlantsAndCategories(AddInPlantsAndCategoriesViewModel addInPlantsAndCategoriesViewModel)
        {
            Plant_Category plantCategory = new Plant_Category()
            {
                PlantId = addInPlantsAndCategoriesViewModel.PlantId,
                CategoryId = addInPlantsAndCategoriesViewModel.CategoryId
            };

            myGardenDb.Plants_Categories.Add(plantCategory);
            myGardenDb.SaveChanges();
        }

        public void AddInPlantsAndDiseases(AddInPlantsAndDiseasesViewModel addInPlantsAndDiseasesViewModel)
        {
            PlantAndDisease plantAndDisease = new PlantAndDisease()
            {
                PlantId = addInPlantsAndDiseasesViewModel.PlantId,
                DiseaseId = addInPlantsAndDiseasesViewModel.DiseaseId
            };

            myGardenDb.PlantsAndDiseases.Add(plantAndDisease);
            myGardenDb.SaveChanges();
        }

        public void AddInPestsAndPlants(AddInPestsAndPlantsViewModel addInPestsAndPlantsViewModel)
        {
            PestAndPlant pestAndPlant = new PestAndPlant()
            {
                PestId = addInPestsAndPlantsViewModel.PestId,
                PlantId = addInPestsAndPlantsViewModel.PlantId
            };

            myGardenDb.PestsAndPlants.Add(pestAndPlant);
            myGardenDb.SaveChanges();
        }

        public void AddInPlantsAndStyles(AddInPlantsAndStylesViewModel addInPlantsAndStylesViewModel)
        {
            PlantAndStyle plantAndStyle = new PlantAndStyle()
            {
                PlantId = addInPlantsAndStylesViewModel.PlantId,
                StyleId = addInPlantsAndStylesViewModel.StyleId
            };
            myGardenDb.PlantsAndStyles.Add(plantAndStyle);
            myGardenDb.SaveChanges();
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
        public void AddPest(AddPestViewModel addPestViewModel)
        {
            Pest pest = new Pest()
            {
                Id = Guid.NewGuid(),
                Name = addPestViewModel.Name,
                Description = addPestViewModel.Description,
                Image = addPestViewModel.Image,
                Cure = addPestViewModel.Cure,
                CureImage = addPestViewModel.CureImage
            };
            myGardenDb.Pests.Add(pest);
            myGardenDb.SaveChanges();
        }

        //Read
        public List<string> ShowAllPlantsNames()
        {
            List<string> plants = new List<string>();
            foreach (Plant plant in myGardenDb.Plants)
            {
                plants.Add (plant.Name);
            }
            return plants;
        }

        public Plant FindPlant(int index)
        {
            List<Plant> plants = myGardenDb.Plants.ToList();
            return plants[index];
        }

        public List<string>CategoriesForPlantNames(int index)
        {
            List<string> categrories = new List<string>();
            foreach (Plant_Category plant_category in myGardenDb.Plants_Categories)
            {
               Category category = myGardenDb.Categories.Find(plant_category.CategoryId);
                categrories.Add(category.Name);
            }
            return categrories;
        }

        public List<string> StylesForPlantNames (int index)
        {
            List<string> styles = new List<string>();
            foreach(PlantAndStyle plantAndStyle in myGardenDb.PlantsAndStyles)
            {
                GardenStyle style = myGardenDb.GardenStyles.Find(plantAndStyle.StyleId);
                styles.Add(style.Name);
            }
            return styles;
        }

        public List<string> PestsForPlantNames(int index)
        {
            List<string> pests = new List<string>();
            foreach (PestAndPlant pestAndPlant in myGardenDb.PestsAndPlants)
            {
                Pest pest = myGardenDb.Pests.Find(pestAndPlant.PestId);
                pests.Add(pest.Name);
            }
            return pests;
        }

        public List<string> DiseasesForPlantNames(int index)
        {
            List<string> diseases = new List<string>();
            foreach (PlantAndDisease plant_disease in myGardenDb.PlantsAndDiseases)
            {
               Disease disease= myGardenDb.Diseases.Find(plant_disease.DiseaseId);
                diseases.Add(disease.Name);
            }
            return diseases;
        }

        public Guid FindPlantId(string name)
        {
            Plant plant = myGardenDb.Plants.FirstOrDefault(p => p.Name == name);
            return plant.Id;
        }

        public Guid FindCategoryId(string categoryName)
        {
           Category category = myGardenDb.Categories.FirstOrDefault(c=>c.Name==categoryName);
            return category.Id;
        }

        public Guid FindPestId(string pestName)
        {
            Pest pest = myGardenDb.Pests.FirstOrDefault(p => p.Name == pestName);
            return pest.Id;
        }

        public Guid FindDiseaseId(string diseaseName)
        {
            Disease disease = myGardenDb.Diseases.FirstOrDefault(d=>d.Name == diseaseName);
            return disease.Id;
        }

        public Guid FindStyleId(string styleName)
        {
            GardenStyle style = myGardenDb.GardenStyles.FirstOrDefault(s => s.Name == styleName);
            return style.Id;
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
        public List<string> AllCategoriesNames()
        {
            List<string> names = new List<string>();
            foreach (Category category in myGardenDb.Categories)
            {
                names.Add(category.Name);
            }
            return names;
        }

        public string GetCategoryDescription(int index)
        {
            List<Category> categories = myGardenDb.Categories.ToList();
            Category category = categories[index];
            return category.Description;
        }

        public List<string> ShowStyleNames()
        {
            List<string> names = new List<string>();
            foreach (GardenStyle style in myGardenDb.GardenStyles)
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
        public List<string> AllDiseasesNames()
        {
            List<string> diseases = new List<string>();
            foreach (Disease disease in myGardenDb.Diseases)
            {
                diseases.Add(disease.Name);
            }
            return diseases;
        }
        public Disease GetDisease(int index)
        {
            List<Disease> diseases = myGardenDb.Diseases.ToList();
            Disease disease = diseases[index];
            return disease;
        }
        public List<string> AllPestsNames()
        {
            List<string> pests = new List<string>();
            foreach (Pest pest in myGardenDb.Pests)
            {
                pests.Add(pest.Name);
            }
            return pests;
        }

        public Pest GetPest(int index)
        {
            List<Pest> pests = myGardenDb.Pests.ToList();
            Pest pest = pests[index];
            return pest;
        }


        //Update

        public void UpdatePlant(UpdatePlantViewModel updatePlantViewModel)
        {
            Plant plant = myGardenDb.Plants.Find(updatePlantViewModel.PlantId);
            plant.Name = updatePlantViewModel.Name;
            plant.HowToPlant = updatePlantViewModel.HowToPlant;
            plant.SeasonsOfInterest = updatePlantViewModel.SeasonOfInteret;
            plant.Characteristics = updatePlantViewModel.Characteristics;
            plant.ClimateZone = updatePlantViewModel.ClimateZone;
            plant.HardinessZone = updatePlantViewModel.HardinessZone;
            plant.SoilType = updatePlantViewModel.SoilType;
            plant.Maintenance = updatePlantViewModel.Мaintenance;
            plant.LenghtOfLife = updatePlantViewModel.LenghtOfLife;
            plant.Price = updatePlantViewModel.Price;
            plant.MoreInfo = updatePlantViewModel.MoreInfo;

            List<PlantImage> images = myGardenDb.PlantImages.Where(i => i.PlantId == updatePlantViewModel.PlantId).ToList();
            List<string> newImages = updatePlantViewModel.Images.ToList();
            if (images.Count > newImages.Count)
            {
                foreach(PlantImage image in images)
                {
                    bool isThere = false;
                    foreach (string name in newImages)
                    {
                        if (image.Url == name) isThere = true;
                    }
                    if(isThere==false)
                    {
                        image.IsVisible = false;
                    }
                }
            }
            else if (images.Count < newImages.Count)
            {
                foreach (string name in newImages)
                {
                    bool isThere = false;
                    foreach (PlantImage image in images)
                    {
                        if (image.Url == name) isThere = true;
                    }
                    if(isThere ==false)
                    {
                        AddImageForPlantViewModel addImageForPlantViewModel = new AddImageForPlantViewModel()
                        {
                            PlantId = updatePlantViewModel.PlantId,
                            Url = name
                        };
                        AddImage(addImageForPlantViewModel);
                    }
                }

            }
            List<string> categories = CategoriesForPlantNames(updatePlantViewModel.Index);
            List<string> newCategories = updatePlantViewModel.Categories;
            
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
        public void UpdateDisease(UpdateDiseaseViewModel updateDiseaseViewModel)
        {
            List<Disease> diseases = myGardenDb.Diseases.ToList();
            Disease disease = diseases[updateDiseaseViewModel.Index];
            disease.Name = updateDiseaseViewModel.Name;
            disease.Description = updateDiseaseViewModel.Description;
            disease.Image = updateDiseaseViewModel.Image;
            disease.Cure = updateDiseaseViewModel.Cure;
            disease.CureImage = updateDiseaseViewModel.CureImage;
            myGardenDb.Diseases.Update(disease);
            myGardenDb.SaveChanges();
        }
        public void UpdatePest(UpdatePestViewModel updatePestViewModel)
        {
            List<Pest> pests = myGardenDb.Pests.ToList();
            Pest pest = pests[updatePestViewModel.Index];
            pest.Name = updatePestViewModel.Name;
            pest.Description = updatePestViewModel.Description;
            pest.Image = updatePestViewModel.Image;
            pest.Cure = updatePestViewModel.Cure;
            pest.CureImage = updatePestViewModel.CureImage;
            myGardenDb.Pests.Update(pest);
            myGardenDb.SaveChanges();
        }

        //Delete

        public void DeleteImage(Guid plantid, int index)
        {
            List<PlantImage> images = myGardenDb.PlantImages.Where(i => i.PlantId == plantid).ToList();
            PlantImage image = images[index];
            image.IsVisible = false;
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

        public void DeleteDisease (int index)
        {
            List<Disease> diseases = myGardenDb.Diseases.ToList();
            Disease disease = diseases[index];
            DeleteDisease_Plant(disease.Id);
            myGardenDb.Diseases.Remove(disease);
            myGardenDb.SaveChanges();
        }

        public void DeleteDisease_Plant (Guid diseaseId)
        {
            foreach(PlantAndDisease plantAndDisease in myGardenDb.PlantsAndDiseases)
            {
                if (plantAndDisease.DiseaseId == diseaseId)
                {
                    myGardenDb.PlantsAndDiseases.Remove(plantAndDisease);
                }
            }
        }

        public void DeletePest(int index)
        {
            List<Pest> pests = myGardenDb.Pests.ToList();
            Pest pest = pests[index];
            DeletePest_Plant(pest.Id);
            myGardenDb.Pests.Remove(pest);
            myGardenDb.SaveChanges();
        }

        public void DeletePest_Plant(Guid pestId)
        {
            foreach (PestAndPlant pestAndPlant in myGardenDb.PestsAndPlants)
            {
                if (pestAndPlant.PestId == pestId)
                {
                    myGardenDb.PestsAndPlants.Remove(pestAndPlant);
                }
            }
        }

        public void DeletePlant (Guid plantId)
        {
            Plant plant = myGardenDb.Plants.Find(plantId);
            DeletePlant_Images(plant.Id);
            DeletePlant_Category(plant.Id);
            DeletePlant_Disease(plant.Id);
            DeletePlant_Pest(plant.Id);
            DeletePlant_Zone(plant.Id);
            myGardenDb.Plants.Remove(plant);
            myGardenDb.SaveChanges();
        }
        
        public void DeletePlant_Images (Guid plantId)
        {
            foreach (PlantImage plantImage in myGardenDb.PlantImages)
            {
                if(plantImage.PlantId == plantId)
                {
                    myGardenDb.PlantImages.Remove(plantImage);
                }
            }
            myGardenDb.SaveChanges();
        }
        public void DeletePlant_Category(Guid plantId)
        {
            foreach(Plant_Category plant_Category in myGardenDb.Plants_Categories)
            {
                if (plant_Category.PlantId == plantId)
                {
                    myGardenDb.Plants_Categories.Remove(plant_Category);
                }
            }
            myGardenDb.SaveChanges();
        }

        public void DeletePlant_Disease (Guid plantId)
        {
            foreach (PlantAndDisease plantAndDisease in myGardenDb.PlantsAndDiseases)
            {
                if (plantAndDisease.PlantId ==plantId)
                {
                    myGardenDb.PlantsAndDiseases.Remove(plantAndDisease);
                }
            }
            myGardenDb.SaveChanges();
        }

        public void DeletePlant_Pest(Guid plantId)
        {
            foreach (PestAndPlant pestAndPlant in myGardenDb.PestsAndPlants)
            {
                if(pestAndPlant.PlantId == plantId)
                {
                    myGardenDb.PestsAndPlants.Remove(pestAndPlant);
                }
            }
            myGardenDb.SaveChanges();
        }

        public void DeletePlant_Zone (Guid plantId)
        {
            foreach (Plant_Garden plant_Garden in myGardenDb.Plants_Gardens)
            {
                if(plant_Garden.PlantId==plantId)
                {
                    myGardenDb.Plants_Gardens.Remove(plant_Garden);
                }
            }
            myGardenDb.SaveChanges();
        }
    }
}
