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
using Systems.Appollo.Shoes.Data.Dtos;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Sales
{
    public partial class NewSaleFromStoreStockRoomForm : Form
    {
        public NewSaleFromStoreStockRoomForm()
        {
            InitializeComponent();
            saleProductDataGridView.AutoGenerateColumns = false;
            CurrentSaleDto = NewSaleDto();
            priceNumericUpDown.Maximum = decimal.MaxValue;
        }

        private SaleDto CurrentSaleDto { get; set; }

        private static SaleDto NewSaleDto()
        {
            return new SaleDto();
        }

        public ShoesClientServices ShoesDataServices { private get; set; }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void NewSaleFromStockRoomForm_Load(object sender, EventArgs e)
        {
            var stores = ShoesDataServices.StoreServices.GetAllStores();
            storeComboBox.DataSource = stores;
            newSaleButton.Enabled = stores.Count > 0;
        }

        private void UpdateAvailablesModelByStore(int storeId)
        {
            var availableModels =
                            ShoesDataServices.StoreStockRoomServices.GetAllAvailableModelsByStoreId(storeId);
            addButton.Enabled = availableModels.Count > 0;
            modelComboBox.DataSource = availableModels;
            if (availableModels.Count == 0)
            {
                colorComboBox.DataSource = new List<ColorDto>();
                sizeComboBox.DataSource = new List<double>();
            }
        }

        private ModelDto SelectedModelDto => modelComboBox.SelectedItem as ModelDto;

        private ColorDto SelectedColorDto => colorComboBox.SelectedItem as ColorDto;

        private double? SelectedShoesSize => (double?)sizeComboBox.SelectedItem;

        private void modelComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SelectedModelDto == null)
            {
                addButton.Enabled = false;
                return;
            }

            var colorByModels =
                ShoesDataServices.StoreStockRoomServices.GetAllStockShoesColorByModelId(SelectedStoreDto.StoreId, SelectedModelDto.ModelId);
            colorComboBox.DataSource = colorByModels;
        }

        private void colorComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SelectedColorDto == null)
            {
                addButton.Enabled = false;
                return;
            }

            var shoesSizes =
                ShoesDataServices.StoreStockRoomServices.GetAllShoesSizesByColorAndModel(SelectedStoreDto.StoreId, SelectedModelDto.ModelId,
                    SelectedColorDto.ColorId);
            sizeComboBox.DataSource = shoesSizes;
        }

        private void sizeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateProductsSizeMax();
        }

        private void UpdateProductsSizeMax()
        {
            var modelId = SelectedModelDto.ModelId;
            var colorId = SelectedColorDto.ColorId;
            var totalShoes =
                ShoesDataServices.StoreStockRoomServices.GetTotalShoesInStockRoomByProduct(SelectedStoreDto.StoreId, modelId, colorId,
                    SelectedShoesSize);
            var shoesSales = CurrentSaleDto.SalesProducts.Where(dto =>
                    dto.ModelId == modelId
                    && dto.ColorId == colorId
                    && dto.Size == SelectedShoesSize)
                .Sum(dto => dto.Quantity);
            var remainShoes = totalShoes - shoesSales;
            quantityNumericUpDown.Maximum = remainShoes;
            quantityNumericUpDown.Value = remainShoes;
            addButton.Enabled = remainShoes > 0;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (priceNumericUpDown.Value == 0)
            {
                if (MessageBox.Show(
                        Messages.SALE_PRODUCT_PRICE_EQUAL_CERO,
                        Constants.MESSAGE_CAPTION,
                        MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
            }

            var newSaleProductDto = new SaleProductDto
            {
                ColorId = SelectedColorDto.ColorId,
                ColorName = SelectedColorDto.Name,
                ModelId = SelectedModelDto.ModelId,
                ModelName = SelectedModelDto.Name,
                ModelPhoto = SelectedModelDto.Photo,
                Price = (double)priceNumericUpDown.Value,
                Quantity = (int)quantityNumericUpDown.Value,
                Size = SelectedShoesSize
            };
            CurrentSaleDto.SalesProducts.Add(newSaleProductDto);
            saleProductDtoBindingSource.Add(newSaleProductDto);
            saveSalesButton.Enabled = true;
            removeAllButton.Enabled = true;
            UpdateToolStripStatus();
            UpdateProductsSizeMax();
        }

        private void UpdateToolStripStatus()
        {
            quantityToolStripStatusLabel.Text = CurrentSaleDto.ProductCounts.ToString();
            totalSaleToolStripStatusLabel.Text = CurrentSaleDto.TotalSaleAmount.ToString();
        }

        private SaleProductDto SelectedSaleProductDto => saleProductDtoBindingSource.Current as SaleProductDto;

        private void saleProductDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            removeProductButton.Enabled = SelectedSaleProductDto != null;
        }

        private void removeProductButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    Messages.REMOVE_PRODUCT_FROM_SALE,
                    Constants.MESSAGE_CAPTION,
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            if (SelectedSaleProductDto == null) return;
            var isLoaded =
                SelectedSaleProductDto.ModelId == SelectedModelDto.ModelId
                && SelectedSaleProductDto.ColorId == SelectedColorDto.ColorId
                && SelectedSaleProductDto.Size == SelectedShoesSize;
            CurrentSaleDto.SalesProducts.Remove(SelectedSaleProductDto);
            saleProductDtoBindingSource.RemoveCurrent();
            removeProductButton.Enabled = SelectedSaleProductDto != null;
            saveSalesButton.Enabled = CurrentSaleDto.SalesProducts.Count > 0;
            removeAllButton.Enabled = CurrentSaleDto.SalesProducts.Count > 0;
            UpdateToolStripStatus();
            if (isLoaded) UpdateProductsSizeMax();
        }

        private StoreDto SelectedStoreDto => storeComboBox.SelectedItem as StoreDto;

        private void saveSalesButton_Click(object sender, EventArgs e)
        {
            CurrentSaleDto.StoreId = SelectedStoreDto?.StoreId ?? null;
            CurrentSaleDto.DateOfSale = saleDateTimePicker.Value;
            ShoesDataServices.SalesServices.AddStoreSalesAndDecrementStockProducts(CurrentSaleDto);
            var message = string.Format(Messages.SALE_FOR_STORE_CREATED_SUCCCESS, SelectedStoreDto.Name,
                    CurrentSaleDto.TotalSaleAmount);
            ResetView();
            MessageBox.Show(message, Constants.MESSAGE_CAPTION);
        }

        private void ResetView()
        {
            CurrentSaleDto = NewSaleDto();
            saveSalesButton.Enabled = false;
            removeProductButton.Enabled = false;
            removeAllButton.Enabled = false;
            addButton.Enabled = false;
            newSaleButton.Enabled = true;
            cancelSaleButton.Enabled = false;
            saleProductDtoBindingSource.Clear();
            storeComboBox.Enabled = true;
            modelComboBox.DataSource = new List<ModelDto>();
            colorComboBox.DataSource = new List<ColorDto>();
            sizeComboBox.DataSource = new List<double>();
            priceNumericUpDown.Value = 0;
            quantityNumericUpDown.Value = 0;
            storeToolStripLabel.Text = "[Sin Seleccionar]";
            UpdateToolStripStatus();
        }

        private void newSaleButton_Click(object sender, EventArgs e)
        {
            CurrentSaleDto = NewSaleDto();           
            UpdateAvailablesModelByStore(SelectedStoreDto.StoreId);
            addButton.Enabled = true;
            newSaleButton.Enabled = false;
            storeComboBox.Enabled = false;
            cancelSaleButton.Enabled = true;
            storeToolStripLabel.Text = SelectedStoreDto.Name;
        }

        private void removeAllButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                    Messages.REMOVE_ALL_PRODUCT_FROM_SALE,
                    Constants.MESSAGE_CAPTION,
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            saleProductDtoBindingSource.Clear();
            CurrentSaleDto.SalesProducts.Clear();
            removeProductButton.Enabled = false;
            saveSalesButton.Enabled = false;
            removeAllButton.Enabled = false;            
            UpdateProductsSizeMax();
            UpdateToolStripStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ResetView();
        }
    }
}