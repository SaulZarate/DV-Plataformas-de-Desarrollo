using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP2_Grupo4
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //validar si el usuario está correcto

            //si es válido y es cliente moverse a la VistaCliente
            VistaClienteFiltrar cambiarFormulario = new VistaClienteFiltrar();
            cambiarFormulario.Show();
            this.Hide();
            //newMDIChild2.Show();

            //si es válido y es admin moverse a la VistaAdmin
        }
    }
}
