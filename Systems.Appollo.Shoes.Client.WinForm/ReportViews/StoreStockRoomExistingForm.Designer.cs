using Subro.Controls;

namespace Systems.Appollo.Shoes.Client.WinForm.ReportViews
{
    partial class StoreStockRoomExistingForm
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
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.storeLabel = new System.Windows.Forms.Label();
            this.storeComboBox = new System.Windows.Forms.ComboBox();
            this.updateButton = new System.Windows.Forms.Button();
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
            this.productDetailsDataGridView.Location = new System.Drawing.Point(12, 46);
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
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(765, 505);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Cerrar";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Modelos:";
            // 
            // modelComboBox
            // 
            this.modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(549, 14);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(194, 21);
            this.modelComboBox.TabIndex = 4;
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(752, 12);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(86, 23);
            this.filterButton.TabIndex = 5;
            this.filterButton.Text = "Filtrar";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // storeLabel
            // 
            this.storeLabel.AutoSize = true;
            this.storeLabel.Location = new System.Drawing.Point(12, 18);
            this.storeLabel.Name = "storeLabel";
            this.storeLabel.Size = new System.Drawing.Size(48, 13);
            this.storeLabel.TabIndex = 6;
            this.storeLabel.Text = "Tiendas:";
            // 
            // storeComboBox
            // 
            this.storeComboBox.DisplayMember = "Name";
            this.storeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.storeComboBox.FormattingEnabled = true;
            this.storeComboBox.Location = new System.Drawing.Point(61, 14);
            this.storeComboBox.Name = "storeComboBox";
            this.storeComboBox.Size = new System.Drawing.Size(210, 21);
            this.storeComboBox.TabIndex = 7;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(277, 13);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 8;
            this.updateButton.Text = "Actualizar";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // StoreStockRoomExistingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 534);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.storeComboBox);
            this.Controls.Add(this.storeLabel);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.productDetailsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "StoreStockRoomExistingForm";
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
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Label storeLabel;
        private System.Windows.Forms.ComboBox storeComboBox;
        private System.Windows.Forms.Button updateButton;
    }
}