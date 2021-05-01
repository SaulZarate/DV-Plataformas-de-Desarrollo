using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4
{
    public partial class FormularioMDI : Form
    {
        public FormularioMDI()
        {
            InitializeComponent();
            Login newMDIChild = new Login();
            newMDIChild.MdiParent = this;
            newMDIChild.Show();


            //VistaClienteFiltrar newMDIChild2 = new VistaClienteFiltrar();
            //newMDIChild2.MdiParent = this;
            //newMDIChild2.Hide();
        }

        private void FormularioMDI_Load(object sender, EventArgs e)
        {

        }
    }
}
