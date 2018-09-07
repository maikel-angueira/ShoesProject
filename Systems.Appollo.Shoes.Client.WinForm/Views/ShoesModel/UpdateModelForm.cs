using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Systems.Appollo.Shoes.Client.WinForm.Utils;
using Systems.Appollo.Shoes.Data.DataModels;
using Systems.Appollo.Shoes.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Seller
{
    public partial class UpdateModelForm : Form
    {
        private ModelServices modelDataServices;

        public UpdateModelForm()
        {
            InitializeComponent();
            modelDataGrid.AutoGenerateColumns = false;
            UploadNewPhoto = false;
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
                    && ModelDataServices.ExistModelByName(ModelName))
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
                Photo = newUploadPhoto
            };

            ModelDataServices.UpdateModel(updatedModelDto);
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
            modelDataGrid.Refresh();
        }

        public ModelServices ModelDataServices
        {
            get => modelDataServices;
            set => modelDataServices = value;
        }

        private void UpdateModelForm_Load(object sender, EventArgs e)
        {
            List<ModelDto> models = ModelDataServices.GetAllModels();
            modelDataGrid.DataSource = models;
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
            EnableButtons();
        }

        private void EnableButtons()
        {
            updateButton.Enabled = true;
            removeButton.Enabled = true;
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

            ModelDataServices.RemoveModel(SelectedModel.ModelId);
            UploadNewPhoto = false;
            var models = ModelDataServices.GetAllModels();
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
