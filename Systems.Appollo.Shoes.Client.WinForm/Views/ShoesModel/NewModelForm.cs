using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.ShoesModel
{
    public partial class NewModelForm : Form
    {
        public NewModelForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            this.modelNameTextBox.Clear();
            this.descriptionTextBox.Clear();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {

        }
    }
}
