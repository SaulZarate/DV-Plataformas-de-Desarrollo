using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4.Views.Cliente
{
    public partial class VistaFormNuevaCliente : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaFormNuevaCliente(AgenciaManager agenciaManager)
        {
            InitializeComponent();
            this.agencia = agenciaManager;
        }
    }
}
