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

namespace Systems.Appollo.Shoes.Client.WinForm.Views.Login
{
    public partial class LoginForm : Form
    {
        private bool login = false;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!login) e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void Login()
        {
            if (string.IsNullOrEmpty(userNameTextBox.Text)
                || string.IsNullOrEmpty(passwordTextBox.Text))
                return;

            if ("admin".Equals(userNameTextBox.Text)
                && "tissca".Equals(passwordTextBox.Text))
            {
                login = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectas. Contacte al administrador del sistema.", Constants.MESSAGE_CAPTION);
                userNameTextBox.Text = "";
                passwordTextBox.Text = "";
                userNameTextBox.Focus();
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Login();
        }
    }
}
