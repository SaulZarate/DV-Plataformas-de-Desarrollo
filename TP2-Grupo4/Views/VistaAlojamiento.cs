using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TP2_Grupo4.Models;
using TP2_Grupo4;

namespace TP2_Grupo4.Views
{
    public partial class VistaAlojamiento : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaAlojamiento()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();

        // TODO: Añadir filtros

        // TODO: Cambiar Ciudad, Barrio, Estrellas y Personas por COMBOBOX
        // TODO: Cambiar TV por CHECKBOX
        private void FormAlojamiento_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Codigo", typeof(string));
            table.Columns.Add("Ciudad", typeof(string));
            table.Columns.Add("Barrio", typeof(string));
            table.Columns.Add("Estrellas", typeof(int));
            table.Columns.Add("Cant. Personas", typeof(string));
            table.Columns.Add("TV", typeof(bool));
            table.Columns.Add("Precio", typeof(string));

            dgvAlojamiento.DataSource = table;
            dgvAlojamiento.ReadOnly = false;
            getTextAlojamientos();
        }

        private void getTextAlojamientos()
        {
            List<Alojamiento> alojamientos = this.agencia.GetAgencia().GetAllAlojamientos();
            foreach (Alojamiento alojamiento in alojamientos)
            {
                this.table.Rows.Add(
                    alojamiento.GetCodigo().ToString(),
                    alojamiento.GetCiudad(),
                    alojamiento.GetBarrio(),
                    alojamiento.GetEstrellas(),
                    alojamiento.GetCantidadDePersonas().ToString(),
                    alojamiento.GetTv(),
                    "$" + alojamiento.PrecioTotalDelAlojamiento().ToString()
                );
            }

        }
    }
}
