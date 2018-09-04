using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systems.Appollo.Shoes.Data.DataModels
{
    public class SellerDto
    {
        public int SellerId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public byte[] Photo { get; set; }

    }
}
