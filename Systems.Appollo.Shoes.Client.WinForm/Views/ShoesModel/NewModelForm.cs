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
using Systems.Appollo.Shoes.Data.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.ShoesModel
{
    public partial class NewModelForm : Form
    {
        private ModelServices modelDataServices;

        public NewModelForm()
        {
            InitializeComponent();
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
            if (modelNameTextBox.Text.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.MODEL_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            byte[] imagesArray = null;
            if (modelPictureBox.Image != null)
                imagesArray = PictureViewUtils.ReadImageFromFilePath(modelOpenFileDialog.FileName);

            var description = descriptionTextBox.Text;
            var newModelName = modelNameTextBox.Text;
            ModelDataServices.InsertModel(newModelName, description, imagesArray);
            ResetView();
            MessageBox.Show(String.Format(Messages.ELEMENT_INSERT_SUCESS, EntityNames.MODEL_ENTITY_NAME, newModelName), Constants.MESSAGE_CAPTION);
        }

        private void ResetView()
        {
            this.modelNameTextBox.Clear();
            this.descriptionTextBox.Clear();
            modelOpenFileDialog.FileName = null;
            if (modelPictureBox.Image != null)
            {
                modelPictureBox.Image.Dispose();
                modelPictureBox.Image = null;
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (modelOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(modelOpenFileDialog.FileName);
                modelPictureBox.Image = img;// resizeImage(img);
                modelPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
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
    }
}
