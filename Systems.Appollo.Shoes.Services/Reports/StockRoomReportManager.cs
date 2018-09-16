using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data;
using Systems.Appollo.Shoes.Services.Reports.Dto;

namespace Systems.Appollo.Shoes.Services.Reports
{
    public class StockRoomReportManager
    {
        private readonly ShoesDBEntities _shoesDBDataEntities;

        public StockRoomReportManager(ShoesDBEntities shoesDB)
        {
            this._shoesDBDataEntities = shoesDB;
        }

        public List<ProductDetailsDto> GetStockRoomExistences()
        {
            var lastStockByProducts = _shoesDBDataEntities.StockRooms
                .GroupBy(st => st.ProductId)
                .Select(g => g.OrderByDescending(st => st.Id).FirstOrDefault());

            return lastStockByProducts.Select(st =>
                    new ProductDetailsDto
                    {
                        Photo = st.Product.Model.Photo,
                        ModelName = st.Product.Model.Name,
                        Color = st.Product.Color.Name,
                        Size = st.Product.Size,
                        LastStockDate = st.EntryDate,
                        Total = st.StockValue
                    }).OrderByDescending(p => p.Total).ToList();
        }

        public List<ProductDetailsDto> GetStoreStockRoomExistingByStoreId(int storeId)
        {
            var lastStockByProducts = _shoesDBDataEntities.StoreStockRooms
                .Where(st => st.StoreId == storeId)
                .GroupBy(st => st.ProductId)
                .Select(g => g.OrderByDescending(st => st.Id).FirstOrDefault());

            return lastStockByProducts.Select(st =>
                    new ProductDetailsDto
                    {
                        Photo = st.Product.Model.Photo,
                        ModelName = st.Product.Model.Name,
                        Color = st.Product.Color.Name,
                        Size = st.Product.Size,
                        LastStockDate = st.EntryDate,
                        Total = st.StockValue
                    }).OrderByDescending(p => p.Total).ToList();
        }
    }
}
