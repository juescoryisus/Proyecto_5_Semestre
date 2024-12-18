using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Proyecto_5_Semestre
{
    public partial class Form1 : Form
    {
        // Usuario y contraseña predefinidos (encriptados)
        private readonly string storedUsername = "jesus";
        private readonly string storedPasswordHash = SecurityHelper.ComputeSha256Hash("281004");
        public Form1()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string passwordHash = SecurityHelper.ComputeSha256Hash(password);

            if (username == storedUsername && passwordHash == storedPasswordHash)
            {
                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mainMenu mainMenu = new mainMenu();
                this.Hide();
                mainMenu.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

    }
}
