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
using Systems.Appollo.Shoes.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Seller
{
    public partial class UpdateModelForm : Form
    {
        private const string AVAILABLE_FOR_ALL_COLORS = "Disponible todos colores";

        public UpdateModelForm()
        {
            InitializeComponent();
            modelDataGrid.AutoGenerateColumns = false;
            UploadNewPhoto = false;
            costNumericUpDown.Maximum = decimal.MaxValue;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (SelectedModel == null)
                return;

            if (ModelName.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.MODEL_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (SelectedModel.Name != ModelName
                    && ShoesClientDataServices.ModelServices.ExistModelByName(ModelName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            byte[] newUploadPhoto = SelectedModel.Photo;
            if (UploadNewPhoto)
            {
                newUploadPhoto = PictureViewUtils.ReadImageFromFilePath(openFileDialog1.FileName);
            }

            var updatedModelDto = new ModelDto
            {
                ModelId = SelectedModel.ModelId,
                Name = ModelName,
                Description = ModelDescription,
                Photo = newUploadPhoto,
                ShoesTypeId = (int)shoesTypeComboBox.SelectedValue,
                Cost = (double)costNumericUpDown.Value,
                Sex = sexComboBox.SelectedItem as string,
                IsForKids = kidsCheckBox.Checked
            };

            ShoesClientDataServices.ModelServices.UpdateModel(updatedModelDto);
            UpdateView(updatedModelDto);
            MessageBox.Show(string.Format(Messages.ELEMENT_UPDATED_SUCCESS, EntityNames.MODEL_ENTITY_NAME), Constants.MESSAGE_CAPTION);
        }

        private string ModelName
        {
            get
            {
                return modelNameTextBox.Text;
            }
            set
            {
                modelNameTextBox.Text = value;
            }
        }

        private void UpdateView(ModelDto updatedDto)
        {
            UploadNewPhoto = false;
            SelectedModel.Name = updatedDto.Name;
            SelectedModel.Description = updatedDto.Description;
            SelectedModel.Photo = updatedDto.Photo;
            SelectedModel.Cost = updatedDto.Cost;
            SelectedModel.ShoesTypeId = updatedDto.ShoesTypeId;
            modelDataGrid.Refresh();
        }

        public ShoesClientServices ShoesClientDataServices
        {
            get; set;
        }

        private void UpdateModelForm_Load(object sender, EventArgs e)
        {
            List<ModelDto> models = ShoesClientDataServices.ModelServices.GetAllModels();
            modelDataGrid.DataSource = models;
            var shoesTypes = ShoesClientDataServices.ShoesTypeDataServices.GetAllShoesType();
            shoesTypeComboBox.DataSource = shoesTypes;
        }

        private void modelDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            UploadNewPhoto = false;
            if (SelectedModel == null)
            {
                DisableButtons();
                return;
            }
            modelNameTextBox.Text = SelectedModel.Name;
            modelDescriptionTextBox.Text = SelectedModel.Description;
            PictureViewUtils.LoadImageToControl(SelectedModel.Photo, modelPictureBox);
            costNumericUpDown.Value = (decimal)SelectedModel.Cost;
            sexComboBox.SelectedItem = SelectedModel.Sex;
            kidsCheckBox.Checked = SelectedModel.IsForKids;
            bool allowModify = !ShoesClientDataServices.StockRoomServices.ExistAnyStockEntryByModelId(SelectedModel.ModelId);
            costNumericUpDown.Enabled = allowModify;
            removeButton.Enabled = allowModify;
            updateButton.Enabled = true;
            shoesTypeComboBox.SelectedValue = SelectedModel.ShoesTypeId;
            colorCheckedListBox.Items.Clear();
            if (SelectedModel.AvailablesColors.Count > 0)
                SelectedModel.AvailablesColors.ForEach(dto => colorCheckedListBox.Items.Add(dto.Name, true));
            else
                colorCheckedListBox.Items.Add(AVAILABLE_FOR_ALL_COLORS, true);
        }

        private void DisableButtons()
        {
            updateButton.Enabled = false;
            removeButton.Enabled = false;
        }

        private ModelDto SelectedModel
        {
            get
            {
                if (modelDataGrid.SelectedRows.Count == 0)
                    return null;
                return modelDataGrid.CurrentRow.DataBoundItem as ModelDto;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(openFileDialog1.FileName);
                modelPictureBox.Image = img;// resizeImage(img);
                modelPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                UploadNewPhoto = true;
            }
        }

        private bool UploadNewPhoto { get; set; }
        public string ModelDescription
        {
            get
            {
                return modelDescriptionTextBox.Text;
            }

            set
            {
                modelDescriptionTextBox.Text = value;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (SelectedModel == null)
                return;

            var dialogResult = MessageBox.Show(
                String.Format(Messages.DO_YOU_WANT_TO_DELETED, SelectedModel.Name),
                Constants.MESSAGE_CAPTION,
                MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
                return;

            ShoesClientDataServices.ModelServices.RemoveModel(SelectedModel.ModelId);
            UploadNewPhoto = false;
            var models = ShoesClientDataServices.ModelServices.GetAllModels();
            modelDataGrid.DataSource = models;
            modelDataGrid.Refresh();
            if (models.Count == 0)
            {
                ResetView();
            }
        }

        private void ResetView()
        {
            modelPictureBox.Image = null;
            modelNameTextBox.Clear();
            modelDescriptionTextBox.Clear();
            DisableButtons();
        }
    }
}
