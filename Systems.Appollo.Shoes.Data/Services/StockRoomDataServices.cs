using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Data.Services
{
    public class StockRoomDataServices
    {
        private readonly ShoesDBEntities shoesDataEntities;
        private readonly ColorServices colorServices;

        public StockRoomDataServices()
        {
            this.shoesDataEntities = new ShoesDBEntities();
            this.colorServices = new ColorServices();
        }

        public void InsertNewProduct(StockRoomDto stockRoomDto)
        {
            Color shoesColor = null;
            if (stockRoomDto.SelectedColor.ColorId == null)
            {
                shoesColor = new Color { Name = stockRoomDto.SelectedColor.Name };
                shoesDataEntities.Colors.Add(shoesColor);
            }
            else
            {
                shoesColor = colorServices.FindColor(stockRoomDto.SelectedColor.ColorId);                
            }

            var newProduct = new Product
            {
                ModelId = stockRoomDto.ModelId,
                ColorId = shoesColor.Id,
                Description = stockRoomDto.Description,
                Size = stockRoomDto.Size,
                Quantity = stockRoomDto.Quantity,
                UnitCost = stockRoomDto.UnitCost,
                InputDate = stockRoomDto.InputDate
            };

            shoesDataEntities.Products.Add(newProduct);
            shoesDataEntities.SaveChanges();
        }
    }
}
