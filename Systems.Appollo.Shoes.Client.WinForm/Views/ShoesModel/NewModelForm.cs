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
            if (ModelName.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.MODEL_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (ModelDataServices.ExistModelByName(ModelName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            byte[] photoUpload = null;
            if (modelPictureBox.Image != null)
                photoUpload = PictureViewUtils.ReadImageFromFilePath(modelOpenFileDialog.FileName);

            ModelDataServices.InsertModel(ModelName, ModelDescription, photoUpload);
            ResetView();
            MessageBox.Show(String.Format(Messages.ELEMENT_INSERT_SUCESS, EntityNames.MODEL_ENTITY_NAME, ModelName), Constants.MESSAGE_CAPTION);
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

        private string ModelDescription
        {
            get
            {
                return descriptionTextBox.Text;
            }

            set
            {
                descriptionTextBox.Text = value;
            }
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

        public ModelServices ModelDataServices
        {
            get
            {
                if (modelDataServices == null)
                    modelDataServices = new ModelServices();
                return modelDataServices;
            }

            set => modelDataServices = value;
        }
    }
}
