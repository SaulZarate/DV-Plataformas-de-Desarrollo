using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4
{
    public partial class VistaAdminUsuarios : Form
    {
        public VistaAdminUsuarios()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VistaAdminReservas cambiarFormulario = new VistaAdminReservas();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VistaAdminAlojamientos cambiarFormulario = new VistaAdminAlojamientos();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login cambiarFormulario = new Login();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
