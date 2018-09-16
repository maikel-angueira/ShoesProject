using Subro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Systems.Appollo.Shoes.Client.WinForm.DataServices;
using Systems.Appollo.Shoes.Client.WinForm.Utils;
using Systems.Appollo.Shoes.Data.DataModels;
using Systems.Appollo.Shoes.Services.Reports;
using Systems.Appollo.Shoes.Services.Reports.Dto;

namespace Systems.Appollo.Shoes.Client.WinForm.ReportViews
{
    public partial class StoreStockRoomExistingForm : Form
    {
        private List<ProductDetailsDto> stockRoomProductDetails;

        public StoreStockRoomExistingForm()
        {
            InitializeComponent();
            productDetailsDataGridView.AutoGenerateColumns = false;
        }

        private void StockRoomExistingForm_Load(object sender, EventArgs e)
        {

            var stores = ShoesClientDataServices.StoreServices.GetAllStores();
            if (stores.Count == 0)
            {
                MessageBox.Show(Messages.NO_STORE_EXISTING_IN_DB, Constants.MESSAGE_CAPTION);
                return;
            }

            storeComboBox.DataSource = stores;
            UpdateView();
        }

        private void UpdateView()
        {
            this.stockRoomProductDetails = ShoesClientDataServices.StockRoomReportManager.GetStoreStockRoomExistingByStoreId(SelectedStoreDto.StoreId);
            filterButton.Enabled = stockRoomProductDetails.Count > 0;
            modelComboBox.Items.Clear();
            if (stockRoomProductDetails.Count == 0)
            {
                productDetailsDataGridView.DataSource = new List<ProductDetailsDto>();
            }
            else
            {
                ReloadViewComponent(stockRoomProductDetails);
            }
        }

        private void ReloadViewComponent(List<ProductDetailsDto> list)
        {
            productDetailsDataGridView.DataSource = list;
            ConfigureGridGroupByModelName();
            var modelNames = list.Select(s => s.ModelName).Distinct().ToList();
            modelNames.Insert(0, "--Seleccionar Todos--");
            modelNames.ForEach(m => modelComboBox.Items.Add(m)); modelComboBox.SelectedIndex = 0;
        }

        private StoreDto SelectedStoreDto => (StoreDto)storeComboBox.SelectedItem;

        private void ConfigureGridGroupByModelName()
        {
            var grouper = new Subro.Controls.DataGridViewGrouper(productDetailsDataGridView);
            grouper.SetGroupOn(ModelNameColumn);
            grouper.DisplayGroup += grouper_DisplayGroup;
            grouper.Options.ShowGroupName = false;
            grouper.Options.ShowCount = false;
        }

        void grouper_DisplayGroup(object sender, GroupDisplayEventArgs e)
        {
            e.BackColor = Color.LightBlue;
            //e.Header = "[" + e.Header + "], grp: " + e.Group.GroupIndex;
            //e.DisplayValue = "Value is " + e.DisplayValue;
            e.Summary = "contiene " + e.Group.Count + " modelos de zapatos";
        }

        public ShoesClientServices ShoesClientDataServices { get; set; }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            List<ProductDetailsDto> dataSource;
            if (modelComboBox.SelectedIndex == 0)
            {
                dataSource = stockRoomProductDetails;
            }
            else
            {
                dataSource = stockRoomProductDetails.Where(st => st.ModelName == FilterModelName).ToList();
            }
            productDetailsDataGridView.DataSource = dataSource;
            ConfigureGridGroupByModelName();
        }

        private string FilterModelName => modelComboBox.SelectedItem as string;

        private void productDetailsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void StockRoomExistingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            productDetailsDataGridView.DataSource = new List<ProductDetailsDto>();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}
