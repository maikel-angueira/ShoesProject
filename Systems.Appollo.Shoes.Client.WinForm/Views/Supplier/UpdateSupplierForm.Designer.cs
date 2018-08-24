namespace Systems.Appollo.Shoes.Client.WinForm.Views.Supplier
{
    partial class UpdateSupplierForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.supplierDataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.sellerAddressTextBox = new System.Windows.Forms.TextBox();
            this.sellerNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.closeButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.sellerPictureBox = new System.Windows.Forms.PictureBox();
            this.IdGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplierDataGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sellerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.supplierDataGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 419);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado Proveedores:";
            // 
            // sellerDataGrid
            // 
            this.supplierDataGrid.AllowUserToAddRows = false;
            this.supplierDataGrid.AllowUserToDeleteRows = false;
            this.supplierDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplierDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGridColumn,
            this.NameGridColumn});
            this.supplierDataGrid.Location = new System.Drawing.Point(7, 23);
            this.supplierDataGrid.MultiSelect = false;
            this.supplierDataGrid.Name = "sellerDataGrid";
            this.supplierDataGrid.ReadOnly = true;
            this.supplierDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplierDataGrid.Size = new System.Drawing.Size(425, 373);
            this.supplierDataGrid.TabIndex = 0;
            this.supplierDataGrid.SelectionChanged += new System.EventHandler(this.modelDataGrid_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.removeButton);
            this.groupBox2.Controls.Add(this.updateButton);
            this.groupBox2.Controls.Add(this.sellerAddressTextBox);
            this.groupBox2.Controls.Add(this.sellerNameTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.linkLabel1);
            this.groupBox2.Controls.Add(this.sellerPictureBox);
            this.groupBox2.Location = new System.Drawing.Point(456, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 419);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proveedor Seleccionado:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dirección Particular:";
            // 
            // removeButton
            // 
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(434, 380);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Eliminar";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Enabled = false;
            this.updateButton.Location = new System.Drawing.Point(346, 380);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Actualizar";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // sellerAddressTextBox
            // 
            this.sellerAddressTextBox.AcceptsReturn = true;
            this.sellerAddressTextBox.Location = new System.Drawing.Point(186, 93);
            this.sellerAddressTextBox.Multiline = true;
            this.sellerAddressTextBox.Name = "sellerAddressTextBox";
            this.sellerAddressTextBox.Size = new System.Drawing.Size(324, 86);
            this.sellerAddressTextBox.TabIndex = 5;
            // 
            // sellerNameTextBox
            // 
            this.sellerNameTextBox.Location = new System.Drawing.Point(185, 42);
            this.sellerNameTextBox.Name = "sellerNameTextBox";
            this.sellerNameTextBox.Size = new System.Drawing.Size(324, 20);
            this.sellerNameTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(7, 186);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Actualizar Foto";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(898, 437);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Cerrar";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Images (*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG;*.)|*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG\"";
            // 
            // sellerPictureBox
            // 
            this.sellerPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sellerPictureBox.Location = new System.Drawing.Point(6, 23);
            this.sellerPictureBox.Name = "sellerPictureBox";
            this.sellerPictureBox.Size = new System.Drawing.Size(156, 156);
            this.sellerPictureBox.TabIndex = 0;
            this.sellerPictureBox.TabStop = false;
            // 
            // IdGridColumn
            // 
            this.IdGridColumn.DataPropertyName = "SupplierId";
            this.IdGridColumn.HeaderText = "ID";
            this.IdGridColumn.Name = "IdGridColumn";
            this.IdGridColumn.ReadOnly = true;
            // 
            // NameGridColumn
            // 
            this.NameGridColumn.DataPropertyName = "Name";
            this.NameGridColumn.HeaderText = "Nombre";
            this.NameGridColumn.Name = "NameGridColumn";
            this.NameGridColumn.ReadOnly = true;
            this.NameGridColumn.Width = 250;
            // 
            // UpdateSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 466);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UpdateSupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Modelos de Zapatos";
            this.Load += new System.EventHandler(this.UpdateModelForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.supplierDataGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sellerPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox sellerNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox sellerPictureBox;
        private System.Windows.Forms.TextBox sellerAddressTextBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView supplierDataGrid;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellerIdGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellerNameGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameGridColumn;
    }
}