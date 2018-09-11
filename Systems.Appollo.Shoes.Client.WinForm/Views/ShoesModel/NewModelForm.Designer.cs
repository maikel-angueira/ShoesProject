namespace Systems.Appollo.Shoes.Client.WinForm.Views.ShoesModel
{
    partial class NewModelForm
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
            this.modelNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.modelPictureBox = new System.Windows.Forms.PictureBox();
            this.insertButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.modelOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.shoesTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.costNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.allColorRadioButton = new System.Windows.Forms.RadioButton();
            this.selectColorRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.colorPanelContainer = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.modelPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.costNumericUpDown)).BeginInit();
            this.colorPanelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Modelo:";
            // 
            // modelNameTextBox
            // 
            this.modelNameTextBox.Location = new System.Drawing.Point(193, 39);
            this.modelNameTextBox.Name = "modelNameTextBox";
            this.modelNameTextBox.Size = new System.Drawing.Size(321, 20);
            this.modelNameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.AcceptsReturn = true;
            this.descriptionTextBox.Location = new System.Drawing.Point(196, 313);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(314, 71);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(19, 168);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(52, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Subir foto";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // modelPictureBox
            // 
            this.modelPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.modelPictureBox.Location = new System.Drawing.Point(22, 23);
            this.modelPictureBox.Name = "modelPictureBox";
            this.modelPictureBox.Size = new System.Drawing.Size(151, 142);
            this.modelPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.modelPictureBox.TabIndex = 0;
            this.modelPictureBox.TabStop = false;
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(355, 392);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 6;
            this.insertButton.Text = "Insertar";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(436, 392);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Cerrar";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // modelOpenFileDialog
            // 
            this.modelOpenFileDialog.Filter = "Images (*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG;*.)|*.JPEG;*.BMP;*.JPG;*.GIF;*.PNG\"";
            this.modelOpenFileDialog.Title = "Choose Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tipo de Zapato:";
            // 
            // shoesTypeComboBox
            // 
            this.shoesTypeComboBox.DisplayMember = "Name";
            this.shoesTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shoesTypeComboBox.FormattingEnabled = true;
            this.shoesTypeComboBox.Location = new System.Drawing.Point(193, 82);
            this.shoesTypeComboBox.Name = "shoesTypeComboBox";
            this.shoesTypeComboBox.Size = new System.Drawing.Size(321, 21);
            this.shoesTypeComboBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(193, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Precio Costo:";
            // 
            // costNumericUpDown
            // 
            this.costNumericUpDown.DecimalPlaces = 2;
            this.costNumericUpDown.Location = new System.Drawing.Point(196, 126);
            this.costNumericUpDown.Name = "costNumericUpDown";
            this.costNumericUpDown.Size = new System.Drawing.Size(77, 20);
            this.costNumericUpDown.TabIndex = 12;
            // 
            // allColorRadioButton
            // 
            this.allColorRadioButton.AutoSize = true;
            this.allColorRadioButton.Checked = true;
            this.allColorRadioButton.Location = new System.Drawing.Point(306, 127);
            this.allColorRadioButton.Name = "allColorRadioButton";
            this.allColorRadioButton.Size = new System.Drawing.Size(55, 17);
            this.allColorRadioButton.TabIndex = 14;
            this.allColorRadioButton.TabStop = true;
            this.allColorRadioButton.Text = "Todos";
            this.allColorRadioButton.UseVisualStyleBackColor = true;
            // 
            // selectColorRadioButton
            // 
            this.selectColorRadioButton.AutoSize = true;
            this.selectColorRadioButton.Location = new System.Drawing.Point(366, 127);
            this.selectColorRadioButton.Name = "selectColorRadioButton";
            this.selectColorRadioButton.Size = new System.Drawing.Size(81, 17);
            this.selectColorRadioButton.TabIndex = 15;
            this.selectColorRadioButton.Text = "Seleccionar";
            this.selectColorRadioButton.UseVisualStyleBackColor = true;
            this.selectColorRadioButton.CheckedChanged += new System.EventHandler(this.selectColorRadioButton_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(297, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 29);
            this.panel1.TabIndex = 16;
            // 
            // colorCheckedListBox
            // 
            this.colorCheckedListBox.FormattingEnabled = true;
            this.colorCheckedListBox.Location = new System.Drawing.Point(3, 4);
            this.colorCheckedListBox.MultiColumn = true;
            this.colorCheckedListBox.Name = "colorCheckedListBox";
            this.colorCheckedListBox.Size = new System.Drawing.Size(314, 94);
            this.colorCheckedListBox.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Colores Disponibles:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // colorPanelContainer
            // 
            this.colorPanelContainer.Controls.Add(this.linkLabel2);
            this.colorPanelContainer.Controls.Add(this.colorCheckedListBox);
            this.colorPanelContainer.Enabled = false;
            this.colorPanelContainer.Location = new System.Drawing.Point(196, 174);
            this.colorPanelContainer.Name = "colorPanelContainer";
            this.colorPanelContainer.Size = new System.Drawing.Size(321, 119);
            this.colorPanelContainer.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(292, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 48);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colores";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(248, 101);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(66, 13);
            this.linkLabel2.TabIndex = 18;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Nuevo Color";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // NewModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 423);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selectColorRadioButton);
            this.Controls.Add(this.allColorRadioButton);
            this.Controls.Add(this.costNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.shoesTypeComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.modelNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modelPictureBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.colorPanelContainer);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "NewModelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Modelo Zapato";
            this.Load += new System.EventHandler(this.NewModelForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modelPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.costNumericUpDown)).EndInit();
            this.colorPanelContainer.ResumeLayout(false);
            this.colorPanelContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox modelPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modelNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.OpenFileDialog modelOpenFileDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox shoesTypeComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown costNumericUpDown;
        private System.Windows.Forms.RadioButton allColorRadioButton;
        private System.Windows.Forms.RadioButton selectColorRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox colorCheckedListBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel colorPanelContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}