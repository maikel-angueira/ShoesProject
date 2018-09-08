using Panic.StringUtils.Extensions;
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

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Stockroom
{
    public partial class NewStoreStockSupplierEntryForm : Form
    {
        public ShoesClientServices ShoesDataClientServices { get; set; }

        public NewStoreStockSupplierEntryForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewStockroomEntryForm_Load(object sender, EventArgs e)
        {
            var shoesModels = ShoesDataClientServices.StockRoomServices.GetAllAvailableModels();
            var stores = ShoesDataClientServices.StoreServices.GetAllStores();
            modelComboBox.DataSource = shoesModels;
            storeComboBox.DataSource = stores;
            var isEnable = shoesModels.Count > 0 && stores.Count > 0;
            addButton.Enabled = isEnable;
            photoLinkLabel.Enabled = isEnable;
            ReloadShoesModelPicture(SelectedModelDto);
        }

        private void ReloadShoesModelPicture(ModelDto selectedModel)
        {
            this.shoesPictureBox.Image = null;
            if (selectedModel != null)
            {
                PictureViewUtils.LoadImageToControl(selectedModel.Photo, shoesPictureBox);
            }
        }

        private ColorDto SelectedColorDto => colorComboBox.SelectedItem as ColorDto;

        private ModelDto SelectedModelDto => modelComboBox.SelectedItem as ModelDto;

        private StoreDto SelectedStoreDto => storeComboBox.SelectedItem as StoreDto;

        private List<ColorDto> Colors { get; set; }

        private void modelComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ReloadShoesModelPicture(SelectedModelDto);
            var availableColors = ShoesDataClientServices.StockRoomServices.GetAllStockShoesColorByModelId(SelectedModelDto.ModelId);
            addButton.Enabled = availableColors.Count > 0;
            colorComboBox.DataSource = availableColors;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (SelectedColorDto == null 
                || SelectedModelDto == null 
                || SelectedStoreDto == null 
                || ShoesSize == null)
            {
                MessageBox.Show(Messages.STORE_SUPPIER_VALUES_REQUIRED, Constants.MESSAGE_CAPTION);
                return;
            }

            var newDto = new StoreStockRoomDto()
            {
                ModelId = SelectedModelDto.ModelId,
                ColorId = SelectedColorDto.ColorId,
                Size = ShoesSize,
                Quantity = (int)quantityNumericUpDown.Value,
                DateOfSupplier = dateInTime.Value,
                StoreId = SelectedStoreDto.StoreId
            };
            ShoesDataClientServices.StoreStockRoomServices.SupplyStoreStockRoom(newDto);
            var max = quantityNumericUpDown.Maximum;
            max -= newDto.Quantity;
            quantityNumericUpDown.Maximum = max;
            quantityNumericUpDown.Value = max;
            ResetView();
            MessageBox.Show(Messages.NEW_PRODUCT_CREATED_SUCESSS, Constants.MESSAGE_CAPTION);
        }

        private double? ShoesSize => (double?) sizeComboBox.SelectedItem;

        private void ResetView()
        {
            dateInTime.Value = DateTime.Now;
            if (SelectedColorDto.ColorId != null) return;
            Colors = ShoesDataClientServices.ColorServices.GetAllColors();
            colorComboBox.DataSource = Colors;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            var uploadPicture = PictureViewUtils.ReadImageFromFilePath(openFileDialog1.FileName);
            ShoesDataClientServices.ModelServices.UpdateShoesModelPicture(SelectedModelDto.ModelId, uploadPicture);
            SelectedModelDto.Photo = uploadPicture;
            LoadNewPhoto(openFileDialog1.FileName);
        }

        private void LoadNewPhoto(string fileName)
        {
            Image img = new Bitmap(fileName);
            shoesPictureBox.Image = img;
            shoesPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void colorComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var sizeItems = ShoesDataClientServices.StockRoomServices.GetAllShoesSizesByColorAndModel(
                SelectedModelDto.ModelId, SelectedColorDto.ColorId);
            sizeComboBox.Items.Clear();
            addButton.Enabled = sizeItems.Count > 0;
            foreach (var item in sizeItems)
                sizeComboBox.Items.Add(item);
            if (sizeItems.Count > 0)
                sizeComboBox.SelectedIndex = 0;
        }

        private void sizeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var modelId = SelectedModelDto.ModelId;
            var colorId = SelectedColorDto.ColorId;
            var size = (double)sizeComboBox.SelectedItem;
            var totalShoes = ShoesDataClientServices.StockRoomServices.GetTotalShoesInStockRoomByProduct(modelId, colorId, size);
            quantityNumericUpDown.Maximum = totalShoes;
            quantityNumericUpDown.Value = totalShoes;
        }
    }
}
