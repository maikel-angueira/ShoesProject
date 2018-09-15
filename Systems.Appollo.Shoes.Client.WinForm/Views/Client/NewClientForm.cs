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

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Client
{
    public partial class NewClientForm : Form
    {
        private ClientServices clientServices;

        public NewClientForm()
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
            if (ClientName.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.CLIENT_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (ClientDataServices.ExistClientByName(ClientName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            byte[] photoUploaded = null;
            if (clientPictureBox.Image != null)
                photoUploaded = PictureViewUtils.ReadImageFromFilePath(openFileDialog1.FileName);

            ClientDataServices.InsertClient(ClientName, Address, photoUploaded);
            ResetView();
            MessageBox.Show(String.Format(Messages.ELEMENT_INSERT_SUCESS, EntityNames.CLIENT_ENTITY_NAME, ClientName), Constants.MESSAGE_CAPTION);
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

        private String ClientName
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

        public ClientServices ClientDataServices
        {
            get => clientServices;
            set => clientServices = value;
        }

        private void ResetView()
        {
            this.clientNameTextBox.Clear();
            this.addressTextBox.Clear();
            openFileDialog1.FileName = null;
            if (clientPictureBox.Image != null)
            {
                clientPictureBox.Image.Dispose();
                clientPictureBox.Image = null;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(openFileDialog1.FileName);
                clientPictureBox.Image = img;// resizeImage(img);
                clientPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
