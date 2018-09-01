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

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Stockroom
{
    public partial class NewStockroomEntryForm : Form
    {
        public ShoesClientServices ShoesDataClientServices { get; set; }

        public NewStockroomEntryForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewStockroomEntryForm_Load(object sender, EventArgs e)
        {
            sizeComboBox.SelectedIndex = 0;

        }
    }
}
