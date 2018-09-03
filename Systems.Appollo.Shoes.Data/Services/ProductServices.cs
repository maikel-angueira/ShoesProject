using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class ProductServices
    {
        private readonly ShoesDBEntities shoesDataEntities;

        public ProductServices()
        {
            this.shoesDataEntities = new ShoesDBEntities();
        }

        public bool ExistProduct(int modelId, int colorId, double size)
        {
            return shoesDataEntities.Products.Any(p =>
                    p.ModelId == modelId
                        && p.ColorId == colorId
                        && p.Size == size);
        }

        public Product FindProduct(int modelId, int colorId, double size)
        {
            if (!ExistProduct(modelId, colorId, size)) return null;
            return shoesDataEntities.Products.Where(p =>
                    p.ModelId == modelId
                        && p.ColorId == colorId
                        && p.Size == size)
                   .SingleOrDefault();
        }

    }
}
