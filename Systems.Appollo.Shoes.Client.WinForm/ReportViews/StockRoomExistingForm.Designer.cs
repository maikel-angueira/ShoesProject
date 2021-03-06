﻿using Subro.Controls;

namespace Systems.Appollo.Shoes.Client.WinForm.ReportViews
{
    partial class StockRoomExistingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ModelNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.filterButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productDetailsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // productDetailsDataGridView
            // 
            this.productDetailsDataGridView.AllowUserToAddRows = false;
            this.productDetailsDataGridView.AllowUserToDeleteRows = false;
            this.productDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productDetailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.ModelNameColumn,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.productDetailsDataGridView.Location = new System.Drawing.Point(12, 49);
            this.productDetailsDataGridView.MultiSelect = false;
            this.productDetailsDataGridView.Name = "productDetailsDataGridView";
            this.productDetailsDataGridView.ReadOnly = true;
            this.productDetailsDataGridView.RowTemplate.Height = 50;
            this.productDetailsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.productDetailsDataGridView.Size = new System.Drawing.Size(828, 450);
            this.productDetailsDataGridView.TabIndex = 1;
            this.productDetailsDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.productDetailsDataGridView_DataError);
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Photo";
            this.Column6.HeaderText = "";
            this.Column6.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 50;
            // 
            // ModelNameColumn
            // 
            this.ModelNameColumn.DataPropertyName = "ModelName";
            this.ModelNameColumn.HeaderText = "Modelo";
            this.ModelNameColumn.Name = "ModelNameColumn";
            this.ModelNameColumn.ReadOnly = true;
            this.ModelNameColumn.Width = 220;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Color";
            this.Column2.HeaderText = "Color";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Size";
            this.Column3.HeaderText = "Número";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "LastStockDate";
            this.Column4.HeaderText = "Fecha última entrada";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Total";
            this.Column5.HeaderText = "Total";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Modelos:";
            // 
            // modelComboBox
            // 
            this.modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(64, 22);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(251, 21);
            this.modelComboBox.TabIndex = 4;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(323, 20);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(86, 23);
            this.filterButton.TabIndex = 5;
            this.filterButton.Text = "Filtrar";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // StockRoomExistingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 512);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.productDetailsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "StockRoomExistingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Existencia de Productos en Almacén";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockRoomExistingForm_FormClosing);
            this.Load += new System.EventHandler(this.StockRoomExistingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productDetailsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView productDetailsDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.Button filterButton;
    }
}