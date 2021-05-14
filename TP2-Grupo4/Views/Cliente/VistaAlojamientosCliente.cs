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
    public partial class VistaAlojamientosCliente : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        
        public VistaAlojamientosCliente(AgenciaManager agenciaManager)
        {
            InitializeComponent();
            this.agencia = agenciaManager;

            this.llenarSelects();
        }

        #region METODOS COMPLEMENTARIOS
        private void llenarSelects()
        {
            // Personas
            foreach(int numero in this.agencia.OpcionesDelSelectDePersonas())
                this.selectCantPersonas.Items.Add(numero);

            // Estrellas
            foreach (int numero in this.agencia.OpcionesDelSelectDeEstrellas())
                this.selectCantPersonas.Items.Add(numero);

            //// Barrios
            //foreach (String item in this.agencia.OpcionesDelSelectDeBarrios())
            //    System.Diagnostics.Debug.WriteLine(item);
            
            //// Ciudades
            //foreach (String item in this.agencia.OpcionesDelSelectDeCiudades())
            //    System.Diagnostics.Debug.WriteLine(item);
            
        }
        #endregion

        private void VistaAlojamientosCliente_Load(object sender, EventArgs e)
        {
            // Boton reservar
            var btnReservar = new DataGridViewButtonColumn
            {
                Text = "RESERVAR",
                UseColumnTextForButtonValue = true,
                Name = "RESERVAR",
                DataPropertyName = "RESERVAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnReservar.DefaultCellStyle.BackColor = Color.Green;

            var checkTv = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Tv",
                Name = "Tv"
            };

            dgvAlojamiento.Columns.Add("Codigo", "Código");
            dgvAlojamiento.Columns.Add("Ciudad", "Ciudad");
            dgvAlojamiento.Columns.Add("Barrio", "Barrio");
            dgvAlojamiento.Columns.Add("Estrellas", "Estrellas");
            dgvAlojamiento.Columns.Add("Cant. Personas", "Cantidad de Personas");
            dgvAlojamiento.Columns.Add(checkTv);
            dgvAlojamiento.Columns.Add("Precio", "Precio");

            dgvAlojamiento.Columns.Add(btnReservar);
            dgvAlojamiento.ReadOnly = false;
            getTextAlojamientos();
        }


        #region Filtros
        private void getTextAlojamientos()
        {
            List<Alojamiento> alojamientos = this.agencia.GetAgencia().GetAlojamientos();
            foreach (Alojamiento alojamiento in alojamientos)
            {
                this.dgvAlojamiento.Rows.Add(
                    alojamiento.GetCodigo(),
                    alojamiento.GetCiudad(),
                    alojamiento.GetBarrio(),
                    alojamiento.GetEstrellas(),
                    alojamiento.GetCantidadDePersonas(),
                    alojamiento.GetTv(),
                    alojamiento.PrecioTotalDelAlojamiento()
                );
            }
        }
        private void getTextHoteles()
        {
            List<Alojamiento> alojamientos = this.agencia.GetAgencia().GetHoteles().GetAlojamientos();
            foreach (Alojamiento alojamiento in alojamientos)
            {
                this.dgvAlojamiento.Rows.Add(
                    alojamiento.GetCodigo(),
                    alojamiento.GetCiudad(),
                    alojamiento.GetBarrio(),
                    alojamiento.GetEstrellas(),
                    alojamiento.GetCantidadDePersonas(),
                    alojamiento.GetTv(),
                    alojamiento.PrecioTotalDelAlojamiento()
                );
            }
        }
        private void getTextCabanias()
        {
            List<Alojamiento> alojamientos = this.agencia.GetAgencia().GetCabanias().GetAlojamientos();
            foreach (Alojamiento alojamiento in alojamientos)
            {
                this.dgvAlojamiento.Rows.Add(
                    alojamiento.GetCodigo(),
                    alojamiento.GetCiudad(),
                    alojamiento.GetBarrio(),
                    alojamiento.GetEstrellas(),
                    alojamiento.GetCantidadDePersonas(),
                    alojamiento.GetTv(),
                    alojamiento.PrecioTotalDelAlojamiento()
                );
            }
        }
        private void getEstrellas()
        {
            List<Alojamiento> alojamientos = this.agencia.GetAgencia().GetAlojamientoPorEstrellas().GetAlojamientos();
            foreach (Alojamiento alojamiento in alojamientos)
            {
                this.dgvAlojamiento.Rows.Add(
                    alojamiento.GetCodigo(),
                    alojamiento.GetCiudad(),
                    alojamiento.GetBarrio(),
                    alojamiento.GetEstrellas(),
                    alojamiento.GetCantidadDePersonas(),
                    alojamiento.GetTv(),
                    alojamiento.PrecioTotalDelAlojamiento()
                );
            }
        }
        #endregion


        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            this.dgvAlojamiento.Rows.Clear();

            if ((selectEstrellas.SelectedItem).ToString() == "1")
            {
                getEstrellas();
            }

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

        private void comboBoxCantPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int estrellas = comboBoxEstre;
            String cantpers = selectCantPersonas.Text;
            this.dgvAlojamiento.Rows.Clear();
            getEstrellas();
        }
        private void comboBoxTipoAloj_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboBoxTipoAloj.SelectedItem).ToString() == "Hotel")
            {
                this.dgvAlojamiento.Rows.Clear();
                getTextHoteles();
            }
            else if ((comboBoxTipoAloj.SelectedItem).ToString() == "Cabaña")
            {
                this.dgvAlojamiento.Rows.Clear();
                getTextCabanias();
            }
            else
            {
                this.dgvAlojamiento.Rows.Clear();
                getTextAlojamientos();
            }
        }
        private void dgvAlojamiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var date1 = new DateTime(2008, 3, 1, 7, 0, 0);
            DateTime date1 = DateTime.Now;

            //var date2 = new DateTime(2008, 5, 2, 8, 1, 1);
            //DateTime date2 = Convert.ToDateTime("2017-12-24 13:30:15");
            DateTime date2 = DateTime.Now;
            // Utilizamos el método AddDays para sumar 10 días:
            date2 = date2.AddDays(7);

            // Si hacemos click en Button RESERVAR
            if (dgvAlojamiento.Columns[e.ColumnIndex].Name == "RESERVAR")
            {
                if (MessageBox.Show("Estas seguro que quieres reservar este alojamiento?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvAlojamiento.CurrentCell.RowIndex;
                    // Codigo del Alojamiento
                    int codigo = Int32.Parse(dgvAlojamiento.Rows[rowIndex].Cells["Codigo"].Value.ToString());

                    // Guardar Datos
                    //int dni = agencia.GetUsuarioLogeado().GetDni();
                    // FALTA PONER LA FECHA Y EL USUARIO DE MANERA CORRECTA
                    this.agencia.AgregarReserva(date1, date2, codigo, this.agencia.GetUsuarioLogeado().GetDni());
                    this.agencia.GuardarCambiosDeLasReservas();

                    // Actualizar GridView
                    this.dgvAlojamiento.Rows.Clear();
                    getTextAlojamientos();
                }
            }
        }

    }
}
