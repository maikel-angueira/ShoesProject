using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class ModelServices
    {
        private readonly ShoesDBEntities shoesDataEntities;

        public ModelServices()
        {
            this.shoesDataEntities = new ShoesDBEntities();
        }

        public void InsertModel(string name, String description, byte[] photo)
        {
            var newModel = new Model { Name = name, Description = description, Photo = photo };
            shoesDataEntities.Models.Add(newModel);
            SaveChanges();
        }

        private void SaveChanges()
        {
            shoesDataEntities.SaveChanges();
        }

        public List<ModelDto> GetAllModels()
        {
            return shoesDataEntities.Models
                .Select(m => new ModelDto
                {
                    ModelId = m.Id,
                    Description = m.Description,
                    Name = m.Name,
                    Photo = m.Photo
                }).ToList();
        }

        public bool ExistModelByName(string newModelName)
        {
            return shoesDataEntities.Models.Any(m => m.Name == newModelName);
        }

        public void UpdateModel(ModelDto updatedModelDto)
        {
            Model model = FindModelById(updatedModelDto.ModelId);
            if (model != null)
            {
                model.Description = updatedModelDto.Description;
                model.Name = updatedModelDto.Name;
                model.Photo = updatedModelDto.Photo;
                SaveChanges();
            }
        }

        private Model FindModelById(int modelId)
        {
            return shoesDataEntities.Models.Where(m => m.Id == modelId).SingleOrDefault();
        }

        public void RemoveModel(int modelId)
        {
            var deletedModel = FindModelById(modelId);
            if (deletedModel != null)
            {
                shoesDataEntities.Models.Remove(deletedModel);
                SaveChanges();
            }
        }
    }
}
