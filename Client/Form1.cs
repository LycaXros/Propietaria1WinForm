using Client.Utils;
using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private int fallos = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro de salir?","Cerrando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if(fallos == 3)
            {
                MessageBox.Show("Demasiados intentos...\nCerrando App");
                this.Close();
            }
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Favor de llenar los datos requeridos");
                txtUsername.Focus();
                return;
            }
            using (var db = new RRHHContext())
            {

                string user = txtUsername.Text.Trim().ToLower();
                string pass = txtPassword.Text.Trim();

                var u = await db.Credenciales.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(user));
                if (u == null)
                {
                    MessageBox.Show("Usuario no encontrado.");
                    Clear();
                    return;
                }

                var encrypted = CryptoServices.Encrypt(pass);
                if (!u.Password.Equals(encrypted))
                {
                    MessageBox.Show("Contraseña Incorrecta");
                    txtPassword.Clear();
                    txtPassword.Focus();
                    fallos += 1;
                    return;
                }
                fallos = 0;
                SimpleModels.EmpleadoDataModel userdata = new SimpleModels.EmpleadoDataModel()
                {
                    Id = u.EmpleadoId,
                    Nombre = u.DatosEmpleado.Nombre,
                    Cedula = u.DatosEmpleado.Cedula,
                    UserName = u.UserName
                };
                var mdi = new MDIs.MDI_User(db, userdata);
                this.Hide();
                mdi.ShowDialog();
                this.Show();
                Clear(); 
            }
        }

        private void Clear()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
