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
        public ShoesClientServices()
        {
            this.ColorServices = new ColorServices(ShoesApplicationContext.ShoesDataEntities);
            this.ModelServices = new ModelServices(ShoesApplicationContext.ShoesDataEntities);
            this.SellerServices = new SellerServices(ShoesApplicationContext.ShoesDataEntities);
            this.ClientServices = new ClientServices(ShoesApplicationContext.ShoesDataEntities);
            this.SupplierServices = new SupplierServices(ShoesApplicationContext.ShoesDataEntities);
            this.StoreServices = new StoreServices(ShoesApplicationContext.ShoesDataEntities);
            var productServices = new ProductServices(ShoesApplicationContext.ShoesDataEntities);
            this.StockRoomServices = new StockRoomDataServices(ShoesApplicationContext.ShoesDataEntities,
                ColorServices, productServices);
            this.SalesServices = new SalesServices(ShoesApplicationContext.ShoesDataEntities,
                StockRoomServices, productServices);
        }

        public ClientServices ClientServices { get; }

        public ColorServices ColorServices { get; }

        public ModelServices ModelServices { get; }

        public SellerServices SellerServices { get; }

        public SupplierServices SupplierServices { get; }

        public StoreServices StoreServices { get; }

        public StockRoomDataServices StockRoomServices { get; }

        public SalesServices SalesServices { get; }
    }
}