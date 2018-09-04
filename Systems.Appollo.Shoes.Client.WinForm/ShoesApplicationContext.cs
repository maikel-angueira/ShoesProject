using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data;

namespace Systems.Appollo.Shoes.Client.WinForm
{
    public sealed class ShoesApplicationContext
    {
        private static ShoesDBEntities shoesDBEntities = new ShoesDBEntities();
        public static ShoesDBEntities ShoesDataEntities
        {
            get
            {
                return shoesDBEntities;
            }
        }
    }
}
