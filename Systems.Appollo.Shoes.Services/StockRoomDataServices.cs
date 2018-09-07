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
        private readonly ProductServices productServices;

        public StockRoomDataServices(ShoesDBEntities shoesDataEntities, ColorServices colorServices, ProductServices productServices)
        {
            this.shoesDataEntities = shoesDataEntities;
            this.colorServices = colorServices;
            this.productServices = productServices;
        }

        public void InsertNewProductInStock(StockRoomDto stockRoomDto)
        {
            Color shoesColor;
            if (stockRoomDto.SelectedColor.ColorId == null)
            {
                shoesColor = new Color { Name = stockRoomDto.SelectedColor.Name };
                shoesDataEntities.Colors.Add(shoesColor);
            }
            else
            {
                shoesColor = colorServices.FindColor(stockRoomDto.SelectedColor.ColorId);
            }

            StockRoom newStockRoom;
            if (!stockRoomDto.SelectedColor.ColorId.HasValue
                || !productServices.ExistProduct(
                        stockRoomDto.ModelId,
                        stockRoomDto.SelectedColor.ColorId.Value,
                        stockRoomDto.Size))
            {
                newStockRoom = AddNewStockRoomAndProduct(stockRoomDto, shoesColor.Id);
            }
            else
            {
                newStockRoom = AddNewStockRoomUpdatingTotal(stockRoomDto);
            }
            AddNewChargeToAccount(newStockRoom.Id, stockRoomDto.Quantity, stockRoomDto.UnitCost);
            SaveChanges();
        }

        private void SaveChanges()
        {
            shoesDataEntities.SaveChanges();
        }

        private StockRoom AddNewStockRoomUpdatingTotal(StockRoomDto newStockRoomDto)
        {
            Product currentProduct = productServices.FindProduct(
                newStockRoomDto.ModelId,
                newStockRoomDto.SelectedColor.ColorId.Value,
                newStockRoomDto.Size);
            var lastStockRoom = GetLastStockRoomByProductId(currentProduct.Id);
            int stocks = newStockRoomDto.Quantity;
            if (lastStockRoom != null)
                stocks += lastStockRoom.StockValue;

            var newStockRoom = new StockRoom
            {
                ProductId = currentProduct.Id,
                StockValue = stocks,
                EntryValue = newStockRoomDto.Quantity,
                EntryDate = newStockRoomDto.EntryDate,
                OperationType = OperationType.IN.ToString(),
                SupplierId = newStockRoomDto.SupplierId
            };
            shoesDataEntities.StockRooms.Add(newStockRoom);
            return newStockRoom;
        }

        private void AddNewChargeToAccount(int stockRoomId, int quantity, double unitCost)
        {
            var newCheckingAccount = new CheckingAccount
            {
                Charge = quantity * unitCost,
                StockRoomId = stockRoomId
            };
            shoesDataEntities.CheckingAccounts.Add(newCheckingAccount);
        }

        private StockRoom AddNewStockRoomAndProduct(StockRoomDto newStockRoomDto, int colorId)
        {
            Product currentProduct = new Product
            {
                ModelId = newStockRoomDto.ModelId,
                ColorId = colorId,
                Size = newStockRoomDto.Size,
            };
            shoesDataEntities.Products.Add(currentProduct);
            var newStockRoom = new StockRoom
            {
                ProductId = currentProduct.Id,
                StockValue = newStockRoomDto.Quantity,
                EntryValue = newStockRoomDto.Quantity,
                EntryDate = newStockRoomDto.EntryDate,
                OperationType = OperationType.IN.ToString(),
                SupplierId = newStockRoomDto.SupplierId
            };
            shoesDataEntities.StockRooms.Add(newStockRoom);
            return newStockRoom;
        }

        private StockRoom GetLastStockRoomByProductId(int productId)
        {
            return shoesDataEntities.StockRooms
                    .Where(s => s.ProductId == productId)
                    .OrderByDescending(s => s.Id)
                    .FirstOrDefault();
        }
    }
}
