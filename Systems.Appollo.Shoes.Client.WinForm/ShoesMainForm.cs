﻿using System;
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
using Systems.Appollo.Shoes.Client.WinForm.Views.Stockroom;
using Systems.Appollo.Shoes.Client.WinForm.Views.Sales;
using Systems.Appollo.Shoes.Client.WinForm.Views.Login;
using Systems.Appollo.Shoes.Client.WinForm.ReportViews;
using Systems.Appollo.Shoes.Client.WinForm.Utils;

namespace Systems.Appollo.Shoes.Client.WinForm
{
    public partial class ShoesMainForm : Form
    {
        private ShoesClientServices _shoesDataServices;

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
            bool existStockProducts = _shoesDataServices.StockRoomServices.ExistProductOnTheStock();
            if (!existStockProducts)
            {
                MessageBox.Show(Messages.NO_EXISTING_PRODUCTS_ON_THE_STOCK, Constants.MESSAGE_CAPTION);
                return;
            }
            var stockRoomExistingForm = new StockRoomExistingForm()
            {
                ShoesClientDataServices = _shoesDataServices
            };
            stockRoomExistingForm.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutUsBox = new AboutUsBox();
            aboutUsBox.ShowDialog();
        }

        private void nuevoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var newColorForm = new NewColorForm();
            newColorForm.ColorDataServices = _shoesDataServices.ColorServices;
            newColorForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var newModelForm = new NewModelForm();
            newModelForm.ShoesDbServices = _shoesDataServices;
            newModelForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var updateColorForm = new UpdateColorForm();
            updateColorForm.ColorDataServices = _shoesDataServices.ColorServices;
            updateColorForm.ShowDialog();
        }

        private void ShoesMainForm_Load(object sender, EventArgs e)
        {
            this._shoesDataServices = new ShoesClientServices();
            var loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var updateModelForm = new UpdateModelForm()
            {
                ShoesClientDataServices = _shoesDataServices
            };
            updateModelForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var newSellerForm = new NewSellerForm();
            newSellerForm.SellerDataServices = _shoesDataServices.SellerServices;
            newSellerForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            var updateSellerForm = new UpdateSellerForm();
            updateSellerForm.SellerDataServices = _shoesDataServices.SellerServices;
            updateSellerForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var clientForm = new NewClientForm()
            {
                ClientDataServices = _shoesDataServices.ClientServices
            };
            clientForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var updateClientForm = new UpdateClientForm()
            {
                ClientDataServices = _shoesDataServices.ClientServices
            };
            updateClientForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var supplierForm = new UpdateSupplierForm()
            {
                SupplierDataServices = _shoesDataServices.SupplierServices
            };
            supplierForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newSupplierForm = new NewSupplierForm()
            {
                SupplierDataServices = _shoesDataServices.SupplierServices
            };
            newSupplierForm.ShowDialog();
        }

        private void nuevoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var newStoreForm = new NewStoreForm()
            {
                ShoesDataServices = _shoesDataServices
            };
            newStoreForm.ShowDialog();
        }

        private void actualizarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var updateStoreForm = new UpdateStoreForm
            {
                ShoesDataClientServices = _shoesDataServices
            };
            updateStoreForm.ShowDialog();
        }

        private void storeStockRoomExistingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_shoesDataServices.StoreStockRoomServices.ExistProductOnTheStock())
            {
                MessageBox.Show(Messages.NO_EXISTING_PRODUCTS_ON_THE_STOCK, Constants.MESSAGE_CAPTION);
                return;
            }

            if (!_shoesDataServices.StoreServices.ExistAnyStore())
            {
                MessageBox.Show(Messages.NO_STORE_EXISTING_IN_DB, Constants.MESSAGE_CAPTION);
                return;
            }

            var storeStockRoomExistingForm = new StoreStockRoomExistingForm()
            {
                ShoesClientDataServices = _shoesDataServices
            };
            storeStockRoomExistingForm.ShowDialog();
        }

        private void tallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newStockroomForm = new NewStockRoomEntryForm()
            {
                ShoesDataClientServices = _shoesDataServices
            };
            newStockroomForm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var newStockroomForm = new NewStockRoomEntryForm()
            {
                ShoesDataClientServices = _shoesDataServices
            };
            newStockroomForm.ShowDialog();
        }

        private void compraAProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newStockRoomSupplierFrom = new NewStockRoomSupplierEntryForm
            {
                ShoesDataClientServices = _shoesDataServices
            };

            newStockRoomSupplierFrom.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var newStockRoomSupplierFrom = new NewStockRoomSupplierEntryForm
            {
                ShoesDataClientServices = _shoesDataServices
            };

            newStockRoomSupplierFrom.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var newStoreSupplierStockForm = new NewStoreStockSupplyEntryForm
            {
                ShoesDataClientServices = _shoesDataServices
            };
            newStoreSupplierStockForm.ShowDialog();
        }

        private void ventaAClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newSaleStockRoomForm = new NewSaleFromStockRoomForm()
            {
                ShoesDataServices = _shoesDataServices
            };
            newSaleStockRoomForm.ShowDialog();
        }

        private void surtirTiendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newSaleStockRoomForm = new NewSaleFromStoreStockRoomForm()
            {
                ShoesDataServices = _shoesDataServices
            };
            newSaleStockRoomForm.ShowDialog();
        }
    }
}
