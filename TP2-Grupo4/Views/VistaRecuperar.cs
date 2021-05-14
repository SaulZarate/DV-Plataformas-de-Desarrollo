using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TP2_Grupo4.Views
{
    public partial class VistaRecuperar : Form
    {
        private AgenciaManager agencia;
        public VistaRecuperar()
        {
            InitializeComponent();
            this.agencia = new AgenciaManager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaLogin cambiarFormulario = new VistaLogin();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VistaRegistrar cambiarFormulario = new VistaRegistrar();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "DNI")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "DNI";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CONTRASEÑA NUEVA")
            {
                txtContrasena.Text = "";
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "CONTRASEÑA NUEVA";
            }
        }
        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE")
            {
                txtNombre.Text = "";
            }
        }
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "NOMBRE";
            }
        }
        private void txtMail_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "EMAIL")
            {
                txtMail.Text = "";
            }
        }
        private void txtMail_Leave(object sender, EventArgs e)
        {
            if (txtMail.Text == "")
            {
                txtMail.Text = "EMAIL";
                txtMail.Text = "EMAIL";
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                agencia.ModificarUsuario(int.Parse(txtUsuario.Text), txtNombre.Text, txtMail.Text, txtContrasena.Text);
                //agencia.AgregarUsuario(, txtNombre.Text, txtMail.Text, txtContrasena.Text);
                agencia.GuardarCambiosDeLosUsuarios();
                txtUsuario.Text = "";
                txtNombre.Text = "";
                txtMail.Text = "";
                txtContrasena.Text = "";
                MessageBox.Show("Se ha modificado el usuario de manera exitosa.");
            }
            catch
            {
                MessageBox.Show("Error en la modificación, por favor intentelo nuevamente.");
            }
        }
    }
}
