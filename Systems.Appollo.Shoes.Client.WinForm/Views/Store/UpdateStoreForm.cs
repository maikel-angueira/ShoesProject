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

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Store
{
    public partial class UpdateStoreForm : Form
    {
        public UpdateStoreForm()
        {
            InitializeComponent();
            storeDataGridView.AutoGenerateColumns = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateStoreForm_Load(object sender, EventArgs e)
        {
            var sellers = ShoesDataClientServices.SellerServices.GetAllSellers();
            sellerComboBox.DataSource = sellers;
            var stores = ShoesDataClientServices.StoreServices.GetAllStores();
            storeDataGridView.DataSource = stores;
            if (stores.Count == 0)
            {
                DisableButtons();
            }
        }

        private void DisableButtons()
        {
            removeButton.Enabled = false;
            updateButton.Enabled = false;
        }

        private void EnableButtons()
        {
            removeButton.Enabled = true;
            updateButton.Enabled = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedStore == null)
            {
                DisableButtons();
                return;
            }

            sellerComboBox.SelectedValue = SelectedStore.SellerId;
            nameTextBox.Text = SelectedStore.Name;
            addressTextBox.Text = SelectedStore.Address;
            EnableButtons();
        }

        private StoreDto SelectedStore
        {
            get
            {
                if (storeDataGridView.SelectedRows.Count == 0)
                    return null;

                return storeDataGridView.CurrentRow.DataBoundItem as StoreDto;
            }
        }

        private SellerDto SelectedSeller
        {
            get
            {
                return sellerComboBox.SelectedItem as SellerDto;
            }
        }

        private string StoreName
        {
            get
            {
                return nameTextBox.Text;
            }
        }


        private string StoreAddress
        {
            get
            {
                return addressTextBox.Text;
            }
        }

        public ShoesClientServices ShoesDataClientServices { get; set; }

        private void updateButton_Click(object sender, EventArgs e)
        {

            if (SelectedStore == null)
                return;

            if (StoreName.Length == 0)
            {
                return;
            }

            if (SelectedStore.Name != StoreName
                && ShoesDataClientServices.StoreServices.ExistStoreByName(StoreName))
            {
                return;
            }

            var updatedStoreDto = new StoreDto
            {
                StoreId = SelectedStore.StoreId,
                Name = StoreName,
                Address = StoreAddress,
                SellerId = SelectedSeller.SellerId
            };
            ShoesDataClientServices.StoreServices.UpdateStore(updatedStoreDto);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (SelectedStore == null)
                return;

            var dialogResult = MessageBox.Show(String.Format(Messages.DO_YOU_WANT_TO_DELETED, SelectedStore.Name), Constants.MESSAGE_CAPTION, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ShoesDataClientServices.StoreServices.RemoveStore(SelectedStore.StoreId);
            }
        }
    }
}
