using System.Linq;
using Systems.Appollo.Shoes.Data;

namespace Systems.Appollo.Shoes.Services
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

        public Product FindProduct(int modelId, int? colorId, double? size)
        {
            return _shoesDataEntities.Products
                   .SingleOrDefault(p => p.ModelId == modelId
                        && p.ColorId == colorId
                        && p.Size == size);
        }
    }
}
