using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Data.Dtos
{
    public class SaleProductDto
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string ColorName { get; set; }
        public int? ColorId { get; set; }
        public byte[] ModelPhoto { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public double TotalAmount => Quantity * Price;

        public double? Size { get; set; }
    }
}
