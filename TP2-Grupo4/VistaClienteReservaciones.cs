using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4
{
    public partial class VistaClienteReservaciones : Form
    {
        public VistaClienteReservaciones()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VistaClienteFiltrar cambiarFormulario = new VistaClienteFiltrar();
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
