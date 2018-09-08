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
using Systems.Appollo.Shoes.Data.DataModels;
using Systems.Appollo.Shoes.Data.Dtos;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Sales
{
    public partial class NewSaleFromStockRoomForm : Form
    {
        public NewSaleFromStockRoomForm()
        {
            InitializeComponent();
            saleProductDataGridView.AutoGenerateColumns = false;
            CurrentSaleDto = NewSaleDto();
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
            var clients = ShoesDataServices.ClientServices.GetAllClients();
            clientComboBox.DataSource = clients;
            var availableModels = ShoesDataServices.StockRoomServices.GetAllAvailableModels();
            addButton.Enabled = availableModels.Count > 0;
            modelComboBox.DataSource = availableModels;
        }

        private ModelDto SelectedModelDto => modelComboBox.SelectedItem as ModelDto;

        private ColorDto SelectedColorDto => colorComboBox.SelectedItem as ColorDto;

        private double? SelectedShoesSize => (double?) sizeComboBox.SelectedItem;

        private void modelComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SelectedModelDto == null)
            {
                addButton.Enabled = false;
                return;
            }

            var colorByModels =
                ShoesDataServices.StockRoomServices.GetAllStockShoesColorByModelId(SelectedModelDto.ModelId);
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
                ShoesDataServices.StockRoomServices.GetAllShoesSizesByColorAndModel(SelectedModelDto.ModelId,
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
                ShoesDataServices.StockRoomServices.GetTotalShoesInStockRoomByProduct(modelId, colorId,
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
            var newSaleProductDto = new SaleProductDto
            {
                ColorId = SelectedColorDto.ColorId,
                ColorName = SelectedColorDto.Name,
                ModelId = SelectedModelDto.ModelId,
                ModelName = SelectedModelDto.Name,
                ModelPhoto = SelectedModelDto.Photo,
                Price = (double) priceNumericUpDown.Value,
                Quantity = (int) quantityNumericUpDown.Value,
                Size = SelectedShoesSize
            };
            CurrentSaleDto.SalesProducts.Add(newSaleProductDto);
            saleProductDtoBindingSource.Add(newSaleProductDto);
            saveSalesButton.Enabled = true;
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
            if (SelectedSaleProductDto == null) return;
            var isLoaded =
                SelectedSaleProductDto.ModelId == SelectedModelDto.ModelId
                && SelectedSaleProductDto.ColorId == SelectedColorDto.ColorId
                && SelectedSaleProductDto.Size == SelectedShoesSize;
            CurrentSaleDto.SalesProducts.Remove(SelectedSaleProductDto);
            saleProductDtoBindingSource.RemoveCurrent();
            removeProductButton.Enabled = SelectedSaleProductDto != null;
            saveSalesButton.Enabled = CurrentSaleDto.SalesProducts.Count > 0;
            UpdateToolStripStatus();
            if (isLoaded) UpdateProductsSizeMax();
        }

        private ClientDto SelectedClientDto => clientComboBox.SelectedItem as ClientDto;

        private void saveSalesButton_Click(object sender, EventArgs e)
        {
            CurrentSaleDto.ClientId = SelectedClientDto?.ClientId ?? null;
            CurrentSaleDto.DateOfSale = saleDateTimePicker.Value;
            ShoesDataServices.SalesServices.AddSalesAndDecrementStockProducts(CurrentSaleDto);
            ResetView();
        }

        private void ResetView()
        {
            CurrentSaleDto = NewSaleDto();
            saveSalesButton.Enabled = false;
            removeProductButton.Enabled = false;
            addButton.Enabled = false;
            newSaleButton.Enabled = true;
            saleProductDtoBindingSource.Clear();
            UpdateToolStripStatus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addButton.Enabled = true;
            newSaleButton.Enabled = false;
        }
    }
}