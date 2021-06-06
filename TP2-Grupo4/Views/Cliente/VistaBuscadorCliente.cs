using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4.Views.Cliente
{
    public partial class VistaBuscadorCliente : Form
    {

        private AgenciaManager agencia;

        public VistaBuscadorCliente(AgenciaManager agenciaManager)
        {
            InitializeComponent();
            this.agencia = agenciaManager;
            this.agregarBtnAlDataGridView();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String inputCiudad = this.inputBuscador.Text;
            DateTime fechaDesde = this.dateTimeDesde.Value;
            DateTime fechaHasta = this.dateTimeHasta.Value;

            this.limpiarDataGridView();
            this.llenarDataGridView(this.agencia.BuscarDeAlojamientosPorCiudadYFechas(inputCiudad, fechaDesde, fechaHasta));
                
        }

        private void limpiarDataGridView()
        {
            this.dataGridViewAlojamientos.Rows.Clear();
        }
        private void llenarDataGridView(List<List<String>> alojamientos)
        {
            foreach (List<String> alojamiento in alojamientos)
            {
                this.dataGridViewAlojamientos.Rows.Add(alojamiento.ToArray());
            }
        }

        private void agregarBtnAlDataGridView()
        {
            // Creo el boton
            var btnReservar = new DataGridViewButtonColumn
            {
                Text = "RESERVAR",
                UseColumnTextForButtonValue = true,
                Name = "RESERVAR",
                DataPropertyName = "RESERVAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnReservar.DefaultCellStyle.BackColor = Color.Green;
            btnReservar.ReadOnly = false;

            // Agrego el boton al dataGridView
            this.dataGridViewAlojamientos.Columns.Add(btnReservar);
        }
    
    }
}
