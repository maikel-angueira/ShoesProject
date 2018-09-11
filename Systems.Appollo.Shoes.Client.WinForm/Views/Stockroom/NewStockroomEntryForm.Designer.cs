namespace Systems.Appollo.Shoes.Client.WinForm.Views.Stockroom
{
    partial class NewStockRoomEntryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dateInTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.photoLinkLabel = new System.Windows.Forms.LinkLabel();
            this.sizeComboBox = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.shoesPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modelo:";
            // 
            // modelComboBox
            // 
            this.modelComboBox.DisplayMember = "Name";
            this.modelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(17, 34);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(290, 21);
            this.modelComboBox.TabIndex = 1;
            this.modelComboBox.SelectedIndexChanged += new System.EventHandler(this.modelComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Color:";
            // 
            // colorComboBox
            // 
            this.colorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.colorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.colorComboBox.DisplayMember = "Name";
            this.colorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(17, 86);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(290, 21);
            this.colorComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Número:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cantidad:";
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(166, 217);
            this.quantityNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.quantityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(103, 20);
            this.quantityNumericUpDown.TabIndex = 7;
            this.quantityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dateInTime
            // 
            this.dateInTime.Location = new System.Drawing.Point(17, 149);
            this.dateInTime.Name = "dateInTime";
            this.dateInTime.Size = new System.Drawing.Size(290, 20);
            this.dateInTime.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Fecha Entrada:";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(363, 237);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 15;
            this.addButton.Text = "Insertar";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(444, 237);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 16;
            this.closeButton.Text = "Cerrar";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // photoLinkLabel
            // 
            this.photoLinkLabel.AutoSize = true;
            this.photoLinkLabel.Location = new System.Drawing.Point(374, 154);
            this.photoLinkLabel.Name = "photoLinkLabel";
            this.photoLinkLabel.Size = new System.Drawing.Size(77, 13);
            this.photoLinkLabel.TabIndex = 17;
            this.photoLinkLabel.TabStop = true;
            this.photoLinkLabel.Text = "Actualizar Foto";
            this.photoLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // sizeComboBox
            // 
            this.sizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeComboBox.FormattingEnabled = true;
            this.sizeComboBox.Items.AddRange(new object[] {
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50"});
            this.sizeComboBox.Location = new System.Drawing.Point(20, 216);
            this.sizeComboBox.Name = "sizeComboBox";
            this.sizeComboBox.Size = new System.Drawing.Size(117, 21);
            this.sizeComboBox.TabIndex = 18;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Images (*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG;*.)|*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG\"";
            // 
            // shoesPictureBox
            // 
            this.shoesPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shoesPictureBox.Location = new System.Drawing.Point(373, 17);
            this.shoesPictureBox.Name = "shoesPictureBox";
            this.shoesPictureBox.Size = new System.Drawing.Size(141, 134);
            this.shoesPictureBox.TabIndex = 14;
            this.shoesPictureBox.TabStop = false;
            // 
            // NewStockRoomEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 272);
            this.Controls.Add(this.sizeComboBox);
            this.Controls.Add(this.photoLinkLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.shoesPictureBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateInTime);
            this.Controls.Add(this.quantityNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewStockRoomEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada desde Taller";
            this.Load += new System.EventHandler(this.NewStockroomEntryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shoesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown;
        private System.Windows.Forms.DateTimePicker dateInTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox shoesPictureBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.LinkLabel photoLinkLabel;
        private System.Windows.Forms.ComboBox sizeComboBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}