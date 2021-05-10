using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4
{
    public partial class VistaClienteBuscar : Form
    {
        public VistaClienteBuscar()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            VistaClienteFiltrar cambiarFormulario = new VistaClienteFiltrar();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VistaClienteReservaciones cambiarFormulario = new VistaClienteReservaciones();
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
