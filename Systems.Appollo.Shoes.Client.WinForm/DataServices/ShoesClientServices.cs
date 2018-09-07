using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Services;

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
        private readonly ProductServices productServices;

        public ShoesClientServices()
        {
            this.colorServices = new ColorServices(ShoesApplicationContext.ShoesDataEntities);
            this.modelServices = new ModelServices(ShoesApplicationContext.ShoesDataEntities);
            this.sellerServices = new SellerServices(ShoesApplicationContext.ShoesDataEntities);
            this.clientServices = new ClientServices(ShoesApplicationContext.ShoesDataEntities);
            this.supplierServices = new SupplierServices(ShoesApplicationContext.ShoesDataEntities);
            this.storeServices = new StoreServices(ShoesApplicationContext.ShoesDataEntities);
            this.productServices = new ProductServices(ShoesApplicationContext.ShoesDataEntities);
            this.stockroomServices = new StockRoomDataServices(ShoesApplicationContext.ShoesDataEntities, colorServices, productServices);
        }

        public ClientServices ClientServices => clientServices;

        public ColorServices ColorServices => colorServices;

        public ModelServices ModelServices => modelServices;

        public SellerServices SellerServices => sellerServices;

        public SupplierServices SupplierServices => supplierServices;

        public StoreServices StoreServices => storeServices;

        public StockRoomDataServices StockRoomServices => stockroomServices;

        public ProductServices ProductServices => productServices;
    }
}
