using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class ProductServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;

        public ProductServices(ShoesDBEntities shoesDataEntities1)
        {
            this._shoesDataEntities = shoesDataEntities1;
        }

        public bool ExistProduct(int modelId, int colorId, double size)
        {
            return _shoesDataEntities.Products.Any(p =>
                    p.ModelId == modelId
                        && p.ColorId == colorId
                        && p.Size == size);
        }

        public Product FindProduct(int modelId, int colorId, double size)
        {
            return _shoesDataEntities.Products
                   .SingleOrDefault(p => p.ModelId == modelId
                        && p.ColorId == colorId
                        && p.Size == size);
        }
    }
}
