namespace Systems.Appollo.Shoes.Client.WinForm.Views.Sales
{
    partial class NewSaleFromStockRoomForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saleDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.saveSalesButton = new System.Windows.Forms.Button();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.saleProductDataGridView = new System.Windows.Forms.DataGridView();
            this.saleProductDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.removeProductButton = new System.Windows.Forms.Button();
            this.saleDetailsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.quantityToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalSaleToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.newSaleButton = new System.Windows.Forms.Button();
            this.removeAllButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleProductDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleProductDtoBindingSource)).BeginInit();
            this.saleDetailsStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.quantityNumericUpDown);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.priceNumericUpDown);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.sizeComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.colorComboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.modelComboBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 487);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Productos para la Venta";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(253, 229);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(82, 23);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Adicionar";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(253, 161);
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(82, 20);
            this.quantityNumericUpDown.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cantidad:";
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.DecimalPlaces = 2;
            this.priceNumericUpDown.Location = new System.Drawing.Point(141, 161);
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(82, 20);
            this.priceNumericUpDown.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio(U):";
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Location = new System.Drawing.Point(21, 161);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(90, 21);
            this.sizeComboBox.TabIndex = 5;
            this.sizeComboBox.SelectedValueChanged += new System.EventHandler(this.sizeComboBox_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Número:";
            // 
            // colorComboBox
            // 
            this.colorComboBox.DisplayMember = "Name";
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(21, 94);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(315, 21);
            this.colorComboBox.TabIndex = 3;
            this.colorComboBox.SelectedValueChanged += new System.EventHandler(this.colorComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color:";
            // 
            // modelComboBox
            // 
            this.modelComboBox.DisplayMember = "Name";
            this.modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(18, 35);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(318, 21);
            this.modelComboBox.TabIndex = 1;
            this.modelComboBox.SelectedValueChanged += new System.EventHandler(this.modelComboBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modelo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saleDateTimePicker);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.saveSalesButton);
            this.groupBox2.Controls.Add(this.clientComboBox);
            this.groupBox2.Controls.Add(this.saleProductDataGridView);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(374, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 487);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles de la Venta por Productos";
            // 
            // saleDateTimePicker
            // 
            this.saleDateTimePicker.Location = new System.Drawing.Point(322, 20);
            this.saleDateTimePicker.Name = "saleDateTimePicker";
            this.saleDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.saleDateTimePicker.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fecha:";
            // 
            // saveSalesButton
            // 
            this.saveSalesButton.Enabled = false;
            this.saveSalesButton.Location = new System.Drawing.Point(538, 18);
            this.saveSalesButton.Name = "saveSalesButton";
            this.saveSalesButton.Size = new System.Drawing.Size(96, 23);
            this.saveSalesButton.TabIndex = 1;
            this.saveSalesButton.Text = "Salvar Venta";
            this.saveSalesButton.UseVisualStyleBackColor = true;
            this.saveSalesButton.Click += new System.EventHandler(this.saveSalesButton_Click);
            // 
            // clientComboBox
            // 
            this.clientComboBox.DisplayMember = "Name";
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(52, 20);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(217, 21);
            this.clientComboBox.TabIndex = 11;
            // 
            // saleProductDataGridView
            // 
            this.saleProductDataGridView.AllowUserToAddRows = false;
            this.saleProductDataGridView.AllowUserToDeleteRows = false;
            this.saleProductDataGridView.AllowUserToResizeRows = false;
            this.saleProductDataGridView.AutoGenerateColumns = false;
            this.saleProductDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.saleProductDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.saleProductDataGridView.DataSource = this.saleProductDtoBindingSource;
            this.saleProductDataGridView.Location = new System.Drawing.Point(6, 52);
            this.saleProductDataGridView.MultiSelect = false;
            this.saleProductDataGridView.Name = "saleProductDataGridView";
            this.saleProductDataGridView.ReadOnly = true;
            this.saleProductDataGridView.RowTemplate.Height = 50;
            this.saleProductDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.saleProductDataGridView.Size = new System.Drawing.Size(628, 429);
            this.saleProductDataGridView.TabIndex = 0;
            this.saleProductDataGridView.SelectionChanged += new System.EventHandler(this.saleProductDataGridView_SelectionChanged);
            // 
            // saleProductDtoBindingSource
            // 
            this.saleProductDtoBindingSource.DataSource = typeof(Systems.Appollo.Shoes.Data.Dtos.SaleProductDto);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cliente:";
            // 
            // removeProductButton
            // 
            this.removeProductButton.Enabled = false;
            this.removeProductButton.Location = new System.Drawing.Point(922, 505);
            this.removeProductButton.Name = "removeProductButton";
            this.removeProductButton.Size = new System.Drawing.Size(99, 23);
            this.removeProductButton.TabIndex = 2;
            this.removeProductButton.Text = "Eliminar Producto";
            this.removeProductButton.UseVisualStyleBackColor = true;
            this.removeProductButton.Click += new System.EventHandler(this.removeProductButton_Click);
            // 
            // saleDetailsStatusStrip
            // 
            this.saleDetailsStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.quantityToolStripStatusLabel,
            this.toolStripStatusLabel3,
            this.totalSaleToolStripStatusLabel});
            this.saleDetailsStatusStrip.Location = new System.Drawing.Point(0, 536);
            this.saleDetailsStatusStrip.Name = "saleDetailsStatusStrip";
            this.saleDetailsStatusStrip.Size = new System.Drawing.Size(1030, 22);
            this.saleDetailsStatusStrip.SizingGrip = false;
            this.saleDetailsStatusStrip.TabIndex = 3;
            this.saleDetailsStatusStrip.Text = "Detalles de la venta";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(72, 17);
            this.toolStripStatusLabel1.Text = "Producto(s):";
            // 
            // quantityToolStripStatusLabel
            // 
            this.quantityToolStripStatusLabel.Name = "quantityToolStripStatusLabel";
            this.quantityToolStripStatusLabel.Size = new System.Drawing.Size(13, 17);
            this.quantityToolStripStatusLabel.Text = "0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel3.Text = "Total Venta:";
            // 
            // totalSaleToolStripStatusLabel
            // 
            this.totalSaleToolStripStatusLabel.Name = "totalSaleToolStripStatusLabel";
            this.totalSaleToolStripStatusLabel.Size = new System.Drawing.Size(28, 17);
            this.totalSaleToolStripStatusLabel.Text = "0.00";
            // 
            // newSaleButton
            // 
            this.newSaleButton.Enabled = false;
            this.newSaleButton.Location = new System.Drawing.Point(263, 505);
            this.newSaleButton.Name = "newSaleButton";
            this.newSaleButton.Size = new System.Drawing.Size(102, 23);
            this.newSaleButton.TabIndex = 4;
            this.newSaleButton.Text = "Nueva Venta";
            this.newSaleButton.UseVisualStyleBackColor = true;
            this.newSaleButton.Click += new System.EventHandler(this.newSaleButton_Click);
            // 
            // removeAllButton
            // 
            this.removeAllButton.Enabled = false;
            this.removeAllButton.Location = new System.Drawing.Point(817, 505);
            this.removeAllButton.Name = "removeAllButton";
            this.removeAllButton.Size = new System.Drawing.Size(99, 23);
            this.removeAllButton.TabIndex = 5;
            this.removeAllButton.Text = "Eliminar Todos";
            this.removeAllButton.UseVisualStyleBackColor = true;
            this.removeAllButton.Click += new System.EventHandler(this.removeAllButton_Click);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ModelPhoto";
            this.Column1.HeaderText = "";
            this.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ModelName";
            this.Column2.HeaderText = "Modelo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ColorName";
            this.Column3.HeaderText = "Color";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Size";
            this.Column4.HeaderText = "Número";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Price";
            this.Column5.HeaderText = "Precio(U)";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Quantity";
            this.Column6.HeaderText = "Cantidad";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 60;
            // 
            // NewSaleFromStockRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 558);
            this.Controls.Add(this.removeAllButton);
            this.Controls.Add(this.newSaleButton);
            this.Controls.Add(this.saleDetailsStatusStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.removeProductButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewSaleFromStockRoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Venta de Zapatos";
            this.Load += new System.EventHandler(this.NewSaleFromStockRoomForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleProductDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleProductDtoBindingSource)).EndInit();
            this.saleDetailsStatusStrip.ResumeLayout(false);
            this.saleDetailsStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown priceNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox sizeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.DataGridView saleProductDataGridView;
        private System.Windows.Forms.Button removeProductButton;
        private System.Windows.Forms.Button saveSalesButton;
        private System.Windows.Forms.StatusStrip saleDetailsStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel quantityToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel totalSaleToolStripStatusLabel;
        private System.Windows.Forms.BindingSource saleProductDtoBindingSource;
        private System.Windows.Forms.DateTimePicker saleDateTimePicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button newSaleButton;
        private System.Windows.Forms.Button removeAllButton;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}