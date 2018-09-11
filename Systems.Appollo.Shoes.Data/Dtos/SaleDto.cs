using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Data.Dtos
{
    public class SaleDto
    {
        public SaleDto()
        {
            this.SalesProducts = new List<SaleProductDto>();
        }

        public int? ClientId { get; set; }

        public int? StoreId { get; set; }

        public List<SaleProductDto> SalesProducts { get; }

        public int ProductCounts => SalesProducts.Count;

        public double TotalSaleAmount
        {
            get
            {
                return SalesProducts.Sum(sp => sp.TotalAmount);
            }
        }

        public DateTime SellingDate { get; set; }
    }
}
