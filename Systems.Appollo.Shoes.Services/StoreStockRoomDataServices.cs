using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Services
{
    public class StoreStockRoomDataServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;        
        private readonly ProductServices _productServices;
        private readonly StockRoomDataServices _stockRoomDataServices;

        public StoreStockRoomDataServices(ShoesDBEntities shoesDataEntities, StockRoomDataServices stockRoomServices,
            ProductServices productServices)
        {
            this._shoesDataEntities = shoesDataEntities;
            this._stockRoomDataServices = stockRoomServices;
            this._productServices = productServices;
        }

        public List<ModelDto> GetAllAvailableModelsByStoreId(int storeId)
        {
            var availableModelKeys = _shoesDataEntities.StoreStockRooms
                .Where(st => st.StoreId == storeId)
                .GroupBy(st => st.ProductId)
                .Select(p => p.OrderByDescending(t => t.Id).FirstOrDefault())
                .Where(st => st.StockValue > 0)
                .Select(st => st.Product.Model.Id)
                .Distinct()
                .ToList();

            return availableModelKeys.Join(_shoesDataEntities.Models, modelId => modelId, model => model.Id,
                (modelId, model) => new ModelDto
                {
                    ModelId = modelId,
                    Name = model.Name,
                    Photo = model.Photo,
                    Description = model.Description
                }).ToList();
        }

        public List<ColorDto> GetAllStockShoesColorByModelId(int storeId, int modelId)
        {
            var availableColorKeys = _shoesDataEntities.StoreStockRooms
                .Where(st => st.StoreId == storeId)
                .Where(st => st.Product.ModelId == modelId)
                .GroupBy(st => st.ProductId)
                .Select(p => p.OrderByDescending(t => t.Id).FirstOrDefault())
                .Where(st => st.StockValue > 0)
                .Select(st => st.Product.ColorId)
                .Distinct()
                .ToList();

            return availableColorKeys.Join(_shoesDataEntities.Colors, colorId => colorId, color => color.Id,
                (colorId, color) => new ColorDto()
                {
                    ColorId = colorId,
                    Name = color.Name
                }).ToList();
        }

        public List<double> GetAllShoesSizesByColorAndModel(int storeId, int modeId, int? colorId)
        {
            return _shoesDataEntities.StoreStockRooms
                .Where(st => st.StoreId == storeId)
                .Where(st => st.Product.ModelId == modeId && st.Product.ColorId == colorId)
                .GroupBy(st => st.ProductId)
                .Select(p => p.OrderByDescending(t => t.Id).FirstOrDefault())
                .Where(st => st.StockValue > 0)
                .Select(st => st.Product.Size)
                .Distinct()
                .ToList();
        }
        
        public int GetTotalShoesInStockRoomByProduct(int storeId, int modelId, int? colorId, double? size)
        {
            var currentProduct = _productServices.FindProduct(modelId, colorId, size);
            if (currentProduct == null) return 0;
            var lastStockEntry = GetLastStoreStockRoomByProductId(storeId, currentProduct.Id);
            return lastStockEntry?.StockValue ?? 0;
        }

        public StoreStockRoom GetLastStoreStockRoomByProductId(int storeId, int productId)
        {
            return _shoesDataEntities.StoreStockRooms
                .Where(s => s.StoreId == storeId)
                .Where(s => s.ProductId == productId)
                .OrderByDescending(s => s.Id)
                .FirstOrDefault();
        }

        public StoreStockRoom GetLastStoreStockRoomByProductId(int storeId, int modelId, int colorId, double size)
        {
            var currentProduct = _productServices.FindProduct(modelId, colorId, size);
            return currentProduct == null ? null : GetLastStoreStockRoomByProductId(storeId, currentProduct.Id);
        }

        public void SupplyStoreStockRoom(StoreStockRoomDto storeStockRoomDto)
        {
            if (storeStockRoomDto.ColorId == null)
                throw new InvalidOperationException("Error: No enter new Store StockRoom if Color is null");
            if (storeStockRoomDto.Size == null)
                throw new InvalidOperationException("Error: No enter new Store StockRoom if Shoes Size is null");

            var modelId = storeStockRoomDto.ModelId;
            var colorId = storeStockRoomDto.ColorId.Value;
            var size = storeStockRoomDto.Size.Value;
            var currentProduct = _productServices.FindProduct(modelId, colorId, size);
            if (currentProduct == null)
                throw new StockRoomOperationException("No Found a product item to supply Store StockRoom");

            var lastStockRoom = _stockRoomDataServices.GetLastStockRoomByProductId(currentProduct.Id);
            if (lastStockRoom == null)
                throw new StockRoomOperationException("No Found any stock room to execute the operation");
            if (lastStockRoom.StockValue < storeStockRoomDto.Quantity)
                throw new StockRoomOperationException(
                    "It is not possible to move requested quantity to selected store");

            var newStockRoom = new StockRoom()
            {
                ProductId = lastStockRoom.ProductId,
                StockValue = lastStockRoom.StockValue - storeStockRoomDto.Quantity,
                EntryDate = storeStockRoomDto.DateOfSupplier,
                EntryValue = -storeStockRoomDto.Quantity,
                StoreId = storeStockRoomDto.StoreId,
                OperationType = OperationType.OUT.ToString()
            };
            _shoesDataEntities.StockRooms.Add(newStockRoom);
            var lastStoreStockRoom = GetLastStoreStockRoomByProductId(storeStockRoomDto.StoreId, currentProduct.Id);
            var storeStocks = storeStockRoomDto.Quantity;
            if (lastStoreStockRoom != null)
                storeStocks += lastStoreStockRoom.StockValue;
            var newStoreStockRoom = new StoreStockRoom
            {
                ProductId = currentProduct.Id,
                StockValue = storeStocks,
                EntryDate = storeStockRoomDto.DateOfSupplier,
                EntryValue = storeStockRoomDto.Quantity,
                StoreId = storeStockRoomDto.StoreId,
                OperationType = OperationType.IN.ToString()
            };
            _shoesDataEntities.StoreStockRooms.Add(newStoreStockRoom);
            SaveChanges();
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }
    }
}
