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

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Client
{
    public partial class UpdateClientForm : Form
    {
        private ClientServices clientDataServices;

        public UpdateClientForm()
        {
            InitializeComponent();
            clientDataGrid.AutoGenerateColumns = false;
            UploadNewPhoto = false;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (SelectedClient == null)
                return;

            if (ClientName.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.CLIENT_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (SelectedClient.Name != ClientName
                    && ClientDataServices.ExistClientByName(ClientName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            byte[] newUploadPhoto = SelectedClient.Photo;
            if (UploadNewPhoto)
            {
                newUploadPhoto = PictureViewUtils.ReadImageFromFilePath(openFileDialog1.FileName);
            }

            var clientDto = new ClientDto
            {
                ClientId = SelectedClient.ClientId,
                Name = ClientName,
                Address = SellerAddress,
                Photo = newUploadPhoto
            };

            ClientDataServices.UpdateClient(clientDto);
            UpdateView(clientDto);
            MessageBox.Show(string.Format(Messages.ELEMENT_UPDATED_SUCCESS, EntityNames.SELLER_ENTITY_NAME), Constants.MESSAGE_CAPTION);
        }

        private string ClientName
        {
            get
            {
                return clientNameTextBox.Text;
            }
            set
            {
                clientNameTextBox.Text = value;
            }
        }

        private void UpdateView(ClientDto updatedDto)
        {
            UploadNewPhoto = false;
            SelectedClient.Name = updatedDto.Name;
            SelectedClient.Address = updatedDto.Address;
            SelectedClient.Photo = updatedDto.Photo;
            clientDataGrid.Refresh();
        }

        public ClientServices ClientDataServices
        {
            get => clientDataServices;
            set => clientDataServices = value;
        }

        private void UpdateModelForm_Load(object sender, EventArgs e)
        {
            List<ClientDto> models = ClientDataServices.GetAllClients();
            clientDataGrid.DataSource = models;
        }

        private void modelDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            UploadNewPhoto = false;
            if (SelectedClient == null)
            {
                DisableButtons();
                return;

            }
            clientNameTextBox.Text = SelectedClient.Name;
            clientAddressTextBox.Text = SelectedClient.Address;
            PictureViewUtils.LoadImageToControl(SelectedClient.Photo, clientPictureBox);
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

        private ClientDto SelectedClient
        {
            get
            {
                if (clientDataGrid.SelectedRows.Count == 0)
                    return null;
                return clientDataGrid.CurrentRow.DataBoundItem as ClientDto;
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
                clientPictureBox.Image = img;// resizeImage(img);
                clientPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                UploadNewPhoto = true;
            }
        }

        private bool UploadNewPhoto { get; set; }
        public string SellerAddress
        {
            get
            {
                return clientAddressTextBox.Text;
            }

            set
            {
                clientAddressTextBox.Text = value;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (SelectedClient == null)
                return;

            var dialogResult = MessageBox.Show(
                String.Format(Messages.DO_YOU_WANT_TO_DELETED, SelectedClient.Name),
                Constants.MESSAGE_CAPTION,
                MessageBoxButtons.YesNo);

            if (dialogResult != DialogResult.Yes)
                return;

            ClientDataServices.RemoveClient(SelectedClient.ClientId);
            UploadNewPhoto = false;
            var clients = ClientDataServices.GetAllClients();
            clientDataGrid.DataSource = clients;
            clientDataGrid.Refresh();
            if (clients.Count == 0)
            {
                ResetView();
            }
        }

        private void ResetView()
        {
            clientPictureBox.Image = null;
            clientNameTextBox.Clear();
            clientAddressTextBox.Clear();
            DisableButtons();
        }
    }
}
