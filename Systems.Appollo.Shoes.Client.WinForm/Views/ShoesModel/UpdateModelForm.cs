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
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            if (SelectedModel == null)
                return;
            modelNameTextBox.Text = SelectedModel.Name;
            modelDescriptionTextBox.Text = SelectedModel.Description;
            PictureViewUtils.LoadImageToControl(SelectedModel.Photo, modelPictureBox);
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
    }
}
