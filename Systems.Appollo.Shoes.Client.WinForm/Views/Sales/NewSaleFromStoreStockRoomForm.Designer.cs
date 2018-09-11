namespace Systems.Appollo.Shoes.Client.WinForm.Views.Sales
{
    partial class NewSaleFromStoreStockRoomForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.storeComboBox = new System.Windows.Forms.ComboBox();
            this.newSaleButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cancelSaleButton = new System.Windows.Forms.Button();
            this.saleDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.saveSalesButton = new System.Windows.Forms.Button();
            this.saleProductDataGridView = new System.Windows.Forms.DataGridView();
            this.saleProductDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.removeProductButton = new System.Windows.Forms.Button();
            this.saleDetailsStatusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.quantityToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalSaleToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.storeNameToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.storeToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.removeAllButton = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saleProductDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleProductDtoBindingSource)).BeginInit();
            this.saleDetailsStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
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
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 487);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Productos para la Venta";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.storeComboBox);
            this.groupBox3.Controls.Add(this.newSaleButton);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(13, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(331, 100);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // storeComboBox
            // 
            this.storeComboBox.DisplayMember = "Name";
            this.storeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(65, 19);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(258, 21);
            this.storeComboBox.TabIndex = 11;
            // 
            // newSaleButton
            // 
            this.newSaleButton.Enabled = false;
            this.newSaleButton.Location = new System.Drawing.Point(221, 56);
            this.newSaleButton.Name = "newSaleButton";
            this.newSaleButton.Size = new System.Drawing.Size(102, 23);
            this.newSaleButton.TabIndex = 4;
            this.newSaleButton.Text = "Iniciar Venta";
            this.newSaleButton.UseVisualStyleBackColor = true;
            this.newSaleButton.Click += new System.EventHandler(this.newSaleButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tienda:";
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(254, 284);
            this.quantityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(82, 20);
            this.quantityNumericUpDown.TabIndex = 9;
            this.quantityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cantidad:";
            // 
            // priceNumericUpDown
            // 
            this.priceNumericUpDown.DecimalPlaces = 2;
            this.priceNumericUpDown.Location = new System.Drawing.Point(142, 284);
            this.priceNumericUpDown.Name = "priceNumericUpDown";
            this.priceNumericUpDown.Size = new System.Drawing.Size(82, 20);
            this.priceNumericUpDown.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio(U):";
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Location = new System.Drawing.Point(22, 284);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(90, 21);
            this.sizeComboBox.TabIndex = 5;
            this.sizeComboBox.SelectedValueChanged += new System.EventHandler(this.sizeComboBox_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 267);
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
            this.colorComboBox.Location = new System.Drawing.Point(22, 217);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(315, 21);
            this.colorComboBox.TabIndex = 3;
            this.colorComboBox.SelectedValueChanged += new System.EventHandler(this.colorComboBox_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 201);
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
            this.modelComboBox.Location = new System.Drawing.Point(19, 158);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(318, 21);
            this.modelComboBox.TabIndex = 1;
            this.modelComboBox.SelectedValueChanged += new System.EventHandler(this.modelComboBox_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modelo:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.addButton);
            this.groupBox4.Location = new System.Drawing.Point(13, 124);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 357);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            // 
            // addButton
            // 
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(221, 234);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(102, 23);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Añadir a Venta";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cancelSaleButton);
            this.groupBox2.Controls.Add(this.saleDateTimePicker);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.saveSalesButton);
            this.groupBox2.Controls.Add(this.saleProductDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(374, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(647, 487);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles de la Venta por Productos";
            // 
            // cancelSaleButton
            // 
            this.cancelSaleButton.Enabled = false;
            this.cancelSaleButton.Location = new System.Drawing.Point(538, 20);
            this.cancelSaleButton.Name = "cancelSaleButton";
            this.cancelSaleButton.Size = new System.Drawing.Size(96, 23);
            this.cancelSaleButton.TabIndex = 14;
            this.cancelSaleButton.Text = "Cancelar Venta";
            this.cancelSaleButton.UseVisualStyleBackColor = true;
            this.cancelSaleButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // saleDateTimePicker
            // 
            this.saleDateTimePicker.Location = new System.Drawing.Point(53, 23);
            this.saleDateTimePicker.Name = "saleDateTimePicker";
            this.saleDateTimePicker.Size = new System.Drawing.Size(264, 20);
            this.saleDateTimePicker.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Fecha:";
            // 
            // saveSalesButton
            // 
            this.saveSalesButton.Enabled = false;
            this.saveSalesButton.Location = new System.Drawing.Point(427, 21);
            this.saveSalesButton.Name = "saveSalesButton";
            this.saveSalesButton.Size = new System.Drawing.Size(96, 23);
            this.saveSalesButton.TabIndex = 1;
            this.saveSalesButton.Text = "Salvar Venta";
            this.saveSalesButton.UseVisualStyleBackColor = true;
            this.saveSalesButton.Click += new System.EventHandler(this.saveSalesButton_Click);
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
            this.totalSaleToolStripStatusLabel,
            this.toolStripStatusLabel2,
            this.storeNameToolStripStatusLabel,
            this.storeToolStripLabel});
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
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel2.Text = "Tienda:";
            // 
            // storeNameToolStripStatusLabel
            // 
            this.storeNameToolStripStatusLabel.Name = "storeNameToolStripStatusLabel";
            this.storeNameToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // storeToolStripLabel
            // 
            this.storeToolStripLabel.Name = "storeToolStripLabel";
            this.storeToolStripLabel.Size = new System.Drawing.Size(94, 17);
            this.storeToolStripLabel.Text = "[Sin Seleccionar]";
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
            // NewSaleFromStoreStockRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 558);
            this.Controls.Add(this.removeAllButton);
            this.Controls.Add(this.saleDetailsStatusStrip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.removeProductButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewSaleFromStoreStockRoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Venta de Zapatos desde Tiendas";
            this.Load += new System.EventHandler(this.NewSaleFromStockRoomForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceNumericUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox storeComboBox;
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
        private System.Windows.Forms.Button removeAllButton;
        private System.Windows.Forms.Button cancelSaleButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button newSaleButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel storeNameToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel storeToolStripLabel;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}