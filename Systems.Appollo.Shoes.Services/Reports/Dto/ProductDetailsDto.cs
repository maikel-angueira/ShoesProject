using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Services.Reports.Dto
{
    public class ProductDetailsDto
    {
        private string _modelName;

        public int ProductId { get; set; }
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }
        public string Color { get; set; }
        public double Size { get; set; } 
        public DateTime LastStockDate { get; set; }
        public int Total { get; set; }
        public byte[] Photo { get; internal set; }

    }
}
