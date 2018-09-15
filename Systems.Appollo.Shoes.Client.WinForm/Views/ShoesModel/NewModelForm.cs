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
using Systems.Appollo.Shoes.Client.WinForm.Views.Color;
using Systems.Appollo.Shoes.Data.DataModels;
using Systems.Appollo.Shoes.Data.Dtos;
using Systems.Appollo.Shoes.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.ShoesModel
{
    public partial class NewModelForm : Form
    {
        private List<ColorDto> _availableColors;

        public NewModelForm()
        {
            InitializeComponent();
            costNumericUpDown.Maximum = decimal.MaxValue;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetView();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if (ModelName.Length == 0)
            {
                MessageBox.Show(string.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.MODEL_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (ShoesDbServices.ModelServices.ExistModelByName(ModelName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            byte[] photoUpload = null;
            if (modelPictureBox.Image != null)
                photoUpload = PictureViewUtils.ReadImageFromFilePath(modelOpenFileDialog.FileName);

            var newModelDto = new ModelDto
            {
                Name = ModelName,
                Description = ModelDescription,
                Photo = photoUpload,
                Cost = (double)costNumericUpDown.Value,
                ShoesTypeId = SelectedShoesType.Id,
                AvailablesColors = GetColorDtoFromSelectedNames(),
                Sex = (string)sexComboBox.SelectedItem,
                IsForKids = kidsCheckBox.Checked
            };         

            ShoesDbServices.ModelServices.InsertModel(newModelDto);
            ResetView();
            MessageBox.Show(string.Format(Messages.ELEMENT_INSERT_SUCESS, EntityNames.MODEL_ENTITY_NAME, ModelName), Constants.MESSAGE_CAPTION);
        }

        private List<ColorDto> GetColorDtoFromSelectedNames()
        {
            if (CheckedColorNames.Count == 0) return new List<ColorDto>();
            return CheckedColorNames.Join(
                        _availableColors,
                        color => color,
                        dto => dto.Name,
                        (color, dto) => dto)
                   .ToList();
        }

        private ShoesTypeDto SelectedShoesType
        {
            get => shoesTypeComboBox.SelectedItem as ShoesTypeDto;
        }

        private string ModelName
        {
            get => modelNameTextBox.Text;

            set => modelNameTextBox.Text = value;
        }

        private string ModelDescription
        {
            get => descriptionTextBox.Text;

            set => descriptionTextBox.Text = value;
        }

        private void ResetView()
        {
            this.modelNameTextBox.Clear();
            this.descriptionTextBox.Clear();
            modelOpenFileDialog.FileName = null;
            costNumericUpDown.Value = 0;
            allColorRadioButton.Checked = true;
            UncheckedAllColors();
            if (modelPictureBox.Image == null) return;
            modelPictureBox.Image.Dispose();
            modelPictureBox.Image = null;

        }

        private void UncheckedAllColors()
        {
            foreach(int i in colorCheckedListBox.CheckedIndices)
                colorCheckedListBox.SetItemCheckState(i, CheckState.Unchecked);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (modelOpenFileDialog.ShowDialog() != DialogResult.OK) return;
            Image img = new Bitmap(modelOpenFileDialog.FileName);
            modelPictureBox.Image = img;// resizeImage(img);
            modelPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public ShoesClientServices ShoesDbServices { get; set; }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void selectColorRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            colorPanelContainer.Enabled = selectColorRadioButton.Checked;
        }

        private List<string> CheckedColorNames => colorCheckedListBox.CheckedItems.Cast<string>().ToList();
            
        private void NewModelForm_Load(object sender, EventArgs e)
        {
            this._availableColors = ShoesDbServices.ColorServices.GetAllColors();
            this._availableColors.ForEach(c => colorCheckedListBox.Items.Add(c.Name));
            var shoesTypes = ShoesDbServices.ShoesTypeDataServices.GetAllShoesType();
            shoesTypeComboBox.DataSource = shoesTypes;
            insertButton.Enabled = shoesTypes.Count > 0;
            sexComboBox.SelectedIndex = 0;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var newColorForm = new NewColorForm()
            {
                ColorDataServices = ShoesDbServices.ColorServices
            };
            if (newColorForm.ShowDialog() == DialogResult.Cancel)
            {
                var allColors = ShoesDbServices.ColorServices.GetAllColors();
                var allKeys = allColors.Select(dto => dto.ColorId);
                var keys = _availableColors.Select(dto => dto.ColorId);
                var newKeys = allKeys.Except(keys);
                var newColorNames = newKeys.Join(allColors, id => id, dto => dto.ColorId, (colorId, dto) => dto.Name).ToList();
                _availableColors = allColors;
                newColorNames.ForEach(name => colorCheckedListBox.Items.Add(name));
            }
        }
    }
}
