using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Data.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.DataServices
{
    public class ShoesClientServices
    {
        private readonly ColorServices colorServices;
        private readonly ModelServices modelServices;
        private readonly SellerServices sellerServices;
        private readonly ClientServices clientServices;
        private readonly SupplierServices supplierServices;
        private readonly StoreServices storeServices;
        private readonly StockRoomDataServices stockroomServices;

        public ShoesClientServices()
        {
            this.colorServices = new ColorServices();
            this.modelServices = new ModelServices();
            this.sellerServices = new SellerServices();
            this.clientServices = new ClientServices();
            this.supplierServices = new SupplierServices();
            this.storeServices = new StoreServices();
            this.stockroomServices = new StockRoomDataServices();
        }

        public ClientServices ClientServices => clientServices;

        public ColorServices ColorServices => colorServices;

        public ModelServices ModelServices => modelServices;

        public SellerServices SellerServices => sellerServices;

        public SupplierServices SupplierServices => supplierServices;

        public StoreServices StoreServices => storeServices;

        public StockRoomDataServices StockRoomServices => stockroomServices;
    }
}
