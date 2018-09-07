using System;

namespace Systems.Appollo.Shoes.Data.DataModels
{
    public class StoreStockRoomDto
    {
        public int ModelId { get; set; }
        public int? ColorId { get; set; }
        public double? Size { get; set; }
        public int Quantity { get; set; }
        public int StoreId { get; set; }
        public DateTime DateOfSupplier { get; set; }
    }
}