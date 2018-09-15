using System.Collections.Generic;
using System.Linq;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Services.Data
{
    public class ColorServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;
        
        public ColorServices(ShoesDBEntities shoesDataEntities1)
        {
            this._shoesDataEntities = shoesDataEntities1;
        }

        public ColorDto InsertColor(string colorName)
        {
            var newColor = new Color() { Name = colorName };
            _shoesDataEntities.Colors.Add(newColor);
            SaveChanges();
            return new ColorDto
            {
                ColorId = newColor.Id,
                Name = newColor.Name
            };
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
            var deleted = FindColor(colorId);
            if (deleted == null) return;
            _shoesDataEntities.Colors.Remove(deleted);
            SaveChanges();
        }

        public List<ColorDto> GetAllColors()
        {
            return _shoesDataEntities.Colors
                    .Select(c => new ColorDto() { ColorId = c.Id, Name = c.Name })
                    .ToList();
        }

        public bool ExistColorByName(string colorName)
        {
            return colorName != null && _shoesDataEntities.Colors.Any(c => c.Name == colorName);
        }

        public Color FindColor(int? colorId)
        {
            return _shoesDataEntities.Colors.SingleOrDefault(c => c.Id == colorId);
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }
    }
}
