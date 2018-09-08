using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Data.Dtos;

namespace Systems.Appollo.Shoes.Services
{
    public class SalesServices
    {
        private readonly ShoesDBEntities _shoesDataEntities;
        private readonly StockRoomDataServices _stockRoomDataServices;
        private readonly ProductServices _productServices;

        public SalesServices(ShoesDBEntities shoesDataEntities, StockRoomDataServices stockRoomDataServices, ProductServices productServices)
        {
            _shoesDataEntities = shoesDataEntities;
            _stockRoomDataServices = stockRoomDataServices;
            _productServices = productServices;
        }

        public void AddSalesAndDecrementStockProducts(SaleDto saleDto)
        {
            var newSale = new Sale()
            {
                DateOfSale = saleDto.DateOfSale,
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
                    UnitPrice = saleProductDto.Price
                };
                _shoesDataEntities.SaleProducts.Add(newSaleProduct);
                var lastStockRoom = _stockRoomDataServices.GetLastStockRoomByProductId(currentProduct.Id);
                var newStockRoom = new StockRoom()
                {
                    ProductId = currentProduct.Id,
                    StockValue = lastStockRoom.StockValue - saleProductDto.Quantity,
                    EntryValue = -saleProductDto.Quantity,
                    EntryDate = saleDto.DateOfSale,
                    OperationType = OperationType.OUT.ToString()
                };
                _shoesDataEntities.StockRooms.Add(newStockRoom);
                var newCheckingAccount = new CheckingAccount()
                {
                    StockRoomId = newStockRoom.Id,
                    SaleId = newSale.Id,
                    Incoming = saleProductDto.TotalAmount
                };
                _shoesDataEntities.CheckingAccounts.Add(newCheckingAccount);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            _shoesDataEntities.SaveChanges();
        }
    }
}