using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Systems.Appollo.Shoes.Client.WinForm.Views;

namespace Systems.Appollo.Shoes.Client.WinForm
{
    public partial class ShoesMainForm : Form
    {
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

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutUsBox = new AboutUsBox();
            aboutUsBox.ShowDialog();
        }
    }
}
