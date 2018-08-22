﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Systems.Appollo.Shoes.Data.DataModels;
using Systems.Appollo.Shoes.Data.Services;

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Color
{
    public partial class UpdateColorForm : Form
    {
        private ColorServices colorDataServices;

        public UpdateColorForm()
        {
            InitializeComponent();
        }

        private void UpdateColorForm_Load(object sender, EventArgs e)
        {
            var colors = this.ColorDataServices.GetAllColors();
            colorDataGrid.DataSource = colors;

        }

        private ColorServices ColorDataServices
        {
            get
            {
                if (this.colorDataServices == null)
                    this.colorDataServices = new ColorServices();
                return this.colorDataServices;
            }
        }

        internal void SetColorDataService(ColorServices colorServices)
        {
            this.colorDataServices = colorServices;
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
            colorTextBox.Text = selectedColor.ColorName;
            updateButton.Enabled = true;
            removeButton.Enabled = true;
            colorTextBox.Enabled = true;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (SelectedColor == null)
                return;
            if (SelectedColor.ColorName.Equals(NewColorName))
                return;



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
    }
}
