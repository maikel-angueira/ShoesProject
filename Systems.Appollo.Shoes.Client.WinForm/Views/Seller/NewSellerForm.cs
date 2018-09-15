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
using Systems.Appollo.Shoes.Services;
using Systems.Appollo.Shoes.Services.Data;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Seller
{
    public partial class NewSellerForm : Form
    {
        private SellerServices sellerDataServices;

        public NewSellerForm()
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
            if (SellerName.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.SELLER_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (SellerDataServices.ExistSellerByName(SellerName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            byte[] imagesArray = null;
            if (sellerPictureBox.Image != null)
                imagesArray = PictureViewUtils.ReadImageFromFilePath(openFileDialog1.FileName);


            SellerDataServices.InsertSeller(SellerName, Address, imagesArray);
            ResetView();
            MessageBox.Show(String.Format(Messages.ELEMENT_INSERT_SUCESS, EntityNames.SELLER_ENTITY_NAME, SellerName), Constants.MESSAGE_CAPTION);
        }

        private String Address
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

        private String SellerName
        {
            get
            {
                return sellerNameTextBox.Text;
            }

            set
            {
                sellerNameTextBox.Text = value;
            }
        }

        private void ResetView()
        {
            this.sellerNameTextBox.Clear();
            this.addressTextBox.Clear();
            openFileDialog1.FileName = null;
            if (sellerPictureBox.Image != null)
            {
                sellerPictureBox.Image.Dispose();
                sellerPictureBox.Image = null;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(openFileDialog1.FileName);
                sellerPictureBox.Image = img;// resizeImage(img);
                sellerPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        public SellerServices SellerDataServices
        {
            get => sellerDataServices;
            set => sellerDataServices = value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
