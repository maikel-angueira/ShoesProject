using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class ColorServices : IColorServices
    {
        private readonly ShoesDBEntities shoesDataEntities;

        public ColorServices()
        {
            this.shoesDataEntities = new ShoesDBEntities();
        }

        public ColorServices(string connectionString)
        {
            this.shoesDataEntities = new ShoesDBEntities(connectionString);
        }

        public void InsertColor(string colorName)
        {
            Color newColor = new Color() { Name = colorName };
            shoesDataEntities.Colors.Add(newColor);
            SaveChanges();
        }

        public void UpdateColor(int colorId, string newColor)
        {
            var currentColor = FindColor(colorId);
            if (currentColor != null)
            {
                currentColor.Name = newColor;
                SaveChanges();
            }
        }

        public void DeleteColor(int colorId)
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
                    .Select(c => new ColorDto() { ColorId = c.Id, ColorName = c.Name })
                    .ToList();
        }

        public bool ExistColorByName(String colorName)
        {
            if (colorName == null)
                return false;

            return shoesDataEntities.Colors.Any(c => c.Name.Equals(colorName));
        }

        private Color FindColor(int colorId)
        {
            return shoesDataEntities.Colors.Where(c => c.Id.Equals(colorId)).SingleOrDefault();
        }

        private void SaveChanges()
        {
            shoesDataEntities.SaveChanges();
        }
    }
}
