using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.DataServices
{
    public class Services
    {
        private readonly ColorServices colorServices;
        private readonly ModelServices modelServices;
        private readonly SellerServices sellerServices;

        public Services()
        {
            this.colorServices = new ColorServices();
            this.modelServices = new ModelServices();
            this.sellerServices = new SellerServices();
        }

        public ColorServices ColorServices
        {
            get
            {
                return this.colorServices;
            }
        }

        public ModelServices ModelServices
        {
            get
            {
                return this.modelServices;
            }
        }

        public SellerServices SellerServices
        {
            get
            {
                return this.sellerServices;
            }
        }
    }
}
