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
    public partial class VistaAdminAlojamiento : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaAdminAlojamiento()
        {
            InitializeComponent();
        }

        private void FormAlojamiento_Load(object sender, EventArgs e)
        {
            dgvAlojamiento.Columns.Add("CODIGO", "Codigo");
            dgvAlojamiento.Columns.Add("CIUADAD", "Ciudad");
            dgvAlojamiento.Columns.Add("BARRIO", "Barrio");
            dgvAlojamiento.Columns.Add("ESTRELLAS", "Estrellas");
            dgvAlojamiento.Columns.Add("CANTPERSONAS", "Cant. Personas");
            dgvAlojamiento.Columns.Add("TV", "TV");
            dgvAlojamiento.Columns.Add("PRECIO", "Precio");

            dgvAlojamiento.ReadOnly = true;
            comboBoxTipoAloj.SelectedIndex = 0;
            getTextAlojamientos();
        }

        private void getTextAlojamientos()
        {
            foreach (List<String> alojamiento in this.agencia.GetAgencia().DatosDeAlojamientosParaLasVistas())
                this.dgvAlojamiento.Rows.Add(alojamiento.ToArray());

            //List<Alojamiento> alojamientos = this.agencia.GetAgencia().GetAlojamientos();
            //foreach (Alojamiento alojamiento in alojamientos)
            //{
            //    this.dgvAlojamiento.Rows.Add(
            //        alojamiento.GetCodigo().ToString(),
            //        alojamiento.GetCiudad(),
            //        alojamiento.GetBarrio(),
            //        alojamiento.GetEstrellas(),
            //        alojamiento.GetCantidadDePersonas().ToString(),
            //        alojamiento.GetTv(),
            //        "$" + alojamiento.PrecioTotalDelAlojamiento().ToString()
            //    );
            //}
        }

        private void getTextHoteles()
        {
            foreach (List<String> alojamiento in this.agencia.GetAgencia().DatosDeHotelesParaLasVistas())
                this.dgvAlojamiento.Rows.Add(alojamiento.ToArray());
            //List<Alojamiento> alojamientos = this.agencia.GetAgencia().GetHoteles();
            //foreach (Alojamiento alojamiento in alojamientos)
            //{
            //    this.dgvAlojamiento.Rows.Add(
            //        alojamiento.GetCodigo(),
            //        alojamiento.GetCiudad(),
            //        alojamiento.GetBarrio(),
            //        alojamiento.GetEstrellas(),
            //        alojamiento.GetCantidadDePersonas(),
            //        alojamiento.GetTv(),
            //        alojamiento.PrecioTotalDelAlojamiento()
            //    );
            //}
        }

        private void getTextCabanias()
        {
            foreach (List<String> alojamiento in this.agencia.GetAgencia().DatosDeCabaniasParaLasVistas())
                this.dgvAlojamiento.Rows.Add(alojamiento.ToArray());
            //List<Alojamiento> alojamientos = this.agencia.GetAgencia().GetCabanias();
            //foreach (Alojamiento alojamiento in alojamientos)
            //{
            //    this.dgvAlojamiento.Rows.Add(
            //        alojamiento.GetCodigo(),
            //        alojamiento.GetCiudad(),
            //        alojamiento.GetBarrio(),
            //        alojamiento.GetEstrellas(),
            //        alojamiento.GetCantidadDePersonas(),
            //        alojamiento.GetTv(),
            //        alojamiento.PrecioTotalDelAlojamiento()
            //    );
            //}
        }

        private void comboBoxTipoAloj_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvAlojamiento.Rows.Clear();
            if ((comboBoxTipoAloj.SelectedItem).ToString() == "Hotel")
            {
                getTextHoteles();
            }
            else if ((comboBoxTipoAloj.SelectedItem).ToString() == "Cabaña")
            {
                getTextCabanias();
            }
            else
            {
                getTextAlojamientos();
            }
        }

    }
}
