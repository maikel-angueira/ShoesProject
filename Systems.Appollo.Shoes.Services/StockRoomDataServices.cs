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

        public List<ModelDto> GetAllAvaibleModels()
        {
            var availableModelKeys = _shoesDataEntities.StockRooms
                .Where(st => st.OperationType == "IN")
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
                .Where(st => st.OperationType == "IN")
                .Where(st => st.Product.ModelId == modelId)
                .GroupBy(st => st.ProductId)
                .Select(p => p.OrderByDescending(t => t.Id).FirstOrDefault())
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
                .Where(st => st.OperationType == "IN")
                .Where(st => st.Product.ModelId == modeId && st.Product.ColorId == colorId)
                .GroupBy(st => st.ProductId)
                .Select(p => p.OrderByDescending(t => t.Id).FirstOrDefault())
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
                newStockRoomDto.SelectedColor.ColorId.Value,
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

        public int GetTotalShoesInStockRoomByProduct(int modelId, int? colorId, double size)
        {
            var lastStockEntry = _shoesDataEntities.StockRooms
                .Where(st =>
                    st.Product.ModelId == modelId
                    && st.Product.ColorId == colorId
                    && st.Product.Size == size)
                .Where(st => st.OperationType == "IN")
                .GroupBy(st => st.ProductId)
                .Select(p => p.OrderByDescending(t => t.Id).FirstOrDefault())
                .SingleOrDefault();
            return lastStockEntry?.EntryValue ?? 0;
        }
    }
}