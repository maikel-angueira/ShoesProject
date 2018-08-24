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
using Systems.Appollo.Shoes.Data.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Color
{
    public partial class NewColorForm : Form
    {
        private ColorServices colorServices;

        public NewColorForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (ColorName.Length == 0)
            {
                MessageBox.Show(String.Format(Messages.ElEMENT_NAME_REQUIRED, EntityNames.COlOR_ENTITY_NAME), Constants.MESSAGE_CAPTION);
                return;
            }

            if (ColorDataServices.ExistColorByName(ColorName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            ColorDataServices.InsertColor(ColorName);
            MessageBox.Show(String.Format(Messages.ELEMENT_INSERT_SUCESS, EntityNames.COlOR_ENTITY_NAME, ColorName), Constants.MESSAGE_CAPTION);
            this.ColorName = String.Empty;
        }

        public ColorServices ColorDataServices
        {
            get
            {
                if (colorServices == null)
                    colorServices = new ColorServices();

                return colorServices;
            }

            set => colorServices = value;
        }

        private String ColorName
        {
            get
            {
                return colorTextBox.Text;
            }

            set
            {
                colorTextBox.Text = value;
            }
        }
    }
}
