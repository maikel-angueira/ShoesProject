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

        public void InsertModel(string name, String description, byte[] photos)
        {
            var newModel = new Model { Name = name, Description = description, Photo = photos };
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
    }
}
