using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Systems.Appollo.Shoes.Client.WinForm.Views.Color;
using Systems.Appollo.Shoes.Client.WinForm.Views;
using Systems.Appollo.Shoes.Client.WinForm.Views.ShoesModel;
using Systems.Appollo.Shoes.Client.WinForm.DataServices;

namespace Systems.Appollo.Shoes.Client.WinForm
{
    public partial class ShoesMainForm : Form
    {
        private Services dataServices;

        public ShoesMainForm()
        {
            InitializeComponent();
        }

        private void almacenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void existenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutUsBox = new AboutUsBox();
            aboutUsBox.ShowDialog();
        }

        private void nuevoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var newColorForm = new NewColorForm();
            newColorForm.SetColorDataService(dataServices.ColorServices);
            newColorForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var newModelForm = new NewModelForm();
            newModelForm.SetModelDataServices(dataServices.ModelServices);
            newModelForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var updateColorForm = new UpdateColorForm();
            updateColorForm.SetColorDataService(dataServices.ColorServices);
            updateColorForm.ShowDialog();            
        }

        private void ShoesMainForm_Load(object sender, EventArgs e)
        {
            this.dataServices = new Services();
        }
    }
}
