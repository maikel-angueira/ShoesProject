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
    public partial class NewStockRoomSupplierEntryForm : Form
    {
        public ShoesClientServices ShoesDataClientServices { get; set; }

        public NewStockRoomSupplierEntryForm()
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
            var shoesModels = ShoesDataClientServices.ModelServices.GetAllModels();
            var suppliers = ShoesDataClientServices.SupplierServices.GetAllSuppliers();
            this.Colors = ShoesDataClientServices.ColorServices.GetAllColors();
            modelComboBox.DataSource = shoesModels;
            supplierComboBox.DataSource = suppliers;
            bool isEnable = shoesModels.Count > 0 && suppliers.Count > 0;
            addButton.Enabled = isEnable;
            photoLinkLabel.Enabled = isEnable;
            sizeComboBox.SelectedIndex = 0;           
        }

        private void ReloadShoesModelPicture(ModelDto selectedModel)
        {
            this.shoesPictureBox.Image = null;
            if (selectedModel != null)
            {
                PictureViewUtils.LoadImageToControl(selectedModel.Photo, shoesPictureBox);
            }
        }

        private ColorDto SelectedOrNewColorDto => colorComboBox.SelectedItem as ColorDto;

        private ModelDto SelectedModelDto
        {
            get
            {
                if (modelComboBox.SelectedItem == null) return null;
                return modelComboBox.SelectedItem as ModelDto;
            }
        }

        private SupplierDto SelectedSupplierDto
        {
            get
            {
                if (supplierComboBox.SelectedItem == null) return null;
                return supplierComboBox.SelectedItem as SupplierDto;
            }
        }

        private List<ColorDto> Colors { get; set; }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (SelectedOrNewColorDto == null)
            {
                MessageBox.Show(Messages.SELECTED_COLOR_REQUIRED, Constants.MESSAGE_CAPTION);
                return;
            }

            if (SelectedModelDto == null)
            {
                MessageBox.Show(Messages.SELECTED_MODEL_REQUIRED, Constants.MESSAGE_CAPTION);
                return;
            }

            if (SelectedSupplierDto == null)
            {
                MessageBox.Show(Messages.SELECTED_SUPPLIER_REQUIRED, Constants.MESSAGE_CAPTION);
                return;
            }

            var newDto = new StockRoomDto
            {
                ModelId = SelectedModelDto.ModelId,
                SelectedColor = SelectedOrNewColorDto,
                Size = Convert.ToDouble(sizeComboBox.SelectedItem),
                Quantity = (int)quantityNumericUpDown.Value,
                EntryDate = dateInTime.Value,
                SupplierId = SelectedSupplierDto.SupplierId
            };
            ShoesDataClientServices.StockRoomServices.InsertNewProductInStock(newDto);
            ResetView();
            MessageBox.Show(Messages.NEW_PRODUCT_CREATED_SUCESSS, Constants.MESSAGE_CAPTION);
        }

        private void ResetView()
        {
            quantityNumericUpDown.Value = 1;
            dateInTime.Value = DateTime.Now;
            if (SelectedOrNewColorDto.ColorId == null)
            {
                Colors = ShoesDataClientServices.ColorServices.GetAllColors();
                colorComboBox.DataSource = Colors;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var uploadPicture = PictureViewUtils.ReadImageFromFilePath(openFileDialog1.FileName);
                ShoesDataClientServices.ModelServices.UpdateShoesModelPicture(SelectedModelDto.ModelId, uploadPicture);
                SelectedModelDto.Photo = uploadPicture;
                LoadNewPhoto(openFileDialog1.FileName);
            }
        }

        private void LoadNewPhoto(string fileName)
        {
            Image img = new Bitmap(fileName);
            shoesPictureBox.Image = img;
            shoesPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void modelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadShoesModelPicture(SelectedModelDto);
            if (SelectedModelDto.AvailablesColors.Count > 0)
            {
                colorComboBox.DataSource = SelectedModelDto.AvailablesColors;
            }
            else
            {
                colorComboBox.DataSource = this.Colors;
            }
        }
    }
}
