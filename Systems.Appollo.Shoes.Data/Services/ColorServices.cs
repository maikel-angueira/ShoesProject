using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Data.Services
{
    class ColorServices : IColorServices
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
            SubmitChanges();
        }

        public void UpdateColor(int colorId, string newColor)
        {
            var currentColor = FindColor(colorId);
            if (currentColor != null)
            {
                currentColor.Name = newColor;
                SubmitChanges();
            }
        }

        public void DeleteColor(int colorId)
        {
            Color deleted = FindColor(colorId);
            if (deleted != null)
            {
                shoesDataEntities.Colors.Remove(deleted);
                SubmitChanges();
            }
        }

        private Color FindColor(int colorId)
        {
            return shoesDataEntities.Colors.Where(c => c.Id.Equals(colorId)).SingleOrDefault();
        }

        private void SubmitChanges()
        {
            shoesDataEntities.SaveChanges();
        }
    }
}
