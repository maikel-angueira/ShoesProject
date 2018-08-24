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
        private readonly ClientServices clientServices;

        public Services()
        {
            this.colorServices = new ColorServices();
            this.modelServices = new ModelServices();
            this.sellerServices = new SellerServices();
            this.clientServices = new ClientServices();
        }

        public ClientServices ClientServices => clientServices;

        public ColorServices ColorServices => colorServices;

        public ModelServices ModelServices => modelServices;

        public SellerServices SellerServices => sellerServices;
    }
}
