﻿using System;
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
using Systems.Appollo.Shoes.Data.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.ShoesModel
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

            if (modelNameTextBox.Text.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.MODEL_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (ModelDataServices.ExistModelByName(SelectedModel.ModelId, modelNameTextBox.Text))
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
                Name = modelNameTextBox.Text,
                Description = modelDescriptionTextBox.Text,
                Photo = newUploadPhoto
            };

            ModelDataServices.UpdateModel(updatedModelDto);
            UpdateView(updatedModelDto);
            MessageBox.Show(string.Format(Messages.ELEMENT_UPDATED_SUCCESS, EntityNames.MODEL_ENTITY_NAME), Constants.MESSAGE_CAPTION);
        }

        private void UpdateView(ModelDto updatedDto)
        {
            UploadNewPhoto = false;
            SelectedModel.Name = updatedDto.Name;
            SelectedModel.Description = updatedDto.Description;
            SelectedModel.Photo = updatedDto.Photo;
            modelDataGrid.Refresh();
        }

        private ModelServices ModelDataServices
        {
            get
            {
                if (modelDataServices == null)
                    modelDataServices = new ModelServices();
                return modelDataServices;
            }
        }

        public void SetModelDataServices(ModelServices modelServices)
        {
            this.modelDataServices = modelServices;
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
                DisableButtons();
            }
        }
    }
}