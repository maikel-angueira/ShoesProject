﻿using System.Collections.Generic;
using System.Linq;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Services.Data
{
    public class ModelServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;


        public ModelServices(ShoesDBEntities shoesDB)
        {
            this._shoesDataEntities = shoesDB;
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }

        public List<ModelDto> GetAllModels()
        {
            var modelDtos = _shoesDataEntities.Models
                .Select(m => new ModelDto
                {
                    ModelId = m.Id,
                    Description = m.Description,
                    Name = m.Name,
                    Photo = m.Photo,
                    Cost = m.Cost,
                    ShoesTypeId = m.ShoesType.Id,
                    Sex = m.Sex,
                    IsForKids = m.IsForKids
                }).ToList();


            foreach (var dto in modelDtos)
            {
                var colorByModels =_shoesDataEntities.ModelColors
                    .Where(c => c.ModelId == dto.ModelId)
                    .Select(c =>
                                new ColorDto
                                {
                                    ColorId = c.ColorId,
                                    Name = c.Color.Name
                                }).ToList();
                dto.AvailablesColors = colorByModels;
            }
            return modelDtos;
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
            model.TypeId = updatedModelDto.ShoesTypeId;
            model.Cost = updatedModelDto.Cost;
            model.Sex = updatedModelDto.Sex;
            model.IsForKids = updatedModelDto.IsForKids;
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
                TypeId = newModelDto.ShoesTypeId,
                Sex = newModelDto.Sex,
                IsForKids = newModelDto.IsForKids
            };

            _shoesDataEntities.Models.Add(newModel);
            newModelDto.AvailablesColors.ForEach(dto =>
            {
                var newModelColor = new ModelColor
                {
                    ColorId = dto.ColorId.Value,
                    ModelId = newModel.Id
                };
                _shoesDataEntities.ModelColors.Add(newModelColor);
            });
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
