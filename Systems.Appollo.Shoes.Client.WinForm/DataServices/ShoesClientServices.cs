using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Systems.Appollo.Shoes.Services;
using Systems.Appollo.Shoes.Services.Data;
using Systems.Appollo.Shoes.Services.Reports;

namespace Systems.Appollo.Shoes.Client.WinForm.DataServices
{
    public class ShoesClientServices
    {
        public ShoesClientServices()
        {
            var shoesDbEntities = ShoesApplicationContext.ShoesDataEntities;
            this.ColorServices = new ColorServices(shoesDbEntities);
            this.ModelServices = new ModelServices(shoesDbEntities);
            this.SellerServices = new SellerServices(shoesDbEntities);
            this.ClientServices = new ClientServices(shoesDbEntities);
            this.SupplierServices = new SupplierServices(shoesDbEntities);
            this.StoreServices = new StoreServices(shoesDbEntities);
            var productServices = new ProductServices(shoesDbEntities);
            this.StockRoomServices = new StockRoomDataServices(shoesDbEntities,
                ColorServices, productServices);
            this.StoreStockRoomServices = new StoreStockRoomDataServices(
                shoesDbEntities, StockRoomServices, productServices);
            this.SalesServices = new SalesServices(shoesDbEntities,
                StockRoomServices, StoreStockRoomServices, productServices);
            this.ShoesTypeDataServices = new ShoesTypeServices(shoesDbEntities);
            this.StockRoomReportManager = new StockRoomReportManager(shoesDbEntities);
        }

        public ClientServices ClientServices { get; }

        public ColorServices ColorServices { get; }

        public ModelServices ModelServices { get; }

        public SellerServices SellerServices { get; }

        public SupplierServices SupplierServices { get; }

        public StoreServices StoreServices { get; }

        public StockRoomDataServices StockRoomServices { get; }

        public SalesServices SalesServices { get; }
        public StoreStockRoomDataServices StoreStockRoomServices { get;}

        public  ShoesTypeServices ShoesTypeDataServices { get; }
        public StockRoomReportManager StockRoomReportManager { get; }
    }
}