using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Data.Services
{
    class ColorServices : IColorServices
    {
        private readonly ShoesDataContext shoesDataContext;

        public ColorServices()
        {
            this.shoesDataContext = new ShoesDataContext();
        }

        public ColorServices(string connection)
        {
            this.shoesDataContext = new ShoesDataContext(connection);
        }

        public void InsertColor(string colorName)
        {
            Color newColor = new Color() { Name = colorName };
            shoesDataContext.Colors.InsertOnSubmit(newColor);
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
                shoesDataContext.Colors.DeleteOnSubmit(deleted);
                SubmitChanges();
            }
        }

        private Color FindColor(int colorId)
        {
            return shoesDataContext.Colors.Where(c => c.Id.Equals(colorId)).SingleOrDefault();
        }

        private void SubmitChanges()
        {
            shoesDataContext.SubmitChanges();
        }
    }
}
