using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
