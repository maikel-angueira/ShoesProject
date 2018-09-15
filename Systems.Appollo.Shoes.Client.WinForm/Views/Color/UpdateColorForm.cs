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

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Color
{
    public partial class UpdateColorForm : Form
    {
        private ColorServices colorDataServices;

        public UpdateColorForm()
        {
            InitializeComponent();
            colorDataGrid.AutoGenerateColumns = false;
        }

        private void UpdateColorForm_Load(object sender, EventArgs e)
        {
            DataFill();
        }

        private void DataFill()
        {
            var colors = this.ColorDataServices.GetAllColors();
            colorDataGrid.DataSource = colors;
            if (colors.Count == 0)
            {
                DisableButtons();
            } else
            {
                EnableButtons();
            }
        }

        public ColorServices ColorDataServices
        {
            get => colorDataServices;
            set => colorDataServices = value;
        }

        private void colorDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            var currentRow = colorDataGrid.CurrentRow;
            this.SelectedColor = currentRow.DataBoundItem as ColorDto;
            UpdateColorPanelView(SelectedColor);
        }

        private ColorDto SelectedColor
        {
            get; set;
        }

        private void UpdateColorPanelView(ColorDto selectedColor)
        {
            idTextBox.Text = selectedColor.ColorId.ToString();
            colorTextBox.Text = selectedColor.Name;            
            colorTextBox.Enabled = true;
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

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (SelectedColor == null)
                return;
            if (SelectedColor.Name.Equals(NewColorName))
                return;
            if (ColorDataServices.ExistColorByName(NewColorName))
            {
                MessageBox.Show(Messages.ELEMENT_EXISTS, Constants.MESSAGE_CAPTION);
                return;
            }

            ColorDataServices.UpdateColor(SelectedColor.ColorId, NewColorName);
            SelectedColor.Name = NewColorName;
            colorDataGrid.Refresh();
            MessageBox.Show(String.Format(Messages.ELEMENT_UPDATED_SUCCESS, EntityNames.COlOR_ENTITY_NAME), Constants.MESSAGE_CAPTION);
        }

        private string NewColorName
        {
            get
            {
                return this.colorTextBox.Text;
            }

            set
            {
                this.colorTextBox.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (SelectedColor == null)
                return;

            var dialogResult = MessageBox.Show(
                    String.Format(Messages.DO_YOU_WANT_TO_DELETED, SelectedColor.Name),
                    Constants.MESSAGE_CAPTION,
                    MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ColorDataServices.DeleteColor(SelectedColor.ColorId);
                DataFill();
                MessageBox.Show(String.Format(Messages.ELEMENT_DELETED_SUCESS, EntityNames.COlOR_ENTITY_NAME, SelectedColor.Name), Constants.MESSAGE_CAPTION);
            }
        }
    }
}
