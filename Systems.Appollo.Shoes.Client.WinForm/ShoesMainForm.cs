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
using Systems.Appollo.Shoes.Client.WinForm.Views.Seller;
using Systems.Appollo.Shoes.Client.WinForm.DataServices;
using Systems.Appollo.Shoes.Client.WinForm.Views.ShoesModel;
using Systems.Appollo.Shoes.Client.WinForm.Views.Client;
using Systems.Appollo.Shoes.Client.WinForm.Views.Supplier;
using Systems.Appollo.Shoes.Client.WinForm.Views.Store;

namespace Systems.Appollo.Shoes.Client.WinForm
{
    public partial class ShoesMainForm : Form
    {
        private ShoesClientServices dataServices;

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
            newColorForm.ColorDataServices = dataServices.ColorServices;
            newColorForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var newModelForm = new NewModelForm();
            newModelForm.ModelDataServices = dataServices.ModelServices;
            newModelForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var updateColorForm = new UpdateColorForm();
            updateColorForm.ColorDataServices = dataServices.ColorServices;
            updateColorForm.ShowDialog();
        }

        private void ShoesMainForm_Load(object sender, EventArgs e)
        {
            this.dataServices = new ShoesClientServices();
        }

        private void actualizarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var updateModelForm = new UpdateModelForm();
            updateModelForm.ModelDataServices = dataServices.ModelServices;
            updateModelForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var newSellerForm = new NewSellerForm();
            newSellerForm.SellerDataServices = dataServices.SellerServices;
            newSellerForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var updateSellerForm = new UpdateSellerForm();
            updateSellerForm.SellerDataServices = dataServices.SellerServices;
            updateSellerForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var clientForm = new NewClientForm()
            {
                ClientDataServices = dataServices.ClientServices
            };
            clientForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var updateClientForm = new UpdateClientForm()
            {
                ClientDataServices = dataServices.ClientServices
            };
            updateClientForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var supplierForm = new UpdateSupplierForm()
            {
                SupplierDataServices = dataServices.SupplierServices
            };
            supplierForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newSupplierForm = new NewSupplierForm()
            {
                SupplierDataServices = dataServices.SupplierServices
            };
            newSupplierForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var newStoreForm = new NewStoreForm()
            {
                ShoesDataServices = dataServices
            };
            newStoreForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var updateStoreForm = new UpdateStoreForm
            {
                ShoesDataClientServices = dataServices
            };
            updateStoreForm.ShowDialog();
        }

        private void gananciaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
