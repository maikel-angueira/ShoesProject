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
using Systems.Appollo.Shoes.Services.Reports;
using Systems.Appollo.Shoes.Services.Reports.Dto;

namespace Systems.Appollo.Shoes.Client.WinForm.ReportViews
{
    public partial class StockRoomExistingForm : Form
    {
        private List<ProductDetailsDto> stockRoomProductDetails;

        public StockRoomExistingForm()
        {
            InitializeComponent();
            productDetailsDataGridView.AutoGenerateColumns = false;
        }

        private void StockRoomExistingForm_Load(object sender, EventArgs e)
        {
            this.stockRoomProductDetails = ShoesClientDataServices.StockRoomReportManager.GetStockRoomExistences();
            if (stockRoomProductDetails.Count == 0)
                MessageBox.Show(Messages.NO_EXISTING_PRODUCTS_ON_THE_STOCK, Constants.MESSAGE_CAPTION);
            else
            {
                productDetailsDataGridView.DataSource = stockRoomProductDetails;
                ConfigureGridGroupByModelName();
                var modelNames = stockRoomProductDetails.Select(s => s.ModelName).Distinct().ToList();
                modelNames.Insert(0, "--Seleccionar Todos--");
                modelNames.ForEach(m => modelComboBox.Items.Add(m));
                modelComboBox.SelectedIndex = 0;
            }
        }

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
    }
}
