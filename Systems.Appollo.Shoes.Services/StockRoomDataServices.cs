using System;
using System.Collections.Generic;
using System.Linq;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Services
{
    public class StockRoomDataServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;
        private readonly ColorServices _colorServices;
        private readonly ProductServices _productServices;

        public StockRoomDataServices(ShoesDBEntities shoesDataEntities, ColorServices colorServices,
            ProductServices productServices)
        {
            this._shoesDataEntities = shoesDataEntities;
            this._colorServices = colorServices;
            this._productServices = productServices;
        }

        public void InsertNewProductInStock(StockRoomDto stockRoomDto)
        {
            Color shoesColor;
            if (stockRoomDto.SelectedColor.ColorId == null)
            {
                shoesColor = new Color {Name = stockRoomDto.SelectedColor.Name};
                _shoesDataEntities.Colors.Add(shoesColor);
            }
            else
            {
                shoesColor = _colorServices.FindColor(stockRoomDto.SelectedColor.ColorId);
            }

            StockRoom newStockRoom;
            if (!stockRoomDto.SelectedColor.ColorId.HasValue
                || !_productServices.ExistProduct(
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

        public List<ModelDto> GetAllAvailableModels()
        {
            var availableModelKeys = _shoesDataEntities.StockRooms
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

        public List<ColorDto> GetAllStockShoesColorByModelId(int modelId)
        {
            var availableColorKeys = _shoesDataEntities.StockRooms
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

        public List<double> GetAllShoesSizesByColorAndModel(int modeId, int? colorId)
        {
            return _shoesDataEntities.StockRooms
                .Where(st => st.Product.ModelId == modeId && st.Product.ColorId == colorId)
                .GroupBy(st => st.ProductId)
                .Select(p => p.OrderByDescending(t => t.Id).FirstOrDefault())
                .Where(st => st.StockValue > 0)
                .Select(st => st.Product.Size)
                .Distinct()
                .ToList();
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }

        private StockRoom AddNewStockRoomUpdatingTotal(StockRoomDto newStockRoomDto)
        {
            var currentProduct = _productServices.FindProduct(
                newStockRoomDto.ModelId,
                newStockRoomDto.SelectedColor.ColorId,
                newStockRoomDto.Size);

            var lastStockRoom = GetLastStockRoomByProductId(currentProduct.Id);
            var stocks = newStockRoomDto.Quantity;
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
            _shoesDataEntities.StockRooms.Add(newStockRoom);
            return newStockRoom;
        }

        private void AddNewChargeToAccount(int stockRoomId, int quantity, double unitCost)
        {
            var newCheckingAccount = new CheckingAccount
            {
                Charge = quantity * unitCost,
                StockRoomId = stockRoomId
            };
            _shoesDataEntities.CheckingAccounts.Add(newCheckingAccount);
        }

        private StockRoom AddNewStockRoomAndProduct(StockRoomDto newStockRoomDto, int colorId)
        {
            var currentProduct = new Product
            {
                ModelId = newStockRoomDto.ModelId,
                ColorId = colorId,
                Size = newStockRoomDto.Size,
            };
            _shoesDataEntities.Products.Add(currentProduct);
            var newStockRoom = new StockRoom
            {
                ProductId = currentProduct.Id,
                StockValue = newStockRoomDto.Quantity,
                EntryValue = newStockRoomDto.Quantity,
                EntryDate = newStockRoomDto.EntryDate,
                OperationType = OperationType.IN.ToString(),
                SupplierId = newStockRoomDto.SupplierId
            };
            _shoesDataEntities.StockRooms.Add(newStockRoom);
            return newStockRoom;
        }

        private StockRoom GetLastStockRoomByProductId(int productId)
        {
            return _shoesDataEntities.StockRooms
                .Where(s => s.ProductId == productId)
                .OrderByDescending(s => s.Id)
                .FirstOrDefault();
        }

        private StockRoom GetLastStockRoomByProductId(int modelId, int colorId, double size)
        {
            var currentProduct = _productServices.FindProduct(modelId, colorId, size);
            return currentProduct == null ? null : GetLastStockRoomByProductId(currentProduct.Id);
        }

        private StoreStockRoom GetLastStoreStockRoomByProductId(int productId)
        {
            return _shoesDataEntities.StoreStockRooms
                .Where(s => s.ProductId == productId)
                .OrderByDescending(s => s.Id)
                .FirstOrDefault();
        }

        private StoreStockRoom GetLastStoreStockRoomByProductId(int modelId, int colorId, double size)
        {
            var currentProduct = _productServices.FindProduct(modelId, colorId, size);
            return currentProduct == null ? null : GetLastStoreStockRoomByProductId(currentProduct.Id);
        }

        public int GetTotalShoesInStockRoomByProduct(int modelId, int? colorId, double size)
        {
            var currentProduct = _productServices.FindProduct(modelId, colorId, size);
            if (currentProduct == null) return 0;
            var lastStockEntry = GetLastStockRoomByProductId(currentProduct.Id);
            return lastStockEntry?.StockValue ?? 0;
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

            var lastStockRoom = GetLastStockRoomByProductId(currentProduct.Id);
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
                OperationType = OperationType.OUT.ToString()
            };
            _shoesDataEntities.StockRooms.Add(newStockRoom);
            var lastStoreStockRoom = GetLastStoreStockRoomByProductId(currentProduct.Id);
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
    }
}