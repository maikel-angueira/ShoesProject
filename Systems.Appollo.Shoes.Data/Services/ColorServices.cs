using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class ColorServices
    {
        private readonly ShoesDBEntities shoesDataEntities;

        public ColorServices()
        {
            this.shoesDataEntities = new ShoesDBEntities();
        }

        public ColorServices(string connectionString)
        {
            
        }

        public void InsertColor(string colorName)
        {
            Color newColor = new Color() { Name = colorName };
            shoesDataEntities.Colors.Add(newColor);
            SaveChanges();
        }

        public ColorDto UpdateColor(int? colorId, string newColor)
        {
            var currentColor = FindColor(colorId);
            if (currentColor != null)
            {
                currentColor.Name = newColor;
                SaveChanges();
            }

            return new ColorDto { ColorId = colorId, Name = newColor };
        }

        public void DeleteColor(int? colorId)
        {
            Color deleted = FindColor(colorId);
            if (deleted != null)
            {
                shoesDataEntities.Colors.Remove(deleted);
                SaveChanges();
            }
        }

        public List<ColorDto> GetAllColors()
        {
            return shoesDataEntities.Colors
                    .Select(c => new ColorDto() { ColorId = c.Id, Name = c.Name })
                    .ToList();
        }

        public bool ExistColorByName(String colorName)
        {
            if (colorName == null)
                return false;

            return shoesDataEntities.Colors.Any(c => c.Name == colorName);
        }

        public Color FindColor(int? colorId)
        {
            return shoesDataEntities.Colors.Where(c => c.Id == colorId).SingleOrDefault();
        }

        private void SaveChanges()
        {
            shoesDataEntities.SaveChanges();
        }
    }
}
