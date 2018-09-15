using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.Dtos;

namespace Systems.Appollo.Shoes.Services.Data
{
    public class SalesServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;
        private readonly StockRoomDataServices _stockRoomDataServices;
        private readonly ProductServices _productServices;
        private readonly StoreStockRoomDataServices _storeStockRoomDataServices;

        public SalesServices(
            ShoesDBEntities shoesDataEntities, 
            StockRoomDataServices stockRoomDataServices,
            StoreStockRoomDataServices storeStockRoomDataServices,
            ProductServices productServices)
        {
            _shoesDataEntities = shoesDataEntities;
            _stockRoomDataServices = stockRoomDataServices;
            _storeStockRoomDataServices = storeStockRoomDataServices;
            _productServices = productServices;
        }

        public void AddSalesToStockAndDecrementProducts(SaleDto saleDto)
        {
            var newSale = new Sale()
            {
                SellingDate = saleDto.SellingDate,
                ClientId = saleDto.ClientId
            };
            _shoesDataEntities.Sales.Add(newSale);
            foreach (var saleProductDto in saleDto.SalesProducts)
            {
                var currentProduct = _productServices.FindProduct(
                    saleProductDto.ModelId, saleProductDto.ColorId, saleProductDto.Size);
                var newSaleProduct = new SaleProduct
                {
                    ProductId = currentProduct.Id,
                    SaleId = newSale.Id,
                    Quantity = saleProductDto.Quantity,
                    SellingPrice = saleProductDto.Price
                };
                _shoesDataEntities.SaleProducts.Add(newSaleProduct);
                var lastStockRoom = _stockRoomDataServices.GetLastStockRoomByProductId(currentProduct.Id);
                var newStockRoom = new StockRoom()
                {
                    ProductId = currentProduct.Id,
                    StockValue = lastStockRoom.StockValue - saleProductDto.Quantity,
                    EntryValue = -saleProductDto.Quantity,
                    EntryDate = saleDto.SellingDate,
                    OperationType = OperationType.OUT.ToString()
                };
                _shoesDataEntities.StockRooms.Add(newStockRoom);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }

        public void AddSalesToStoreAndDecrementStockProducts(SaleDto saleDto)
        {
            var newSale = new Sale()
            {
                SellingDate = saleDto.SellingDate,
                StoreId = saleDto.StoreId
            };
            _shoesDataEntities.Sales.Add(newSale);
            foreach (var saleProductDto in saleDto.SalesProducts)
            {
                var currentProduct = _productServices.FindProduct(
                    saleProductDto.ModelId, saleProductDto.ColorId, saleProductDto.Size);
                var newSaleProduct = new SaleProduct
                {
                    ProductId = currentProduct.Id,
                    SaleId = newSale.Id,
                    Quantity = saleProductDto.Quantity,
                    SellingPrice = saleProductDto.Price
                };
                _shoesDataEntities.SaleProducts.Add(newSaleProduct);
                var lastStockRoom = _storeStockRoomDataServices.GetLastStoreStockRoomByProductId(saleDto.StoreId.Value, currentProduct.Id);
                var newStoreStockRoom = new StoreStockRoom()
                {
                    ProductId = currentProduct.Id,
                    StockValue = lastStockRoom.StockValue - saleProductDto.Quantity,
                    EntryValue = -saleProductDto.Quantity,
                    EntryDate = saleDto.SellingDate,
                    StoreId = saleDto.StoreId.Value,
                    OperationType = OperationType.OUT.ToString()
                };
                _shoesDataEntities.StoreStockRooms.Add(newStoreStockRoom);
                SaveChanges();
            }
        }
    }
}