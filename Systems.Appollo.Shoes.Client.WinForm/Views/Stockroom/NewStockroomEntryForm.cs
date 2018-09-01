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
    public partial class NewStockroomEntryForm : Form
    {
        public ShoesClientServices ShoesDataClientServices { get; set; }

        public NewStockroomEntryForm()
        {
            InitializeComponent();
            costNumericUpDown.Maximum = Decimal.MaxValue;
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
            this.Colors = ShoesDataClientServices.ColorServices.GetAllColors();
            modelComboBox.DataSource = shoesModels;
            colorComboBox.DataSource = Colors;
            addButton.Enabled = shoesModels.Count > 0;
            sizeComboBox.SelectedIndex = 0;
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

        private ColorDto SelectedOrNewColorDto
        {
            get
            {
                var colorName = colorComboBox.Text;
                if (colorName == null) return null;
                if (colorName.Length == 0) return null;
                var selectedColorDto = this.Colors.Where(dto => dto.Name.Equals(colorName.Trim(), StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (selectedColorDto == null)
                {
                    selectedColorDto = new ColorDto { Name = colorName };
                }

                return selectedColorDto;
            }
        }

        private ModelDto SelectedModelDto
        {
            get
            {
                if (modelComboBox.SelectedItem == null) return null;
                return modelComboBox.SelectedItem as ModelDto;
            }
        }

        private List<ColorDto> Colors { get; set; }

        private void modelComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ReloadShoesModelPicture(SelectedModelDto);
        }

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

            var newDto = new StockRoomDto
            {
                ModelId = SelectedModelDto.ModelId,
                SelectedColor = SelectedOrNewColorDto,
                Description = descriptionTextBox.Text,
                Size = Convert.ToDouble(sizeComboBox.SelectedItem),
                Quantity = (int)quantityNumericUpDown.Value,
                UnitCost = (double)costNumericUpDown.Value,
                InputDate = dateInTime.Value
            };
            ShoesDataClientServices.StockRoomServices.InsertNewProduct(newDto);
            ResetView();
            MessageBox.Show(Messages.NEW_PRODUCT_FROM_STORE_CREATED_SUCESSS, Constants.MESSAGE_CAPTION);
        }

        private void ResetView()
        {
            quantityNumericUpDown.Value = 1;
            costNumericUpDown.Value = 0;
            descriptionTextBox.Text = "";
            dateInTime.Value = DateTime.Now;
            if (SelectedOrNewColorDto.ColorId == null)
            {
                Colors = ShoesDataClientServices.ColorServices.GetAllColors();
                colorComboBox.DataSource = Colors;
            }
        }
    }
}
