using System;
using System.Collections.Generic;
using System.Linq;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Services
{
    public class ModelServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;
        

        public ModelServices(ShoesDBEntities shoesDataEntities1)
        {
            this._shoesDataEntities = shoesDataEntities1;
        }

        public void InsertModel(string name, string description, byte[] photo)
        {
            var newModel = new Model { Name = name, Description = description, Photo = photo };
            _shoesDataEntities.Models.Add(newModel);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }

        public List<ModelDto> GetAllModels()
        {
            return _shoesDataEntities.Models
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
            return _shoesDataEntities.Models.Any(m => m.Name == newModelName);
        }

        public void UpdateModel(ModelDto updatedModelDto)
        {
            var model = FindModelById(updatedModelDto.ModelId);
            if (model == null) return;
            model.Description = updatedModelDto.Description;
            model.Name = updatedModelDto.Name;
            model.Photo = updatedModelDto.Photo;
            SaveChanges();
        }

        private Model FindModelById(int modelId)
        {
            return _shoesDataEntities.Models.SingleOrDefault(m => m.Id == modelId);
        }

        public void RemoveModel(int modelId)
        {
            var deletedModel = FindModelById(modelId);
            if (deletedModel == null) return;
            _shoesDataEntities.Models.Remove(deletedModel);
            SaveChanges();
        }

        public void InsertModel(ModelDto newModelDto)
        {
            var newModel = new Model
            {
                Name = newModelDto.Name,
                Description = newModelDto.Description,
                Photo = newModelDto.Photo,
                Cost = newModelDto.Cost,
                TypeId = newModelDto.ShoesTypeId                
            };

            newModelDto.AvailablesColors.ForEach(dto =>
            {
                var newModelColor = new AvailableColorModel
                {
                    ColorId = dto.ColorId.Value,
                    ModelId = newModel.Id
                };
                _shoesDataEntities.AvailableColorModels.Add(newModelColor);
            });
            _shoesDataEntities.Models.Add(newModel);
            SaveChanges();
        }

        public void UpdateShoesModelPicture(int modelId, byte[] uploadPicture)
        {
            var currentShoesModel = FindModelById(modelId);
            if (currentShoesModel == null) return;
            currentShoesModel.Photo = uploadPicture;
            SaveChanges();
        }
    }
}
