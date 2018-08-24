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

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Seller
{
    public partial class UpdateSellerForm : Form
    {
        private SellerServices sellerDataServices;

        public UpdateSellerForm()
        {
            InitializeComponent();
            sellerDataGrid.AutoGenerateColumns = false;
            UploadNewPhoto = false;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (SelectedSeller == null)
                return;

            if (SellerName.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.SELLER_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (SelectedSeller.Name != SellerName
                    && SellerDataServices.ExistSellerByName(SellerName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            byte[] newUploadPhoto = SelectedSeller.Photo;
            if (UploadNewPhoto)
            {
                newUploadPhoto = PictureViewUtils.ReadImageFromFilePath(openFileDialog1.FileName);
            }

            var sellerDto = new SellerDto
            {
                SellerId = SelectedSeller.SellerId,
                Name = SellerName,
                Address = SellerAddress,
                Photo = newUploadPhoto
            };

            SellerDataServices.UpdateSeller(sellerDto);
            UpdateView(sellerDto);
            MessageBox.Show(string.Format(Messages.ELEMENT_UPDATED_SUCCESS, EntityNames.SELLER_ENTITY_NAME), Constants.MESSAGE_CAPTION);
        }

        private string SellerName
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

        private void UpdateView(SellerDto updatedDto)
        {
            UploadNewPhoto = false;
            SelectedSeller.Name = updatedDto.Name;
            SelectedSeller.Address = updatedDto.Address;
            SelectedSeller.Photo = updatedDto.Photo;
            sellerDataGrid.Refresh();
        }

        public SellerServices SellerDataServices
        {
            get
            {
                if (sellerDataServices == null)
                    sellerDataServices = new SellerServices();
                return sellerDataServices;
            }

            set => sellerDataServices = value;
        }

        private void UpdateModelForm_Load(object sender, EventArgs e)
        {
            List<SellerDto> models = SellerDataServices.GetAllSellers();
            sellerDataGrid.DataSource = models;
        }

        private void modelDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            UploadNewPhoto = false;
            if (SelectedSeller == null)
            {
                DisableButtons();
                return;

            }
            sellerNameTextBox.Text = SelectedSeller.Name;
            sellerAddressTextBox.Text = SelectedSeller.Address;
            PictureViewUtils.LoadImageToControl(SelectedSeller.Photo, sellerPictureBox);
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

        private SellerDto SelectedSeller
        {
            get
            {
                if (sellerDataGrid.SelectedRows.Count == 0)
                    return null;
                return sellerDataGrid.CurrentRow.DataBoundItem as SellerDto;
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
                sellerPictureBox.Image = img;// resizeImage(img);
                sellerPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                UploadNewPhoto = true;
            }
        }

        private bool UploadNewPhoto { get; set; }
        public string SellerAddress
        {
            get
            {
                return sellerAddressTextBox.Text;
            }

            set
            {
                sellerAddressTextBox.Text = value;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (SelectedSeller == null)
                return;

            var dialogResult = MessageBox.Show(
                String.Format(Messages.DO_YOU_WANT_TO_DELETED, SelectedSeller.Name),
                Constants.MESSAGE_CAPTION,
                MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
                return;

            SellerDataServices.RemoveSeller(SelectedSeller.SellerId);
            UploadNewPhoto = false;
            var sellers = SellerDataServices.GetAllSellers();
            sellerDataGrid.DataSource = sellers;
            sellerDataGrid.Refresh();
            if (sellers.Count == 0)
            {
                ResetView();
            }
        }

        private void ResetView()
        {
            sellerPictureBox.Image = null;
            sellerNameTextBox.Clear();
            sellerAddressTextBox.Clear();
            DisableButtons();
        }
    }
}
