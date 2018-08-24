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
using Systems.Appollo.Shoes.Client.WinForm.Views.Seller;
using Systems.Appollo.Shoes.Data.DataModels;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Store
{
    public partial class NewStoreForm : Form
    {
        public NewStoreForm()
        {
            InitializeComponent();
        }

        public ShoesClientServices ShoesDataServices { get; internal set; }

        private void NewStoreForm_Load(object sender, EventArgs e)
        {
            sellerComboBox.DisplayMember = "Name";
            LoadSellers();
        }

        private void LoadSellers()
        {
            var sellers = ShoesDataServices.SellerServices.GetAllSellers();
            sellerComboBox.DataSource = sellers;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ResetView();
        }

        private void ResetView()
        {
            nameTextBox.Clear();
            addressTextBox.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StoreName.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.STORE_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (ShoesDataServices.StoreServices.ExistStoreByName(StoreName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            ShoesDataServices.StoreServices.InsertStore(StoreName, StoreAddress, SelectedSeller.SellerId);
            MessageBox.Show(String.Format(Messages.ELEMENT_INSERT_SUCESS, EntityNames.STORE_ENTITY_NAME, StoreName), Constants.MESSAGE_CAPTION);
            ResetView();
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

            set
            {
                nameTextBox.Text = value;
            }
        }

        private string StoreAddress
        {
            get
            {
                return addressTextBox.Text;
            }

            set
            {
                addressTextBox.Text = value;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var newSellerform = new NewSellerForm
            {
                SellerDataServices = ShoesDataServices.SellerServices
            };
            DialogResult dialogResult = newSellerform.ShowDialog();
            if (dialogResult == DialogResult.Cancel)
            {
                LoadSellers();
            }
        }
    }
}
