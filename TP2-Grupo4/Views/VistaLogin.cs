using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TP2_Grupo4.Models;
using TP2_Grupo4.Views;
using TP2_Grupo4;
using System.Runtime.InteropServices;

namespace TP2_Grupo4.Views
{
    public partial class VistaLogin : Form
    {
        private int intentos = 3;
        private string dni;
        private string password;
        private AgenciaManager agencia;

        public VistaLogin()
        {
            this.agencia = new AgenciaManager();
            InitializeComponent();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "USUARIO")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        // TODO: Password *********
        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CONTRASEÑA")
            {
                txtContrasena.Text = "";
                txtContrasena.UseSystemPasswordChar = true;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "CONTRASEÑA";
                txtContrasena.UseSystemPasswordChar = false;
            }
        }

        // TODO: Chequear intentos
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // admin
            // user: 40393222
            // pass: admin1234
            this.dni = txtUsuario.Text;
            this.password = txtContrasena.Text;

            

            if (this.agencia.autenticarUsuario(Int32.Parse(dni), password))
            {
                VistaDashboardAdmin vistaAdmin = new VistaDashboardAdmin(this.agencia);
                // VistaDashboardUsuario vistaUsuario = new VistaDashboardUsuario(this.agencia);

                if (!this.agencia.GetUsuarioLogeado().GetBloqueado())
                {
                    this.intentos = 3;
                    if (this.agencia.GetUsuarioLogeado().GetIsAdmin())
                    {
                        MessageBox.Show("Logueado");
                        vistaAdmin.Show();
                        this.Hide();
                    }
                    else
                    {
                        // TODO: Mostrar vistaUsuario
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show($"Usuario Bloqueado, hable con un administrador para desbloquear el usuario");
                }

            }
            else
            {
                this.intentos--;
                if (this.intentos == 0)
                {
                    this.agencia.BloquearUsuario(Int32.Parse(dni));
                    this.intentos = 3;
                    MessageBox.Show($"Usuario Bloqueado, hable con un administrador para desbloquear el usuario");
                }
                else
                {
                    MessageBox.Show($"Usuario o contraseña incorrecto, intenta de nuevo [ intentos: {this.intentos} ]");
                }
            }
        }

        // TODO: Mostrar VistaRegistrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //this.vistaRegistrar.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        #region Helpers
        // Nos permite utilizar librerias del sistema operativo, para poder mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        #endregion


    }
}
