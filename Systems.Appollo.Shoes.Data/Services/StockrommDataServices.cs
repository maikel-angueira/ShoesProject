using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class StockroomDataServices
    {
        private readonly ShoesDBEntities shoesDataEntities;
        private readonly ColorServices colorServices;

        public StockroomDataServices()
        {
            this.shoesDataEntities = new ShoesDBEntities();
            this.colorServices = new ColorServices();
        }

        public void InsertNewProduct(StockRoomDto stockroomDto)
        {
            Color shoesColor = null;
            if (stockroomDto.SelectedColor.ColorId == null)
            {
                shoesColor = new Color { Name = stockroomDto.SelectedColor.Name };
                shoesDataEntities.Colors.Add(shoesColor);
            }
            else
            {
                shoesColor = colorServices.FindColor(stockroomDto.SelectedColor.ColorId);                
            }

            var newProduct = new Product
            {
                ModelId = stockroomDto.ModelId,
                ColorId = shoesColor.Id,
                Description = stockroomDto.Description,
                Size = stockroomDto.Size,
                Quantity = stockroomDto.Quantity,
                UnitCost = stockroomDto.UnitCost,
                InputDate = stockroomDto.InputDate
            };

            shoesDataEntities.Products.Add(newProduct);
            shoesDataEntities.SaveChanges();
        }
    }
}
