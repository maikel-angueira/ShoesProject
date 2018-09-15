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
using Systems.Appollo.Shoes.Services;
using Systems.Appollo.Shoes.Services.Data;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Supplier
{
    public partial class UpdateSupplierForm : Form
    {
        private SupplierServices supplierDataServices;

        public UpdateSupplierForm()
        {
            InitializeComponent();
            supplierDataGrid.AutoGenerateColumns = false;
            UploadNewPhoto = false;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (SelectedSupplier == null)
                return;

            if (SupplierName.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.SUPPLIER_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (SelectedSupplier.Name != SupplierName
                    && SupplierDataServices.ExistSupplierByName(SupplierName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            byte[] newUploadPhoto = SelectedSupplier.Photo;
            if (UploadNewPhoto)
            {
                newUploadPhoto = PictureViewUtils.ReadImageFromFilePath(openFileDialog1.FileName);
            }

            var sellerDto = new SupplierDto
            {
                SupplierId = SelectedSupplier.SupplierId,
                Name = SupplierName,
                Address = SupplierAddress,
                Photo = newUploadPhoto
            };

            SupplierDataServices.UpdateSupplier(sellerDto);
            UpdateView(sellerDto);
            MessageBox.Show(string.Format(Messages.ELEMENT_UPDATED_SUCCESS, EntityNames.SUPPLIER_ENTITY_NAME), Constants.MESSAGE_CAPTION);
        }

        private string SupplierName
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

        private void UpdateView(SupplierDto updatedDto)
        {
            UploadNewPhoto = false;
            SelectedSupplier.Name = updatedDto.Name;
            SelectedSupplier.Address = updatedDto.Address;
            SelectedSupplier.Photo = updatedDto.Photo;
            supplierDataGrid.Refresh();
        }

        public SupplierServices SupplierDataServices
        {
            get => supplierDataServices;
            set => supplierDataServices = value;
        }

        private void UpdateModelForm_Load(object sender, EventArgs e)
        {
            List<SupplierDto> models = SupplierDataServices.GetAllSuppliers();
            supplierDataGrid.DataSource = models;
        }

        private void modelDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            UploadNewPhoto = false;
            if (SelectedSupplier == null)
            {
                DisableButtons();
                return;

            }
            sellerNameTextBox.Text = SelectedSupplier.Name;
            sellerAddressTextBox.Text = SelectedSupplier.Address;
            PictureViewUtils.LoadImageToControl(SelectedSupplier.Photo, sellerPictureBox);
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

        private SupplierDto SelectedSupplier
        {
            get
            {
                if (supplierDataGrid.SelectedRows.Count == 0)
                    return null;
                return supplierDataGrid.CurrentRow.DataBoundItem as SupplierDto;
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
        public string SupplierAddress
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
            if (SelectedSupplier == null)
                return;

            var dialogResult = MessageBox.Show(
                String.Format(Messages.DO_YOU_WANT_TO_DELETED, SelectedSupplier.Name),
                Constants.MESSAGE_CAPTION,
                MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
                return;

            SupplierDataServices.RemoveSupplier(SelectedSupplier.SupplierId);
            UploadNewPhoto = false;
            var suppliers = SupplierDataServices.GetAllSuppliers();
            supplierDataGrid.DataSource = suppliers;
            supplierDataGrid.Refresh();
            if (suppliers.Count == 0)
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
