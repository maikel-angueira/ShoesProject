using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Data.DataModels
{
    public class StockRoomDto
    {
        public int ModelId { get; set; }
        public ColorDto SelectedColor { get; set; }
        public double Size { get; set; }
        public int Quantity { get; set; }
        public double UnitCost { get; set; }
        public DateTime InputDate { get; set; }
        public string Description { get; set; }
        public int? SupplierId { get; set; }
    }
}
