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

        public ProductServices(ShoesDBEntities shoesDataEntities1)
        {
            this.shoesDataEntities = shoesDataEntities1;
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
            return shoesDataEntities.Products.Where(p =>
                    p.ModelId == modelId
                        && p.ColorId == colorId
                        && p.Size == size)
                   .SingleOrDefault();
        }

    }
}
